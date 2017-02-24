using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class IconBattleCard : MonoBehaviour {

	private CardParam m_cardParam;
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

	[SerializeField]
	private bool m_bIsField;

	public void Initialize(CardParam _param , bool _bIsField)
	{
		m_bIsField = _bIsField;
		Initialize(_param);
	}
	public void Initialize(CardParam _param)
	{
		m_cardParam = _param;
		m_txtPower.text = string.Format("{0}", _param.power);
		m_txtSpeed.text = string.Format("{0}", _param.speed);

		m_btn = gameObject.GetComponent<Button>();
		if (m_bIsField)
		{
			m_btn.onClick.AddListener(OnClickField);
		}
		else
		{
			m_btn.onClick.AddListener(OnClick);
		}

		bool bUsed = false;
		if( 2 <= _param.status)
		{
			bUsed = true;
		}
		m_goUsed.SetActive(bUsed);
		m_btn.interactable = !bUsed;

		CardInfoParam infoParam = DataManager.Instance.GetCardInfoParam(_param.card_type);

		m_imgIcon.sprite = SpriteManager.Instance.LoadSprite(infoParam.filename);

	}

	private void OnClickField()
	{
		FloorRoute.Instance.MoveStart(m_cardParam.speed);
	}
	private void OnClick()
	{

	}


}
