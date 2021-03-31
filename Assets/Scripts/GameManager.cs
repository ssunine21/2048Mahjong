using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel {
	three = 3, four, five, six, seven, eight
}

public class GameManager : MonoBehaviour {

	public GameObject homeUI;
	public GameObject gameUI;

	private MenuSelect menuSelect;

	public static GameManager init;
	private void Awake() {
		if (init == null) {
			init = this;
		}
		else if (init != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);

		menuSelect = FindObjectOfType<MenuSelect>();
	}

	public void GameStart() {
		homeUI.SetActive(false);
		gameUI.SetActive(true);
		TileManager.init.SpawnTile((GameLevel)(menuSelect.currSelectedNum + 3));
	}

	public void GoHome() {
		homeUI.SetActive(true);
		gameUI.SetActive(false);
	}

	public void ReStart() {
		TileManager.init.SpawnTile((GameLevel)(menuSelect.currSelectedNum + 3));
	}
}