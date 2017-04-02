using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPartnerTop : CPanel {

	[SerializeField]
	private GameObject m_goRootIcon;

	[SerializeField]
	private List<IconPartner> partnerList = new List<IconPartner>();

	protected override void panelStart()
	{
		base.panelStart();

		DeleteObjects<IconPartner>(m_goRootIcon);

		foreach( PartnerMasterParam param in DataManager.Instance.partnerMaster.list)
		{
			IconPartner script = PrefabManager.Instance.MakeScript<IconPartner>("prefab/IconPartner", m_goRootIcon);
			PartnerParam dataParam = DataManager.Instance.partnerData.Get(param.partner_id);
			script.Initialize(param , dataParam);
			partnerList.Add(script);
		}
	}

}
