using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : ModeBase {

	public enum STATUS
	{
		NONE		= 0,
		GAMESTART	,
		IDLE		,
		MOVESTART	,
		MOVING		,
		MOVEEND		,

		EVENT		,
		EVENT_END	,

		RELOAD		,
		SHUFFLE		,

		END			,

		MAX			,

	}
	public STATUS m_eStatus;
	public STATUS m_eStatusPre;

	[SerializeField]
	private Camera cameraDungeon;

	private void gameCleanStart()
	{
		DataManager.Instance.playerQuestData.WriteInt("position_index", 0);
		DataManager.Instance.playerQuestData.Write("game_status", "playing");
		DataManager.Instance.playerQuestData.WriteInt("deck_max", 5);
		DataManager.Instance.playerQuestData.WriteInt("reload_card", 2);

		DataManager.Instance.playerQuestData.WriteInt("reload_limit", -1);		// レギュレーション系
		DataManager.Instance.playerQuestData.WriteInt("shuffle_limit", -1);      // レギュレーション系

		DataManager.Instance.playerQuestDeck.AllClear(Card.STATUS.READY);

		// 直接５にしてますけど設定値を使うべき
		List<CardParam> initial_cards = DataManager.Instance.playerQuestDeck.ChoiceStatus(Card.STATUS.READY, 5);
		foreach (CardParam param in initial_cards)
		{
			param.status = (int)Card.STATUS.FIELD;
		}
	}

	private void gameResume()
	{

	}

	protected override void mode_start()
	{
		Debug.LogError("GameMode.mode_start");
		if( DataManager.Instance.playerQuestData.HasKey("game_status"))
		{
			if(DataManager.Instance.playerQuestData.Read("game_status").Equals("playing"))
			{
				// 場所のリセット
				gameResume();
			}
			else
			{
			gameCleanStart();
			}
		}
		else
		{
			gameCleanStart();
		}
		cameraDungeon.gameObject.SetActive(true);
		int iPositionIndex = DataManager.Instance.playerQuestData.ReadInt("position_index");
		FloorRoute.Instance.SetIndexPosition(iPositionIndex);


		m_eStatus = STATUS.IDLE;

		PlayerCardHolder.Instance.GameStart();

	}

	protected override void mode_end()
	{
		cameraDungeon.gameObject.SetActive(false);
	}

	public int m_iCount;

	// コンストラクタ代わり
	protected override void initialize()
	{
		m_iCount = 0;
		//PlayerCardHolder.Instance.OnFinishedMoveEvent.AddListener(OnFinishedMove);
		//PlayerCardHolder.Instance.OnEndReloadEvent.AddListener(OnEndReload);
		PlayerCardHolder.Instance.OnClickCardEvent.AddListener(OnClickCard);
	}

	private void OnClickCard(IconBattleCard _icon)
	{
		if (m_eStatus == STATUS.IDLE)
		{
			DataManager.Instance.SaveLock();
			_icon.param.status = (int)Card.STATUS.USED;
			_icon.OnActionBattleUsed.AddListener(OnActionBattleCardUsed);
			_icon.ActionBattleUse();
			m_eStatus = STATUS.MOVESTART;
		}

	}

	private void OnActionBattleCardUsed(IconBattleCard _icon)
	{
		m_eStatus = STATUS.MOVING;
		_icon.OnActionBattleUsed.RemoveListener(OnActionBattleCardUsed);
		FloorRoute.Instance.OnMoveFinished.AddListener(OnMoveFinished);
		FloorRoute.Instance.MoveStart(_icon.param.speed);
		PlayerCardHolder.Instance.RemoveCard(_icon);
	}
	private void OnMoveFinished()
	{
		FloorRoute.Instance.OnMoveFinished.RemoveListener(OnMoveFinished);

		DataManager.Instance.playerQuestData.WriteInt("position_index", FloorRoute.Instance.m_iIndex);

		m_eStatus = STATUS.MOVEEND;

		//m_eStep = STEP.MOVE_END;
		//DataManager.Instance.SaveUnlock();

		//OnFinishedMoveEvent.Invoke();
		DataManager.Instance.SaveUnlock();

		int num = DataManager.Instance.playerQuestData.ReadInt("reload_card");

		Debug.LogError(string.Format("num:{0} hasnum:{1}", num, PlayerCardHolder.Instance.HasCardNum()));

		if( PlayerCardHolder.Instance.HasCardNum() <= num)
		{
			PlayerCardHolder.Instance.OnEndReloadEvent.AddListener(OnEndReload);
			PlayerCardHolder.Instance.Reload();
			m_eStatus = STATUS.RELOAD;
		}
		else
		{
			m_eStatus = STATUS.EVENT;
			m_eStatus = STATUS.IDLE;
		}

	}

	private void OnEndReload()
	{
		PlayerCardHolder.Instance.OnEndReloadEvent.RemoveListener(OnEndReload);
		Debug.LogError("GameMain.OnReloadEnd");

		if(PlayerCardHolder.Instance.HasCardNum() < DataManager.Instance.playerQuestData.ReadInt("deck_max"))
		{
			// シャッフルの回数制限

			DataManager.Instance.playerQuestDeck.Shuffle();

			PlayerCardHolder.Instance.OnEndReloadEvent.AddListener(OnEndReload);
			PlayerCardHolder.Instance.Reload();

		}
		else
		{
			m_eStatus = STATUS.EVENT;
			m_eStatus = STATUS.IDLE;
			DataManager.Instance.Save();
		}






	}



}
