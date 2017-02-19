using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : SpriteManagerBase<SpriteManager> {
	public override void Initialize()
	{
		base.Initialize();
		LoadAtlas("Atlas/dungeon_atlas");
	}
}
