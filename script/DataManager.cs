using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventIconPlayer : UnityEvent<IconPlayer>
{
}
namespace dungeon
{
	public class DataManager : DataManagerBase<DataManager>
	{

		public List<CardParam> show_card_list;

		public Player playerData;
		public PlayerMaster playerMaster;

		public Partner partnerData;
		public PartnerMaster partnerMaster;

		public DataKvs gameQuestData;
		public Card gameQuestDeck;

		public Stage stage;

		public Dictionary<string, CardInfoParam> cardInfo = new Dictionary<string, CardInfoParam>();

		public int m_iSaveLock;
		public bool m_bSave;
		private bool m_bSavePre;

		public bool IsReady;

		public void SaveLock()
		{
			m_iSaveLock += 1;
		}
		public void SaveUnlock()
		{
			if (0 < m_iSaveLock)
			{
				m_iSaveLock -= 1;
			}
			return;
		}

		public void Save()
		{
			if (0 < m_iSaveLock)
			{
				Debug.LogError("try save but lock now");
				return;
			}
			gameQuestDeck.Save();
			gameQuestData.Save();
		}


		public override void Initialize()
		{
			IsReady = false;
			m_iSaveLock = 0;
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
			foreach (CardInfoParam param in card_info.list)
			{
				cardInfo.Add(param.card_type, param);
			}

			// 読めなかったとき対応が必要
			gameQuestData = new DataKvs();
			gameQuestData.SetSaveFilename("data/player_quest_data");
			if (gameQuestData.LoadMulti("data/player_quest_data") == false)
			{
				gameQuestData.Save();
			}

			Debug.LogError("初期デッキデータが必要になります");
			gameQuestDeck = new Card();
			gameQuestDeck.LoadMulti("data/deck_quest");
			gameQuestDeck.SetSaveFilename("data/deck_quest");

			stage = new Stage();
			stage.OnRecieveData.AddListener(OnRecieveStageData);
			stage.LoadStageData("13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I", "stage1-1");
			ftime = 0.0f;

			playerMaster = new PlayerMaster();
			playerMaster.OnRecieveData.AddListener(OnRecievePlayerMaster);
			playerMaster.SpreadSheet("15oWONkEF1GVKVGwU6GQEpZkPLGUdADItm9PMftpBpzE", "player");

			partnerMaster = new PartnerMaster();
			partnerMaster.OnRecieveData.AddListener(OnRecievePartnerMaster);
			partnerMaster.SpreadSheet("15oWONkEF1GVKVGwU6GQEpZkPLGUdADItm9PMftpBpzE", "partner");

			partnerData = new Partner();
			partnerData.SetSaveFilename("data/data_partner");
			if (partnerData.LoadMulti("data/data_partner") == false)
			{
				partnerData.Save();
			}


		}

		private void OnRecieveStageData(List<StageParam> arg0)
		{
			IsReady = true;
		}
		private void OnRecievePlayerMaster(List<PlayerMasterParam> paramList)
		{
			/*
			Debug.LogError("OnRecievePlayerMaster");
			foreach(PlayerMasterParam param in playerMaster.list) 
			{
				Debug.LogError(param.name);
			}
			*/
		}
		private void OnRecievePartnerMaster(List<PartnerMasterParam> paramList)
		{
			/*
			foreach (PartnerMasterParam param in paramList)
			{
				Debug.LogError(param.name);
			}
			*/
		}
		/*
		public void onRecievedNetworkData(EveryStudioLibrary.TNetworkData _networkData)
		{
			string ret = EveryStudioLibrary.CommonNetwork.ParseSpreadSheetSerial("13CqWTURQlBHQY3F1_7vcFbiRoQarUIxnpNe5ibt8P-I", "stage1-1", _networkData.m_strData);
			Debug.LogError(ret);
		}
		*/



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
			if (1.0f < ftime)
			{
				FPS.text = string.Format("FPS:{0:f2}", frameCount / ftime);
				frameCount = 0;
				ftime -= 1.0f;
			}

			if (m_bSave)
			{
				m_bSave = false;
				Save();
			}

		}



	}
}
