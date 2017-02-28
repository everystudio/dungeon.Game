using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampMode : ModeBase {

	[SerializeField]
	private Camera cameraCamp;

	protected override void initialize()
	{

	}

	protected override void mode_start()
	{
		cameraCamp.gameObject.SetActive(true);
		
		Invoke("campmain", 1.0f);
		// ここでいろいろと派生させるべき
		

	}

	private void campmain()
	{
		UIAssistant.main.ShowPage("CampMain");

		Invoke("gotogame", 1.5f);
	}

	private void gotogame()
	{
		ModeManager.Instance.ChangeMode("GameMode");
	}

	protected override void mode_end()
	{
		cameraCamp.gameObject.SetActive(false);
	}
}
