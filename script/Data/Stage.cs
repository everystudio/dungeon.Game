using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageParam : CsvDataParam
{
	public int id { get; set; }
	public int next_id { get; set; }
	public int px { get; set; }
	public int py { get; set; }
	public int pz { get; set; }

	public int rx { get; set; }
	public int ry { get; set; }
	public int rz { get; set; }


}

public class Stage : CsvData<StageParam> {

	//private OnLoadedStageData m_callback;
	//public delegate void OnLoadedStageData(List<StageParam> _paramList);
	public void LoadStageData(string _strSpreadSheet, string _strSheetName )
	{
		m_strSpreadSheet = _strSpreadSheet;
		m_strSheetName = _strSheetName;
		//m_callback = _callback;
		EveryStudioLibrary.CommonNetwork.Instance.RecieveSpreadSheeWorksheets(_strSpreadSheet, onRecievedWorksheet);
	}
	/*
	public void onRecievedWorksheet(EveryStudioLibrary.TNetworkData _networkData)
	{
		string sheet_id = EveryStudioLibrary.CommonNetwork.ParseSpreadSheetSerial(m_strSpreadSheet, m_strSheetName, _networkData.m_strData);

		LoadSpreadSheet(m_strSpreadSheet, sheet_id);

		//EveryStudioLibrary.CommonNetwork.Instance.RecieveSpreadSheet(m_strSpreadSheet, sheet_id, onRecievedNetworkData);
	}
	*/
	public void onRecievedNetworkData(EveryStudioLibrary.TNetworkData _networkData)
	{

	}




}







