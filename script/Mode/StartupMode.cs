using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupMode : ModeBase {

	protected override void initialize()
	{
	}

	protected override void mode_start()
	{
		Debug.LogError("startup mode.mode_start");


	}

	void Update()
	{
		if(DataManager.Instance.IsReady)
		{
			ModeManager.Instance.ChangeMode("CampMode");

			// この見方は破綻するきがする
			gameObject.SetActive(false);
		}
	}

	protected override void mode_end()
	{
	}

}
