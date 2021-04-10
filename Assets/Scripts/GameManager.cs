using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameLevel {
	three = 3, four, five, six, seven, eight
}

public class GameManager : MonoBehaviour {

	public GameObject homeUI;
	public GameObject gameUI;
	public GameObject howToUI;
	public GameObject UIPanel;

	public bool isGameOver;

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

	private void Update() {
		
		#if UNITY_ANDROID 
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (howToUI.activeSelf) {
				CloseHowToUI();
			} else if (gameUI.activeSelf) {
				GoHome();
			} else {
				Application.Quit();
			}
		} 
		#endif
	}

	public void GameStart() {
		homeUI.SetActive(false);
		gameUI.SetActive(true);
		TileManager.init.SpawnTileGround((GameLevel)(menuSelect.currSelectedNum + 3));
	}

	public void GoHome() {
		TileManager.init.GoHome();
		homeUI.SetActive(true);
		gameUI.SetActive(false);
		isGameOver = false;

		AdsManager.init.ShowInterstitialAd();
	}

	public void GoBack() {
		if (!isGameOver)
			TileManager.init.GoBack();
	}

	public void ReStart() {
		TileManager.init.ReStart();
		isGameOver = false;

		AdsManager.init.ShowInterstitialAd();
	}

	private void OnApplicationQuit() {
		DataManager.init.Save();
	}

	private void OnApplicationPause(bool pause) {
		if (pause) {
			DataManager.init.Save();
		}
	}

	public void OpenHowToUI() {
		howToUI.SetActive(true);
		UIPanel.SetActive(false);
	}

	public void CloseHowToUI() {
		howToUI.SetActive(false);
		UIPanel.SetActive(true);
	}
}