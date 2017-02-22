using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : DataManagerBase<DataManager> {

	public List<CardParam> show_card_list;

	public Dictionary<string, CardInfoParam> cardInfo = new Dictionary<string, CardInfoParam>();


	public override void Initialize()
	{
		// これは消しません
		SetDontDestroy(true);
		//Debug.LogError(QualitySettings.vSyncCount);
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

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

		ftime = 0.0f;
	}

	public CardInfoParam GetCardInfoParam(string _cardType)
	{
		CardInfoParam ret = null;
		cardInfo.TryGetValue(_cardType, out ret);
		return ret;
	}
	int frameCount;
	float ftime;
	[SerializeField]
	private Text FPS;
	void Update()
	{
		frameCount += 1;
		ftime += Time.deltaTime;
		if( 1.0f < ftime)
		{
			FPS.text = string.Format("FPS:{0:f2}", frameCount/ ftime);
			frameCount = 0;
			ftime -= 1.0f;
		}

	}

}
