using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerTop : CPanel {

	[SerializeField]
	private Image m_imgPlayer;

	[SerializeField]
	private Text m_txtPlayerName;

	#region ネームバー
	[SerializeField]
	private RectTransform rtNameBar;
	#endregion

	#region イメージエリア
	[SerializeField]
	private RectTransform rtImageArea;
	#endregion

	#region ステータスエリア
	[SerializeField]
	private RectTransform rtStatusArea;
	[SerializeField]
	private GridLayoutGroup gridLayoutGroupMainStatus;
	[SerializeField]
	private RectTransform rtBasicParam;
	[SerializeField]
	private RectTransform rtAttributeParam;

	[SerializeField]
	private RectTransform rtSkillArea;
	#endregion

	#region キャラクターバー
	[SerializeField]
	private ScrollRect scrollRect;
	[SerializeField]
	private RectTransform rtScrollRect;
	[SerializeField]
	private RectTransform rtContents;
	[SerializeField]
	private GridLayoutGroup gridLayoutGroup;
	List<IconPlayer> iconPlayerList = new List<IconPlayer>();
	#endregion

	[SerializeField]
	private List<IconBasicParam> iconBasicParamList;

	private IconPlayer m_selectingPlayer;

	protected override void panelStart()
	{
		m_selectingPlayer = null;
		base.panelStart();

		OnChangeOrientation(DeviceOrientationDetector.Instance.orientation);

		IconPlayer[] iconPlayerArr = rtContents.gameObject.GetComponentsInChildren<IconPlayer>();
		foreach( IconPlayer icon in iconPlayerArr)
		{
			Destroy(icon.gameObject);
		}
		iconPlayerList.Clear();

		foreach ( PlayerMasterParam param in DataManager.Instance.playerMaster.list)
		{
			IconPlayer script = PrefabManager.Instance.MakeScript<IconPlayer>( "prefab/IconPlayer", rtContents.gameObject);
			script.gameObject.transform.localScale = Vector3.one;
			script.OnEventIconPlayer.AddListener(OnSelectPlayer);
			script.Initialize(param);
			if(m_selectingPlayer == null)
			{
				m_selectingPlayer = script;
			}
		}

		OnSelectPlayer(m_selectingPlayer);
	}

	private void OnSelectPlayer(IconPlayer _selectedPlayer)
	{
		m_selectingPlayer = _selectedPlayer;

		m_txtPlayerName.text = m_selectingPlayer.masterParam.name;
		m_imgPlayer.sprite = SpriteManager.Instance.LoadSprite(PlayerMaster.GetImageFilename(m_selectingPlayer.masterParam.player_id));

		//Debug.LogError(m_imgPlayer.sprite.rect);
		m_imgPlayer.rectTransform.sizeDelta = new Vector2(m_imgPlayer.sprite.rect.width, m_imgPlayer.sprite.rect.height);
	}

	protected override void awake()
	{
		base.awake();
		//m_rtSelf = gameObject.GetComponent<RectTransform>();
		DeviceOrientationDetector.Instance.OnChangeOrientation.AddListener(OnChangeOrientation);
	}

	private void OnChangeOrientation(DeviceOrientationDetector.ORIENTATION _orientaiton)
	{
		if (_orientaiton == DeviceOrientationDetector.ORIENTATION.YOKO)
		{
			//CheckRectTransform(rtNameBar, "rtNameBar");
			rtNameBar.pivot = new Vector2(0.5f, 1);
			rtNameBar.anchorMin = new Vector2(0, 1);
			rtNameBar.anchorMax = new Vector2(1, 1);
			rtNameBar.offsetMin = new Vector2(0, -75);
			rtNameBar.offsetMax = new Vector2(-150, 0);
			rtNameBar.sizeDelta = new Vector2(-150, 75);

			//CheckRectTransform(rtImageArea, "rtImageArea");
			rtImageArea.pivot = new Vector2(0.5f, 0.5f);
			rtImageArea.anchorMin = new Vector2(0, 0);
			rtImageArea.anchorMax = new Vector2(1, 1);
			rtImageArea.offsetMin = new Vector2(0, 0);
			rtImageArea.offsetMax = new Vector2(-616.9f, -70);
			rtImageArea.sizeDelta = new Vector2(-616.9f, -70);

			//CheckRectTransform(rtStatusArea, "rtStatusArea");
			rtStatusArea.pivot = new Vector2(0.5f, 0.5f);
			rtStatusArea.anchorMin = new Vector2(0, 0);
			rtStatusArea.anchorMax = new Vector2(1, 1);
			rtStatusArea.offsetMin = new Vector2(308.275f, 0);
			rtStatusArea.offsetMax = new Vector2(-154.275f, -69.99994f);
			rtStatusArea.sizeDelta = new Vector2(-462.55f, -69.99994f);

			
			//CheckRectTransform(rtBasicParam, "rtBasicParam");
			rtBasicParam.pivot = new Vector2(0.5f, 1);
			rtBasicParam.anchorMin = new Vector2(0, 1);
			rtBasicParam.anchorMax = new Vector2(1, 1);
			rtBasicParam.offsetMin = new Vector2(10, -139.22f);
			rtBasicParam.offsetMax = new Vector2(-10, -81.5f);
			rtBasicParam.sizeDelta = new Vector2(-20, 57.72f);
			gridLayoutGroupMainStatus.cellSize = new Vector2(109.0f, 50.0f);
			gridLayoutGroupMainStatus.spacing = new Vector2(1.0f, 3.0f);

			//CheckRectTransform(rtSkillArea, "rtSkillArea");
			rtAttributeParam.pivot = new Vector2(0.5f, 1);
			rtAttributeParam.anchorMin = new Vector2(0, 1);
			rtAttributeParam.anchorMax = new Vector2(1, 1);
			rtAttributeParam.offsetMin = new Vector2(9.999939f, -210.16f);
			rtAttributeParam.offsetMax = new Vector2(-10.00006f, -143);
			rtAttributeParam.sizeDelta = new Vector2(-20, 67.16f);

			//CheckRectTransform(rtAttributeParam, "rtAttributeParam");
			rtSkillArea.pivot = new Vector2(0.5f, 1);
			rtSkillArea.anchorMin = new Vector2(0, 0);
			rtSkillArea.anchorMax = new Vector2(1, 1);
			rtSkillArea.offsetMin = new Vector2(10, 2.799973f);
			rtSkillArea.offsetMax = new Vector2(-10, -211.26f);
			rtSkillArea.sizeDelta = new Vector2(-20, -214.06f);

			//CheckRectTransform(m_rtSelf, "m_rtSelf");
			scrollRect.vertical = true;
			scrollRect.horizontal = false;
			//CheckRectTransform(rtScrollRect, "rtScrollRect");
			rtScrollRect.anchorMin = new Vector2(1, 0);
			rtScrollRect.anchorMax = new Vector2(1, 1);
			rtScrollRect.offsetMin = new Vector2(-150, 0);
			rtScrollRect.offsetMax = new Vector2(0, 0);
			rtScrollRect.sizeDelta = new Vector2(150, 0);

			//CheckRectTransform(rtContents, "rtContents");
			rtContents.anchorMin = new Vector2(0, 1);
			rtContents.anchorMax = new Vector2(1, 1);
			rtContents.offsetMin = new Vector2(16.5f, -750.0633f);
			rtContents.offsetMax = new Vector2(-16.5f, -0.0632991f);
			rtContents.pivot = new Vector2(0.5f, 1);
			rtContents.sizeDelta = new Vector2(-33, 750);

			gridLayoutGroup.spacing = new Vector2(0.0f, 30.0f);
			gridLayoutGroup.childAlignment = TextAnchor.UpperCenter;
			gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			gridLayoutGroup.constraintCount = 1;

		}
		else
		{
			// 縦
			rtNameBar.pivot = new Vector2(0.5f, 1);
			rtNameBar.anchorMin = new Vector2(0, 1);
			rtNameBar.anchorMax = new Vector2(1, 1);
			rtNameBar.offsetMin = new Vector2(0, -75);
			rtNameBar.offsetMax = new Vector2(0, 0);
			rtNameBar.sizeDelta = new Vector2(0, 75);

			gridLayoutGroupMainStatus.cellSize = new Vector2(165.0f, 50.0f);
			gridLayoutGroupMainStatus.spacing = new Vector2(5.0f, 5.0f);
			//CheckRectTransform(rtBasicParam, "rtBasicParam");
			rtBasicParam.pivot = new Vector2(0.5f, 1);
			rtBasicParam.anchorMin = new Vector2(0, 1);
			rtBasicParam.anchorMax = new Vector2(1, 1);
			rtBasicParam.offsetMin = new Vector2(10, -198.5f);
			rtBasicParam.offsetMax = new Vector2(-10, -81.5f);
			rtBasicParam.sizeDelta = new Vector2(-20, 117);

			//CheckRectTransform(rtAttributeParam, "rtAttributeParam");
			rtAttributeParam.pivot = new Vector2(0.5f, 1);
			rtAttributeParam.anchorMin = new Vector2(0, 1);
			rtAttributeParam.anchorMax = new Vector2(1, 1);
			rtAttributeParam.offsetMin = new Vector2(9.999939f, -269.46f);
			rtAttributeParam.offsetMax = new Vector2(-10.00006f, -202.3f);
			rtAttributeParam.sizeDelta = new Vector2(-20, 67.16f);

			//CheckRectTransform(rtSkillArea, "rtSkillArea");
			rtSkillArea.pivot = new Vector2(0.5f, 1);
			rtSkillArea.anchorMin = new Vector2(0, 0);
			rtSkillArea.anchorMax = new Vector2(1, 1);
			rtSkillArea.offsetMin = new Vector2(10, 2.799896f);
			rtSkillArea.offsetMax = new Vector2(-10, -268.8f);
			rtSkillArea.sizeDelta = new Vector2(-20, -271.5999f);

			//CheckRectTransform(rtScrollRect, "rtScrollRect");
			rtScrollRect.anchorMin = new Vector2(0, 0);
			rtScrollRect.anchorMax = new Vector2(1, 0);
			rtScrollRect.offsetMin = new Vector2(0, 0);
			rtScrollRect.offsetMax = new Vector2(0, 150);
			rtScrollRect.pivot = new Vector2(1, 0);
			rtScrollRect.sizeDelta = new Vector2(0, 150);
			scrollRect.vertical = false;
			scrollRect.horizontal = true;

			//CheckRectTransform(rtContents, "rtContents");
			rtContents.anchorMin = new Vector2(0, 0);
			rtContents.anchorMax = new Vector2(0, 1);
			rtContents.offsetMin = new Vector2(0, 0);
			rtContents.offsetMax = new Vector2(0, 0);
			rtContents.pivot = new Vector2(0, 0.5f);
			rtContents.sizeDelta = new Vector2(0, 0);

			//CheckRectTransform(rtStatusArea, "rtStatusArea");
			rtStatusArea.pivot = new Vector2(1, 0.5f);
			rtStatusArea.anchorMin = new Vector2(1, 0);
			rtStatusArea.anchorMax = new Vector2(1, 1);
			rtStatusArea.offsetMin = new Vector2(-365.4f, 150);
			rtStatusArea.offsetMax = new Vector2(0, -75);
			rtStatusArea.sizeDelta = new Vector2(365.4f, -225);

			//CheckRectTransform(rtImageArea, "rtImageArea");
			rtImageArea.pivot = new Vector2(0, 0.5f);
			rtImageArea.anchorMin = new Vector2(0, 0);
			rtImageArea.anchorMax = new Vector2(0, 1);
			rtImageArea.offsetMin = new Vector2(0, 150);
			rtImageArea.offsetMax = new Vector2(150, -75);
			rtImageArea.sizeDelta = new Vector2(150, -225);

			gridLayoutGroup.spacing = new Vector2(30.0f, 0.0f);
			gridLayoutGroup.childAlignment = TextAnchor.MiddleLeft;
			gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
			gridLayoutGroup.constraintCount = 1;			
		}
		foreach (IconBasicParam icon in iconBasicParamList)
		{
			icon.SetOrientation(_orientaiton);
		}

	}

}
