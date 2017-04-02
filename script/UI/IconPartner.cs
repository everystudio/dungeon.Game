using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class IconPartner : MonoBehaviour {

	[SerializeField]
	private Image m_imgFrame;
	[SerializeField]
	private Image m_imgIcon;

	PartnerMasterParam m_masterParam;
	PartnerParam m_dataParam;

	public void Initialize( PartnerMasterParam _master , PartnerParam _data )
	{
		m_masterParam = _master;
		m_dataParam = _data;

		if(m_dataParam != null)
		{
			//Debug.LogError(PartnerMaster.GetIconFilename(m_dataParam.partner_id));
			m_imgIcon.sprite = SpriteManager.Instance.LoadSprite(PartnerMaster.GetIconFilename(m_dataParam.partner_id));
		}
		else
		{
			m_imgIcon.color = Color.black;
		}

	}

}
