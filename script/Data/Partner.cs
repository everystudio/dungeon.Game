using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerParam : CsvDataParam
{
	public int partner_id { get; set; }
	public int status { get; set; }

	public int level { get; set; }

}
public class PartnerMasterParam : CsvDataParam
{
	public int partner_id { get; set; }
	public int rarity { get; set; }

	public string name { get; set; }
	public string attribute { get; set; }
	public string type { get; set; }

	public int hp { get; set; }
	public int hp_max { get; set; }
	public int attack { get; set; }
	public int attack_max { get; set; }
	public int defence { get; set; }
	public int defence_max { get; set; }
	public int mp { get; set; }
	public int mp_max { get; set; }
	public int fire { get; set; }
	public int fire_max { get; set; }
	public int water { get; set; }
	public int  water_max { get; set; }
	public int tree { get; set; }
	public int tree_max { get; set; }
	public int dark { get; set; }
	public int dark_max { get; set; }
	public int light { get; set; }
	public int light_max { get; set; }
	public string growtype { get; set; }
	public string personality { get; set; }
	public string detail { get; set; }

}

public class Partner : CsvData<PartnerParam>
{
	public PartnerParam Get(int _iPartnerId)
	{
		PartnerParam ret = null;

		foreach( PartnerParam param in list)
		{
			if( param.partner_id == _iPartnerId)
			{
				ret = param;
				break;
			}
		}
		return ret;
	}

}

public class PartnerMaster: CsvData<PartnerMasterParam>
{
	static public string GetIconFilename(int _PartnerId)
	{
		return string.Format("Texture/partner/partner{0:D3}_icon{1:D2}.png", _PartnerId,0);
	}
	static public string GetImageFilename(int _PartnerId , int _iIndex = 0)
	{
		return string.Format("Texture/partner/partner{0:D3}_{1:D2}.png", _PartnerId,_iIndex);
	}

}



