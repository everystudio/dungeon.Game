using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardHolder : Singleton<PlayerCardHolder> {

	[SerializeField]
	private GameObject m_posDeck;
	[SerializeField]
	private GameObject[] m_posObjectArr;

	private List<IconBattleCard> fieldCardList = new List<IconBattleCard>();

	public enum STEP
	{
		NONE		= 0,
		IDLE		,
		MOVING		,
		BATTLE		,
		MAX			,
	}
	public STEP m_eStep;
	public STEP m_eStepPre;
	public int m_iCheckCount;
	public bool m_bRequestShuffle;

	public void Reload()
	{
		foreach( GameObject obj in m_posObjectArr)
		{
			obj.SetActive(false);
		}

		int iIndex = 0;

		foreach( IconBattleCard icon in fieldCardList)
		{
			icon.goTarget = m_posObjectArr[iIndex];
			icon.goTarget.SetActive(true);
			iIndex += 1;
		}
		int iNokori = m_posObjectArr.Length - iIndex;

		List<CardParam> add = DataManager.Instance.playerQuestDeck.ChoiceStatus(Card.STATUS.READY, iNokori);

		foreach(CardParam param in add)
		{
			param.status = (int)Card.STATUS.FIELD;
			IconBattleCard script = PrefabManager.Instance.MakeScript<IconBattleCard>(
				"prefab/BattleCardIcon", m_posDeck);
			script.transform.localScale = Vector3.zero;
			script.goTarget = m_posObjectArr[iIndex];
			script.goTarget.SetActive(true);
			iIndex += 1;

			script.Initialize(param, true);
			script.OnClickEvent.AddListener(OnClickCard);
			fieldCardList.Add(script);
		}

		iIndex = 0;
		m_iCheckCount = 0;

		// 次のデッキを繰り出しで大丈夫かどうかチェック
		m_bRequestShuffle = false;
		if( fieldCardList.Count != m_posObjectArr.Length)
		{
			m_bRequestShuffle = true;
		}

		foreach (IconBattleCard card in fieldCardList)
		{
			float fDelayInterval = 0.1f;
			m_iCheckCount += 1;
			card.OnEndResetPosition.AddListener(OnEndResetPosition);
			card.ResetPosition(fDelayInterval * iIndex, m_posDeck);
			iIndex += 1;
		}
		if( m_bRequestShuffle && fieldCardList.Count == 0)
		{
			ShuffleReload();
		}
		// 手元のカードのターゲットは左に寄せる
	}

	// とりあえず演出とかはいったん無しで
	public void ShuffleReload()
	{
		DataManager.Instance.playerQuestDeck.Shuffle();
		Reload();
	}

	public override void Initialize()
	{
		Invoke("_initialize", 0.1f);
	}
	private void _initialize() {
		m_eStep = STEP.IDLE;
		m_eStepPre = STEP.NONE;

		foreach (GameObject obj in m_posObjectArr)
		{
			obj.transform.localScale = Vector3.zero;
			obj.SetActive(false);
		}
		base.Initialize();

		List<CardParam> deckCardParam = new List<CardParam>();
		deckCardParam.Clear();

		int iPosIndex = 0;

		//　復帰処理とかなのでとりあえず復元させるだけ
		m_bRequestShuffle = false;
		foreach (CardParam param in DataManager.Instance.playerQuestDeck.list)
		{
			if( param.status == 1 )
			{
				deckCardParam.Add(param);

				m_posObjectArr[iPosIndex].SetActive(true);

				IconBattleCard script = PrefabManager.Instance.MakeScript<IconBattleCard>(
					"prefab/BattleCardIcon", m_posDeck);
				script.transform.localScale = Vector3.zero;
				script.goTarget = m_posObjectArr[iPosIndex];

				iPosIndex += 1;

				script.Initialize(param, true);
				script.OnClickEvent.AddListener(OnClickCard);
				fieldCardList.Add(script);
				/*
				*/
			}
		}

		iPosIndex = 0;
		foreach( IconBattleCard card in fieldCardList)
		{
			m_iCheckCount += 1;
			float fDelayInterval = 0.1f;
			//card.gameObject.transform.position = m_posDeck.transform.position;
			card.OnEndResetPosition.AddListener(OnEndResetPosition);
			card.ResetPosition(fDelayInterval * iPosIndex , m_posDeck);
			iPosIndex += 1;
		}
	}
	public void OnEndResetPosition(IconBattleCard _icon)
	{
		_icon.OnEndResetPosition.RemoveListener(OnEndResetPosition);
		m_iCheckCount -= 1;
		if(m_iCheckCount == 0)
		{
			Debug.LogError("allend");
			if (m_bRequestShuffle)
			{
				ShuffleReload();
			}
		}
	}

	public void OnClickCard( IconBattleCard _icon )
	{
		switch( m_eStep)
		{
			case STEP.IDLE:
				/*
				_icon.RefreshDisp();
				*/
				_icon.param.status = (int)Card.STATUS.USED;
				_icon.OnActionBattleUsed.AddListener(OnActionBattleCardUsed);
				_icon.ActionBattleUse();
				m_eStep = STEP.MOVING;
				break;
		}
	}


	private void OnActionBattleCardUsed(IconBattleCard _icon)
	{
		_icon.OnActionBattleUsed.RemoveListener(OnActionBattleCardUsed);
		FloorRoute.Instance.OnMoveFinished.AddListener(OnMoveFinished);
		FloorRoute.Instance.MoveStart(_icon.param.speed);

		if (fieldCardList.Remove(_icon))
		{
			_icon.goTarget.SetActive(false);
			foreach (IconBattleCard card in fieldCardList)
			{
				card.ResetPosition(0.1f, card.goTarget);
			}
			Destroy(_icon.gameObject);
		}
		else
		{
			throw new System.Exception("手持ちデッキに無いカードを除外しようとしました");
		}
	}

	public void OnMoveFinished()
	{
		//Debug.LogError("OnMoveFinished");
		FloorRoute.Instance.OnMoveFinished.RemoveListener(OnMoveFinished);
		m_eStep = STEP.IDLE;

		if( 1 == fieldCardList.Count)
		{
			Reload();
		}


	}


}
