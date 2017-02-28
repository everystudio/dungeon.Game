using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : Singleton<ModeManager> {
	[SerializeField]
	private string Mode;

	public ModeBase GetMode(string _strModeName)
	{
		ModeBase ret = null;
		modeDict.TryGetValue(_strModeName, out ret);
		return ret;
	}

	public ModeBase currentMode;

	[SerializeField]
	private Camera DungeonCamera;
	[SerializeField]
	private Camera CampCamera;

	public void ChangeMode( string _strMode)
	{
		if(Mode.Equals(_strMode))
		{
			return;
		}
		if( currentMode != null)
		{
			currentMode.ModeEnd();
		}

		currentMode = GetMode(_strMode);
		if(currentMode != null)
		{
			currentMode.ModeStart();
		}

		/*
		switch(_strMode)
		{
			case "Startup":
				CampCamera.gameObject.SetActive(true);
				DungeonCamera.gameObject.SetActive(false);
				break;
			case "Game":
				DungeonCamera.gameObject.SetActive(true);
				CampCamera.gameObject.SetActive(false);
				break;

			case "Camp":
			default:
				CampCamera.gameObject.SetActive(true);
				DungeonCamera.gameObject.SetActive(false);
				break;
		}
		*/
	}

	public Dictionary<string,ModeBase> modeDict = new Dictionary<string, ModeBase>();

	public override void Initialize()
	{
		base.Initialize();

		currentMode = null;
		ModeBase[] modeArr = FindObjectsOfType<ModeBase>();
		foreach(ModeBase mode in modeArr)
		{
			modeDict.Add(mode.gameObject.name, mode);
		}
		/*
		*/
		foreach (string key in modeDict.Keys)
		{
			Debug.LogError(key);
		}
		Mode = "none";
		ChangeMode("StartupMode");
	}

}
