using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParam : CsvDataParam
{
	public int player_id { get; set; }
	public int status { get; set; }

	public int level { get; set; }

}
public class PlayerMasterParam : CsvDataParam
{
	public int player_id { get; set; }

	public string name { get; set; }
	public string filename { get; set; }
	public string profile { get; set; }
}

public class Player : CsvData<PlayerParam>
{


}

public class PlayerMaster: CsvData<PlayerMasterParam>
{
	static public string GetIconFilename(int _playerId)
	{
		return string.Format("texture/player/player{0:D2}_icon100x100.png", _playerId);
	}
	static public string GetImageFilename(int _playerId)
	{
		return string.Format("texture/player/player{0:D2}.png", _playerId);
	}

}



