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


		ModeManager.Instance.ChangeMode("CampMode");
	}

	protected override void mode_end()
	{
	}

}
