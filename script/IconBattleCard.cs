using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class IconBattleCard : MonoBehaviour {

	public CardParam param { get; set; }
	//private CardParam m_cardParam;
	private Button m_btn;

	[SerializeField]
	private Text m_txtPower;

	[SerializeField]
	private Text m_txtSpeed;

	[SerializeField]
	private Image m_imgIcon;
	[SerializeField]
	private Image m_imgFrame;

	[SerializeField]
	private GameObject m_goUsed;

	/*
	[SerializeField]
	private bool m_bIsField;
	*/

	public void Initialize(CardParam _param , bool _bIsField)
	{
		//m_bIsField = _bIsField;
		Initialize(_param);
	}
	public void Initialize(CardParam _param)
	{
		param = _param;
		m_txtPower.text = string.Format("{0}", _param.power);
		m_txtSpeed.text = string.Format("{0}", _param.speed);

		m_btn = gameObject.GetComponent<Button>();
		m_btn.onClick.AddListener(OnClick);
		RefreshDisp();

		CardInfoParam infoParam = DataManager.Instance.GetCardInfoParam(_param.card_type);

		m_imgIcon.sprite = SpriteManager.Instance.LoadSprite(infoParam.filename);
	}

	public void RefreshDisp()
	{
		bool bUsed = false;
		if (2 <= param.status)
		{
			bUsed = true;
		}
		m_goUsed.SetActive(bUsed);
		m_btn.interactable = !bUsed;
	}

	public class UUnityEventIconBattleCard : UnityEvent<IconBattleCard>
	{
	}
	public UUnityEventIconBattleCard OnClickEvent = new UUnityEventIconBattleCard();

	private void OnClick()
	{
		OnClickEvent.Invoke(this);
	}


}
