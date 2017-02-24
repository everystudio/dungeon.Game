using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShowUI : MonoBehaviour {

	virtual protected void onclick_event()
	{

	}

	[SerializeField]
	private string pageName;
	public void OnClick()
	{
		onclick_event();
		UIAssistant.main.ShowPage(pageName);
	}

}
