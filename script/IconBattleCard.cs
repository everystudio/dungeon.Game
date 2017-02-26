using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class IconBattleCard : MonoBehaviourEx {

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

	public GameObject goTarget;
	
	private float m_fAppearDelay;
	public void ResetPosition( float _fDelay, GameObject _posReset )
	{
		m_fAppearDelay = _fDelay;
		Invoke("_appear", _fDelay+0.1f );
	}
	private void _appear()
	{
		float fAppearTime = 0.3f;
		iTween.MoveTo(gameObject,
			iTween.Hash(
				"time", fAppearTime,
				"oncomplete", "endResetPosition",
				"x", goTarget.transform.position.x,
				"y", goTarget.transform.position.y,
				"z", goTarget.transform.position.z
				));

		iTween.ScaleTo(gameObject,
			iTween.Hash(
				"time", fAppearTime,
				"x", 1.0f,
				"y", 1.0f,
				"z", 1.0f
				));
	}

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

	public class EventIconBattleCard : UnityEvent<IconBattleCard>
	{
	}
	public EventIconBattleCard OnClickEvent = new EventIconBattleCard();

	private void OnClick()
	{
		OnClickEvent.Invoke(this);
	}


	public void ActionBattleUse()
	{
		float actTime = 0.5f;
		iTween.MoveAdd(gameObject,
			iTween.Hash(
				"time", actTime,
				"islocal", true,
				"y", 30,
				"oncomplete", "actEnd",
				"oncompletetarget", gameObject
			)
		);

		iTween.ValueTo(gameObject,
			iTween.Hash(
				"time", actTime,
				"onupdate" , "SetAlphaAll",
				"from",1.0f,
				"to",0.0f));
	}
	public EventIconBattleCard OnActionBattleUsed = new EventIconBattleCard();
	private void actEnd()
	{
		OnActionBattleUsed.Invoke(this);
	}
	public EventIconBattleCard OnEndResetPosition = new EventIconBattleCard();
	private void endResetPosition()
	{
		OnEndResetPosition.Invoke(this);
	}

	/*
	public void SetAlpha(float _fAlpha)
	{
		SetAlphaAll(gameObject, _fAlpha);
	}
	*/

}
