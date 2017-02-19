using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : DataManagerBase<DataManager> {

	public List<CardParam> show_card_list;

	public Dictionary<string, CardInfoParam> cardInfo = new Dictionary<string, CardInfoParam>();


	public override void Initialize()
	{
		//Debug.LogError("datamanager.initialize");
		base.Initialize();
		Card datacard = new Card();
		datacard.LoadMulti("Data/deck/sample_deck");
		show_card_list = datacard.list;

		CardInfo card_info = new CardInfo();
		card_info.LoadMulti("Data/card_info");
		foreach( CardInfoParam param in card_info.list)
		{
			cardInfo.Add(param.card_type, param);
		}
	}

	public CardInfoParam GetCardInfoParam(string _cardType)
	{
		CardInfoParam ret = null;
		cardInfo.TryGetValue(_cardType, out ret);
		return ret;
	}
	

}
