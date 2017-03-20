using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoArea : MonoBehaviourEx {

	[SerializeField]
	private RectTransform m_rtSelf;
	[SerializeField]
	private RectTransform m_rtAreaPlayer;
	[SerializeField]
	private RectTransform m_rtAreaPartner;

	[SerializeField]
	private RectTransform m_rtCardHolder;

	[SerializeField]
	private GridLayoutGroup m_rtCardHolderGridLayout;

	void Awake()
	{
		m_rtSelf = gameObject.GetComponent<RectTransform>();
		//CheckRectTransform(m_rtSelf, "m_rtSelf");
		DeviceOrientationDetector.Instance.OnChangeOrientation.AddListener(OnChangeOrientation);
		OnChangeOrientation(DeviceOrientationDetector.Instance.orientation);
	}

	private void OnChangeOrientation(DeviceOrientationDetector.ORIENTATION _orientaiton)
	{
		if(_orientaiton == DeviceOrientationDetector.ORIENTATION.YOKO)
		{
			//CheckRectTransform(m_rtSelf, "m_rtSelf");
			m_rtSelf.pivot = new Vector2(0.5000f, 0.0000f);
			m_rtSelf.anchorMin = new Vector2(0.0000f, 0.0000f);
			m_rtSelf.anchorMax = new Vector2(1.0000f, 0.0000f);
			m_rtSelf.offsetMin = new Vector2(0.0000f, 0.0000f);
			m_rtSelf.offsetMax = new Vector2(0.0000f, 70.0000f);
			m_rtSelf.sizeDelta = new Vector2(0.0000f, 70.0000f);
			//CheckRectTransform(m_rtAreaPlayer, "m_rtAreaPlayer");
			m_rtAreaPlayer.anchorMin = new Vector2(0, 0);
			m_rtAreaPlayer.anchorMax = new Vector2(0, 0);
			m_rtAreaPlayer.offsetMin = new Vector2(0, 0);
			m_rtAreaPlayer.offsetMax = new Vector2(150, 300);
			m_rtAreaPlayer.sizeDelta = new Vector2(150, 300);
			//CheckRectTransform(m_rtAreaPartner, "m_rtAreaPartner");
			m_rtAreaPartner.anchorMin = new Vector2(1, 0);
			m_rtAreaPartner.anchorMax = new Vector2(1, 0);
			m_rtAreaPartner.offsetMin = new Vector2(-150, 0);
			m_rtAreaPartner.offsetMax = new Vector2(0, 300);
			m_rtAreaPartner.sizeDelta = new Vector2(150, 300);
			//CheckRectTransform(m_rtCardHolder, "m_rtCardHolder");
			m_rtCardHolder.anchorMin = new Vector2(0, 0);
			m_rtCardHolder.anchorMax = new Vector2(1, 0);
			m_rtCardHolder.offsetMin = new Vector2(0, 60);
			m_rtCardHolder.offsetMax = new Vector2(0, 160);
			m_rtCardHolder.sizeDelta = new Vector2(0, 100);
			m_rtCardHolderGridLayout.spacing = new Vector2(20.0f, 0.0f);

		}
		else
		{
			//CheckRectTransform(m_rtSelf, "m_rtSelf");
			m_rtSelf.pivot = new Vector2(0.5f, 0);
			m_rtSelf.anchorMin = new Vector2(0, 0);
			m_rtSelf.anchorMax = new Vector2(1, 0);
			m_rtSelf.offsetMin = new Vector2(0, 85);
			m_rtSelf.offsetMax = new Vector2(0, 155);
			m_rtSelf.sizeDelta = new Vector2(0, 70);
			//CheckRectTransform(m_rtAreaPlayer, "m_rtAreaPlayer");
			m_rtAreaPlayer.anchorMin = new Vector2(0, 0);
			m_rtAreaPlayer.anchorMax = new Vector2(0, 0);
			m_rtAreaPlayer.offsetMin = new Vector2(0, 0);
			m_rtAreaPlayer.offsetMax = new Vector2(100, 140);
			m_rtAreaPlayer.sizeDelta = new Vector2(100, 140);
			//CheckRectTransform(m_rtAreaPartner, "m_rtAreaPartner");
			m_rtAreaPartner.anchorMin = new Vector2(1, 0);
			m_rtAreaPartner.anchorMax = new Vector2(1, 0);
			m_rtAreaPartner.offsetMin = new Vector2(-100, 0);
			m_rtAreaPartner.offsetMax = new Vector2(0, 140);
			m_rtAreaPartner.sizeDelta = new Vector2(100, 140);
			//CheckRectTransform(m_rtCardHolder, "m_rtCardHolder");
			m_rtCardHolder.anchorMin = new Vector2(0, 0);
			m_rtCardHolder.anchorMax = new Vector2(1, 0);
			m_rtCardHolder.offsetMin = new Vector2(0, 130);
			m_rtCardHolder.offsetMax = new Vector2(0, 230);
			m_rtCardHolder.sizeDelta = new Vector2(0, 100);
			m_rtCardHolderGridLayout.spacing = new Vector2(3.0f, 0.0f);

		}
	}
	
}
