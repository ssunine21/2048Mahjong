using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {
	private static readonly string TAG = "TileManager";

	public GameObject tileParent;
	public GameObject tileFour;
	public GameObject tileFive;
	public GameObject tileSix;
	public GameObject tileSeven;
	public GameObject tileEight;

	private List<GameObject> tiles;
	private GameObject tile;

	private int tileCount;

	public static TileManager init;

	private void Awake() {
		if (init == null) {
			init = this;
		}
		else if (init != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);

		tiles = new List<GameObject>();
	}

	public void SpawnTile(GameLevel level) {
		int levelNum = (int)level;
		try {
			tile = SetTile(level);
		} catch (NullReferenceException e) {
			Debug.LogError(e.Message);
			return;
		}

		ClearTiles();

		GridLayoutGroup gridLayout;
		if (null == tileParent.GetComponent<GridLayoutGroup>()) {
			tileParent.AddComponent<GridLayoutGroup>();
		}
		gridLayout = tileParent.GetComponent<GridLayoutGroup>();

		float tileWidth = (tile.GetComponent<SpriteRenderer>().sprite.rect.width / tile.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit);

		gridLayout.constraintCount = levelNum;
		gridLayout.cellSize = new Vector2(tileWidth, tileWidth);


		for (int i = 0; i < levelNum * levelNum; ++i) {
			SpwanTile(tileCount++.ToString());
		}
	}

	private GameObject SetTile(GameLevel level) {

		switch (level) {
			case GameLevel.four:
				return tileFour;
			case GameLevel.five:
				return tileFive;
			case GameLevel.six:
				return tileSix;
			case GameLevel.seven:
				return tileSeven;
			case GameLevel.eight:
				return tileEight;
			default:
				throw new NullReferenceException($"{TAG} :: SetTile() error");
		}
	}

	private void ClearTiles() {
		tileCount = 0;
		foreach(GameObject tile in tiles) {
			Destroy(tile);
		}

		tiles.Clear();
	}

	public void StartLevel(int num) {
		SpawnTile((GameLevel)num);
	}

	public void SpwanTile(string name, Transform tr = null) {
		GameObject temp;
		if (tr is null) {
			temp = Instantiate(tile);
			temp.transform.SetParent(tileParent.transform);
		} else {
			temp = Instantiate(tile, tr.position, Quaternion.identity);
		}

		temp.name = name;
		tiles.Add(temp);
	}
}