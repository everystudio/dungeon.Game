using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfoParam : CsvDataParam
{
	public string card_type { get; set;}
	public string title { get; set; }
	public string filename { get; set; }
	public string explain { get; set; }
}

public class CardInfo : CsvData<CardInfoParam> {
	



}
