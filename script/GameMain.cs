using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : Singleton<GameMain> {

	public int m_iCount;

	public override void Initialize()
	{
		m_iCount = 0;
		base.Initialize();

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
