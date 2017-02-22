using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardHolder : Singleton<PlayerCardHolder> {
	[SerializeField]
	private IconBattleCard[] fieldCardArr;
	
	public override void Initialize()
	{
		base.Initialize();

		CardParam param = new CardParam();
		param.card_type = "attack";
		param.power = 4567;
		param.speed = 123;

		foreach( IconBattleCard icon in fieldCardArr)
		{
			icon.Initialize(param,true);
		}
	}

}
