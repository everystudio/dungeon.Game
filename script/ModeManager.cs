using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : Singleton<ModeManager> {

	[SerializeField]
	private string Mode;

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
	}

	public override void Initialize()
	{
		base.Initialize();
		Mode = "none";
		ChangeMode("Startup");

		Invoke("testgame", 1.0f);
	}

	private void testgame()
	{
		UIAssistant.main.ShowPage("Main");
	}

}
