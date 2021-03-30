using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel {
	three = 3, four, five, six, seven, eight
}

public class GameManager : MonoBehaviour {

	public static GameManager init;
	private void Awake() {
		if (init == null) {
			init = this;
		}
		else if (init != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

	private void Start() {
		SpwanObject(GameLevel.four);
	}

	public void GameStart(GameLevel level) {
		SpwanObject(level);
	}

	private void SpwanObject(GameLevel level) {
		TileManager.init.SpawnTile(level);
	}
}