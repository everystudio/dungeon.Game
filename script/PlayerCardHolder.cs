using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardHolder : Singleton<PlayerCardHolder> {
	[SerializeField]
	private IconBattleCard[] fieldCardArr;

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

	public override void Initialize()
	{
		m_eStep = STEP.IDLE;
		m_eStepPre = STEP.NONE;

		base.Initialize();

		List<CardParam> deckCardParam = new List<CardParam>();
		deckCardParam.Clear();

		foreach (CardParam param in DataManager.Instance.playerQuestDeck.list)
		{
			if( param.status == 1 || param.status == 2)
			{
				deckCardParam.Add(param);
			}
		}

		for( int i = 0; i < fieldCardArr.Length; i++) 
		{
			fieldCardArr[i].Initialize(deckCardParam[i],true);

			fieldCardArr[i].OnClickEvent.AddListener(OnClickCard);

		}
	}

	public void OnClickCard( IconBattleCard _icon )
	{
		switch( m_eStep)
		{
			case STEP.IDLE:
				FloorRoute.Instance.OnMoveFinished.AddListener(OnMoveFinished);
				FloorRoute.Instance.MoveStart(_icon.param.speed);
				_icon.param.status = (int)Card.STATUS.FIELD_USED;
				_icon.RefreshDisp();
				m_eStep = STEP.MOVING;
				break;
		}
	}


	public void OnMoveFinished()
	{
		//Debug.LogError("OnMoveFinished");
		FloorRoute.Instance.OnMoveFinished.RemoveListener(OnMoveFinished);
		m_eStep = STEP.IDLE;
	}


}
