using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class IconBattleCard : MonoBehaviour {

	[SerializeField]
	private Text m_txtPower;

	[SerializeField]
	private Text m_txtSpeed;

	[SerializeField]
	private Image m_imgIcon;
	[SerializeField]
	private Image m_imgFrame;

	[SerializeField]
	private bool m_bIsField;

	public void Initialize(CardParam _param , bool _bIsField)
	{
		m_bIsField = _bIsField;
		Initialize(_param);
	}
	public void Initialize(CardParam _param)
	{
		m_txtPower.text = string.Format("{0}", _param.power);
		m_txtSpeed.text = string.Format("{0}", _param.speed);

		CardInfoParam infoParam = DataManager.Instance.GetCardInfoParam(_param.card_type);

		m_imgIcon.sprite = SpriteManager.Instance.LoadSprite(infoParam.filename);

		if( m_bIsField)
		{
			gameObject.GetComponent<Button>().onClick.AddListener(OnClickField);

		}
		else
		{
			gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
		}
	}

	private void OnClickField()
	{
		FloorRoute.Instance.MoveStart(3);
	}
	private void OnClick()
	{

	}


}
