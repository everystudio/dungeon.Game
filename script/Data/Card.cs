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

	public enum STATUS
	{
		READY		= 0,
		FIELD		,
		FIELD_USED	,
		USED		,
		MAXQ		,

	}

	public List<CardParam> ChoiceStatus( STATUS _eStatus , int _iNum)
	{
		List<CardParam> ret = new List<CardParam>();
		//_icon.param.status = (int)Card.STATUS.USED;
		int[] card_prob = new int[list.Count];

		int iRestNum = 0;
		for (int i = 0; i < card_prob.Length; i++)
		{
			int probParam = 0;
			if( list[i].status == (int)_eStatus)
			{
				probParam = 100;
				iRestNum += 1;
			}
			card_prob[i] = probParam;
		}

		int iLimit = Mathf.Min(_iNum, iRestNum);
		for( int i = 0;i < iLimit; i++)
		{
			int index = UtilRand.GetIndex(card_prob);
			ret.Add(list[index]);
			card_prob[index] = 0;
		}
		return ret;
	}

	// 関数名がよくわからん気がするけど
	public void Shuffle()
	{
		foreach( CardParam param in list)
		{
			if( param.status != (int)STATUS.FIELD)
			{
				param.status = (int)STATUS.READY;
			}
		}
	}

	public void AllClear(STATUS _eStatus)
	{
		foreach (CardParam param in list)
		{
			param.status = (int)_eStatus;
		}
		return;
	}

	}
