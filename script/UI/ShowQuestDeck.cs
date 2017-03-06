using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuestDeck : ButtonShowUI{

	protected override void onclick_event()
	{
		base.onclick_event();
		DataManager.Instance.show_card_list = DataManager.Instance.gameQuestDeck.list;
	}

}
