using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICampMain : CPanel
{
	[SerializeField]
	private RectTransform rtRootMenu;

	[SerializeField]
	private RectTransform rtRootShopBanner;

	[SerializeField]
	private RectTransform rtButtonLeft;
	[SerializeField]
	private RectTransform rtButtonRight;

	[SerializeField]
	private GameObject m_goButtonShop;
	[SerializeField]
	private GameObject m_goButtonGacha;

	[SerializeField]
	private Image m_imgChara;
	[SerializeField]
	private RectTransform rtChara;

	protected override void panelStart()
	{
		base.panelStart();
		OnChangeOrientation(DeviceOrientationDetector.Instance.orientation);
	}

	public void OnClickQuest()
	{
		ModeManager.Instance.ChangeMode("GameMode");
	}

	protected override void awake()
	{
		base.awake();
		DeviceOrientationDetector.Instance.OnChangeOrientation.AddListener(OnChangeOrientation);
	}

	private void OnChangeOrientation(DeviceOrientationDetector.ORIENTATION _orientaiton)
	{
		if (_orientaiton == DeviceOrientationDetector.ORIENTATION.YOKO)
		{
			//CheckRectTransform(rtRootMenu, "rtRootMenu");
			rtRootMenu.pivot = new Vector2(0.5f, 1);
			rtRootMenu.anchorMin = new Vector2(0, 1);
			rtRootMenu.anchorMax = new Vector2(1, 1);
			rtRootMenu.offsetMin = new Vector2(0, -150);
			rtRootMenu.offsetMax = new Vector2(0, 0);
			rtRootMenu.sizeDelta = new Vector2(0, 150);

			//CheckRectTransform(rtRootShopBanner, "rtRootShopBanner");
			rtRootShopBanner.anchorMin = new Vector2(0, 0);
			rtRootShopBanner.anchorMax = new Vector2(1, 0);
			rtRootShopBanner.offsetMin = new Vector2(0, 60);
			rtRootShopBanner.offsetMax = new Vector2(0, 160);
			rtRootShopBanner.pivot = new Vector2(0.5f, 0.5f);
			rtRootShopBanner.sizeDelta = new Vector2(0, 100);

			//m_goButtonShop.transform.parent = rtButtonRight.transform;
			//m_goButtonGacha.transform.parent = rtButtonRight.transform;

			//CheckRectTransform(rtChara, "rtChara");
			rtChara.pivot = new Vector2(0.5f, 0.5f);
			rtChara.anchorMin = new Vector2(0.5f, 0.5f);
			rtChara.anchorMax = new Vector2(0.5f, 0.5f);
			rtChara.offsetMin = new Vector2(-300, -400);
			rtChara.offsetMax = new Vector2(300, 400);
			rtChara.sizeDelta = new Vector2(800,600);
		}
		else
		{
			//CheckRectTransform(rtRootMenu, "rtRootMenu");
			rtRootMenu.pivot = new Vector2(0.5f, 1);
			rtRootMenu.anchorMin = new Vector2(0, 1);
			rtRootMenu.anchorMax = new Vector2(1, 1);
			rtRootMenu.offsetMin = new Vector2(0, -230);
			rtRootMenu.offsetMax = new Vector2(0, -80);
			rtRootMenu.sizeDelta = new Vector2(0, 150);

			//CheckRectTransform(rtRootShopBanner, "rtRootShopBanner");
			rtRootShopBanner.anchorMin = new Vector2(0, 0);
			rtRootShopBanner.anchorMax = new Vector2(1, 0);
			rtRootShopBanner.offsetMin = new Vector2(0, 140);
			rtRootShopBanner.offsetMax = new Vector2(0, 240);
			rtRootShopBanner.pivot = new Vector2(0.5f, 0.5f);
			rtRootShopBanner.sizeDelta = new Vector2(0, 100);

			//m_goButtonShop.transform.parent = rtButtonLeft.transform;
			//m_goButtonGacha.transform.parent = rtButtonLeft.transform;

			//CheckRectTransform(rtChara, "rtChara");
			rtChara.pivot = new Vector2(0.5f, 0.5f);
			rtChara.anchorMin = new Vector2(0.5f, 0.5f);
			rtChara.anchorMax = new Vector2(0.5f, 0.5f);
			rtChara.offsetMin = new Vector2(-400, -300);
			rtChara.offsetMax = new Vector2(400, 300);
			rtChara.sizeDelta = new Vector2(800, 600);
			/*
			rtChara.pivot = new Vector2(1, 0);
			rtChara.anchorMin = new Vector2(1, 0);
			rtChara.anchorMax = new Vector2(1, 0);
			rtChara.offsetMin = new Vector2(-300, 240);
			rtChara.offsetMax = new Vector2(0, 840);
			rtChara.sizeDelta = new Vector2(300, 600);
			*/
		}
	}
}

