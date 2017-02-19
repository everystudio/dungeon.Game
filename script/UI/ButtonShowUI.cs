using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShowUI : MonoBehaviour {

	[SerializeField]
	private string pageName;
	public void OnClick()
	{
		UIAssistant.main.ShowPage(pageName);
	}

}
