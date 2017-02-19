using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeck : CPanel {

	[SerializeField]
	private GameObject m_goRootIcon;
	public List<IconBattleCard> show_deck = new List<IconBattleCard>();

	protected override void panelStart()
	{
		IconBattleCard[] scriptArr = m_goRootIcon.GetComponentsInChildren<IconBattleCard>();
		foreach(IconBattleCard script in scriptArr)
		{
			Destroy(script.gameObject);
		}

		base.panelStart();

		foreach( CardParam param in DataManager.Instance.show_card_list)
		{
			IconBattleCard script = PrefabManager.Instance.MakeScript<IconBattleCard>("Prefab/BattleCardIcon", m_goRootIcon);
			script.Initialize(param);
			//Debug.LogError(script.gameObject.transform.localScale);
			script.gameObject.transform.localScale = Vector3.one;
		}

	}

}
