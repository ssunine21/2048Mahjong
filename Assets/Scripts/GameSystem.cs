using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public static GameSystem init;

	private TileMap tileMap;

	private void Awake() {
		if (init == null) {
			init = this;
		}
		else if (init != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);

		tileMap = new TileMap();
	}

	private void Update() {
		if (Input.GetMouseButtonUp(0)) {
			CastRay();
		}
	}

	private void CastRay() {
		Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

		if (!GameManager.init.isGameOver) {
			try {
				if (!(hit.collider is null)) {
					if (tileMap.first is null) {
						tileMap.first = hit.transform.GetComponent<Tile>();
						tileMap.first.Selection();
					} else {
						tileMap.second = hit.transform.GetComponent<Tile>();
						IsNearby();
					}

					Debug.Log(hit.collider.name);
				}
			} catch (NullReferenceException e) {
				Debug.Log(e.StackTrace);
			}
		}
	}

	private void IsNearby() {
		int levelNum = (int)tileMap.first.gameLevel;
		int firstNum = int.Parse(tileMap.first.name);
		int secondNum = int.Parse(tileMap.second.name);
		int nextTileText = int.Parse(tileMap.second.tileNumberText.text) * 2;

		if (firstNum == secondNum) {
			tileMap.Clear();
			return;
		}

		if(Mathf.Abs(firstNum - secondNum) == 1) {
			int largeNum = firstNum > secondNum ? firstNum : secondNum;
			if (largeNum % levelNum == 0)
				tileMap.SecondToFirst();
		}

		if ((Mathf.Abs(firstNum - secondNum) == 1 || Mathf.Abs(firstNum - secondNum) == levelNum)
			&& tileMap.first.tileNumberText.text.Equals(tileMap.second.tileNumberText.text)) {

			TileManager.init.SetScore(nextTileText);
			TileManager.init.SetTileData();
			tileMap.Merge();

			if (nextTileText == 2048) CloudOnce.Achievements.Tile2048.Unlock();
			if (nextTileText == 4096) CloudOnce.Achievements.Tile4096.Unlock();
			if (nextTileText == 8192) CloudOnce.Achievements.Tile8192.Unlock();
			if (nextTileText == 16384) CloudOnce.Achievements.Tile16384.Unlock();
			if (nextTileText == 32768) CloudOnce.Achievements.Tile32768.Unlock();
			if (nextTileText == 65536) CloudOnce.Achievements.Tile65536.Unlock();
			if (nextTileText == 131072) CloudOnce.Achievements.Tile131072.Unlock();

		} else {
			tileMap.SecondToFirst();
		}
	}

	public void ClearTileMap() {
		tileMap.Clear();
	}
}