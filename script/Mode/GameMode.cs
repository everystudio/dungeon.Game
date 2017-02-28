using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : ModeBase {

	[SerializeField]
	private Camera cameraDungeon;

	protected override void mode_start()
	{
		cameraDungeon.gameObject.SetActive(true);
	}

	protected override void mode_end()
	{
		cameraDungeon.gameObject.SetActive(false);
	}

	public int m_iCount;

	protected override void initialize()
	{
		m_iCount = 0;

		PlayerCardHolder.Instance.OnFinishedMoveEvent.AddListener(OnFinishedMove);
		PlayerCardHolder.Instance.OnEndReloadEvent.AddListener(OnEndReload);
		PlayerCardHolder.Instance.OnEndShuffleEvent.AddListener(OnEndReload);
	}


	private void OnFinishedMove()
	{
		//Debug.LogError("GameMain.OnMoveFinished");
		DataManager.Instance.SaveUnlock();
		PlayerCardHolder.Instance.Reload();
	}

	private void OnEndReload()
	{
		//Debug.LogError("GameMain.OnReloadEnd");

		if(m_iCount == 0)
		{
			m_iCount += 1;
			DataManager.Instance.playerQuestDeck.Shuffle();
			PlayerCardHolder.Instance.Reload();
		}
	}

	private void OnEndShuffle()
	{
		Debug.LogError("GameMain.OnEndShuffle");

	}


}
