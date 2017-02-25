using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : DataManagerBase<DataManager> {

	public List<CardParam> show_card_list;

	public Card playerQuestDeck;

	public Stage stage;

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

		// 読めなかったとき対応が必要
		Debug.LogError("初期デッキデータが必要になります");
		playerQuestDeck = new Card();
		playerQuestDeck.LoadMulti("data/deck_quest");

		string strUrl = string.Format("https://spreadsheets.google.com/feeds/worksheets/{0}/public/basic", "13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I");
		//EveryStudioLibrary.CommonNetwork.Instance.Recieve(strUrl, onRecievedNetworkData);

		stage = new Stage();
		stage.OnRecieveData.AddListener(OnRecieveStageData);
		stage.LoadStageData("13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I", "stage1-1");
		ftime = 0.0f;
	}

	private void OnRecieveStageData(List<StageParam> arg0)
	{
	}

	public void onRecievedNetworkData(EveryStudioLibrary.TNetworkData _networkData)
	{
		/*
		Debug.LogError(_networkData.m_strData);

		int index = _networkData.m_strData.IndexOf("stage1-1");

		int index2 = _networkData.m_strData.IndexOf("13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I/", index);
		int index3 = _networkData.m_strData.IndexOf("/", index2 + "13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I/".Length);
		Debug.LogError(index);
		Debug.LogError(index2);
		Debug.LogError(index3);
		Debug.LogError(_networkData.m_strData.Substring(index2 + "13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I/".Length, index3 - (index2 + "13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I/".Length)));
		*/

		string ret = EveryStudioLibrary.CommonNetwork.ParseSpreadSheetSerial("13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I", "stage1-1", _networkData.m_strData);
		Debug.LogError(ret);

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
