using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {
	private static readonly string TAG = "TileManager";
	public static TileManager init;

	public GameObject tileParent;
	public GameObject tileThree;
	public GameObject tileFour;
	public GameObject tileFive;
	public GameObject tileSix;
	public GameObject tileSeven;
	public GameObject tileEight;

	public SpriteRenderer background;

	public Sprite[] backgroundImages;
	public Sprite[] tileSprites0;
	public Sprite[] tileSprites1;
	public Sprite[] tileSprites2;
	public Sprite[] tileSprites3;
	public Sprite[] tileSprites4;
	public Sprite[] tileSprites5;

	private GameObject tile;
	private ArrayList tileSprites;

	private int tileCount;

	private int _themaIndex;
	public int themaIndex {
		get {
			if (_themaIndex > 5)
				_themaIndex = 0;
			return _themaIndex;
		}
		set {
			if (_themaIndex > 5)
				_themaIndex = 0;
			else
				_themaIndex = value;
		}
	}

	private void Awake() {
		if (init == null) {
			init = this;
		} else if (init != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);

		AddTileSprites();
	}

	private void AddTileSprites() {
		tileSprites = new ArrayList();
		tileSprites.Add(tileSprites0);
		tileSprites.Add(tileSprites1);
		tileSprites.Add(tileSprites2);
		tileSprites.Add(tileSprites3);
		tileSprites.Add(tileSprites4);
		tileSprites.Add(tileSprites5);
	}

    private void Start() {
        
    }

    public void SpawnTileGround(GameLevel level) {
		int levelNum = (int)level;
		try {
			tile = SetTile(level);
		} catch (NullReferenceException e) {
			Debug.LogError(e.Message);
			return;
		}

		GameSystem.init.ClearTileMap();
		ClearTiles();

		for (int i = 0; i < levelNum * levelNum; ++i) {
			SpwanTile(tileCount++.ToString());
		}

		GridLayoutGroup gridLayout;
		if (null == tileParent.GetComponent<GridLayoutGroup>()) {
			tileParent.AddComponent<GridLayoutGroup>();
		}
		gridLayout = tileParent.GetComponent<GridLayoutGroup>();

		float tileWidth = tile.GetComponent<Tile>().width;

		gridLayout.constraintCount = levelNum;
		gridLayout.cellSize = new Vector2(tileWidth, tileWidth);
	}

	private GameObject SetTile(GameLevel level) {

		switch (level) {
			case GameLevel.three:
				return tileThree;
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
		foreach (Transform tile in tileParent.GetComponentsInChildren<Transform>()) {
			if (tile.name == tileParent.name) continue;
			Destroy(tile.gameObject);
		}
	}

	public void StartLevel(int num) {
		SpawnTileGround((GameLevel)num);
	}

	public void SpwanTile(string name, Transform tr = null) {
		GameObject temp;
		if (tr is null) {
			temp = Instantiate(tile);
			temp.transform.SetParent(tileParent.transform);
		} else {
			temp = Instantiate(tile, tr.position, Quaternion.identity);
			temp.name = tr.name;
			temp.transform.SetParent(tr.parent);
			temp.transform.SetSiblingIndex(int.Parse(temp.name));
			tr.SetParent(null);

			StartCoroutine(nameof(IsGameOver));
		}

		temp.name = name;
	}

	private IEnumerator IsGameOver() {
		yield return null;

		bool isGameOver = true;

		Tile[] tiles = tileParent.GetComponentsInChildren<Tile>();

		for (int i = 0; i < tiles.Length - 1; ++i) {

			int levelNum = (int)tiles[i].gameLevel;
			int secondNum = int.Parse(tiles[i + 1].name);

			if (secondNum % levelNum != 0
				&& tiles[i].tileNumberText.text.Equals(tiles[i + 1].tileNumberText.text)) {
				isGameOver = false;
				break;
			}

			if (i < levelNum * (levelNum - 1)
				&& tiles[i].tileNumberText.text.Equals(tiles[i + levelNum].tileNumberText.text)) {
				isGameOver = false;
				break;
			}
		}
		if (isGameOver)
			Debug.Log("GameOver");
	}

	public void ChangeThema() {
		++themaIndex;
		background.sprite = backgroundImages[themaIndex];
    }

	public Sprite[] GetTileThema() {
		Sprite[] temp = (Sprite[])tileSprites[themaIndex];
		return temp;
    }
}