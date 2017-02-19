using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardParam : CsvDataParam
{
	public int status{ get; set; }
	public string card_type { get; set; }

	public int speed { get; set; }
	public int power { get; set; }
}

public class Card : CsvData<CardParam> {
	public enum TYPE
	{
		NONE = 0,
		ATTACK,
		DEFENCE,
		SKILL,
		CURE,
		COUNTER,

	}

}
