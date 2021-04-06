using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataInfo {
	[System.Serializable]
	public class GameData {
		public ScoreData threeTileData = new ScoreData();
		public ScoreData fourTileData = new ScoreData();
		public ScoreData fiveTileData = new ScoreData();
		public ScoreData sixTileData = new ScoreData();
		public ScoreData sevenTileData = new ScoreData();
		public ScoreData eightTileData = new ScoreData();
	}
}
