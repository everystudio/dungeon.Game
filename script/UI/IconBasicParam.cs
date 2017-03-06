using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBasicParam : MonoBehaviourEx {

	[SerializeField]
	private Image imgBack;
	[SerializeField]
	private Image imgIcon;
	[SerializeField]
	private Text txtName;
	[SerializeField]
	private Text txtParam;

	public void SetOrientation(DeviceOrientationDetector.ORIENTATION _orientaiton)
	{
		if (_orientaiton == DeviceOrientationDetector.ORIENTATION.YOKO)
		{
			//CheckRectTransform(imgBack.rectTransform, "imgBack.rectTransform");
			imgBack.rectTransform.pivot = new Vector2(0.5f, 0.5f);
			imgBack.rectTransform.anchorMin = new Vector2(0, 1);
			imgBack.rectTransform.anchorMax = new Vector2(0, 1);
			imgBack.rectTransform.offsetMin = new Vector2(5.199997f, -55);
			imgBack.rectTransform.offsetMax = new Vector2(170.2f, -5);
			imgBack.rectTransform.sizeDelta = new Vector2(165, 50);

			//CheckRectTransform(imgIcon.rectTransform, "imgIcon.rectTransform");
			imgIcon.rectTransform.pivot = new Vector2(0, 0.5f);
			imgIcon.rectTransform.anchorMin = new Vector2(0, 1);
			imgIcon.rectTransform.anchorMax = new Vector2(0, 1);
			imgIcon.rectTransform.offsetMin = new Vector2(0, -26.3f);
			imgIcon.rectTransform.offsetMax = new Vector2(30, 3.7f);
			imgIcon.rectTransform.sizeDelta = new Vector2(30, 30);
			
			//CheckRectTransform(txtName.rectTransform, "txtName.rectTransform");
			txtName.rectTransform.pivot = new Vector2(0.5f, 0.5f);
			txtName.rectTransform.anchorMin = new Vector2(0, 1);
			txtName.rectTransform.anchorMax = new Vector2(1, 1);
			txtName.rectTransform.offsetMin = new Vector2(30.8f, -30);
			txtName.rectTransform.offsetMax = new Vector2(67, 0);
			txtName.rectTransform.sizeDelta = new Vector2(50.2f, 30);

			//CheckRectTransform(txtParam.rectTransform, "txtParam.rectTransform");
			txtParam.rectTransform.pivot = new Vector2(0.5f, 0.5f);
			txtParam.rectTransform.anchorMin = new Vector2(1, 0);
			txtParam.rectTransform.anchorMax = new Vector2(1, 0);
			txtParam.rectTransform.offsetMin = new Vector2(-166.3f, -8.7f);
			txtParam.rectTransform.offsetMax = new Vector2(-6.300003f, 36.3f);
			txtParam.rectTransform.sizeDelta = new Vector2(160, 45);
		}
		else
		{
			//CheckRectTransform(imgBack.rectTransform, "imgBack.rectTransform");
			imgBack.rectTransform.pivot = new Vector2(0.5f, 0.5f);
			imgBack.rectTransform.anchorMin = new Vector2(0, 0);
			imgBack.rectTransform.anchorMax = new Vector2(0, 0);
			imgBack.rectTransform.offsetMin = new Vector2(0, 0);
			imgBack.rectTransform.offsetMax = new Vector2(0, 0);
			imgBack.rectTransform.sizeDelta = new Vector2(0, 0);

			//CheckRectTransform(imgIcon.rectTransform, "imgIcon.rectTransform");
			imgIcon.rectTransform.pivot = new Vector2(0, 0.5f);
			imgIcon.rectTransform.anchorMin = new Vector2(0, 0.5f);
			imgIcon.rectTransform.anchorMax = new Vector2(0, 0.5f);
			imgIcon.rectTransform.offsetMin = new Vector2(0, -32);
			imgIcon.rectTransform.offsetMax = new Vector2(64, 32);
			imgIcon.rectTransform.sizeDelta = new Vector2(64, 64);

			//CheckRectTransform(txtName.rectTransform, "txtName.rectTransform");
			txtName.rectTransform.pivot = new Vector2(0.5f, 0.5f);
			txtName.rectTransform.anchorMin = new Vector2(1, 0);
			txtName.rectTransform.anchorMax = new Vector2(1, 0);
			txtName.rectTransform.offsetMin = new Vector2(-43.9f, -1.4f);
			txtName.rectTransform.offsetMax = new Vector2(30.1f, 28.6f);
			txtName.rectTransform.sizeDelta = new Vector2(74, 30);

			//CheckRectTransform(txtParam.rectTransform, "txtParam.rectTransform");
			txtParam.rectTransform.pivot = new Vector2(0.5f, 0.5f);
			txtParam.rectTransform.anchorMin = new Vector2(1, 0.5f);
			txtParam.rectTransform.anchorMax = new Vector2(1, 0.5f);
			txtParam.rectTransform.offsetMin = new Vector2(-170, -22.5f);
			txtParam.rectTransform.offsetMax = new Vector2(-10, 22.5f);
			txtParam.rectTransform.sizeDelta = new Vector2(160, 45);
		}
	}

}
