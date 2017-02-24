using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardHolder : Singleton<PlayerCardHolder> {
	[SerializeField]
	private IconBattleCard[] fieldCardArr;

	public override void Initialize()
	{
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
		}
	}

}
