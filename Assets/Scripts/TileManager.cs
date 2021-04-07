using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {
	private static readonly string TAG = "TileManager";
	public static TileManager init;

	public Animator gameOverPanel;
	public Animator gameOverText;
	public TextMeshProUGUI currScoreTMPro;
	public TextMeshProUGUI bestScoreTMPro;

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
	private ScoreData tileData;
	private GameLevel gameLevel;

	private int backScore;

	public int currScore {
		get { return tileData.currScore; }
		set {
			if (value < 0) value = 0;
			tileData.currScore = value;
			currScoreTMPro.text = value.ToString();
		}
	}

	public int bestScore {
		get { return tileData.bestScore; }
		set {
			if (value < 0) value = 0;

			tileData.bestScore = value;
			bestScoreTMPro.text = value.ToString();
		}
	}

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
		tileData = new ScoreData();
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

	public void ReStart() {
		currScore = 0;
		tileData.tileData.Clear();
		SpawnTileGround(gameLevel);
    }

    public void SpawnTileGround(GameLevel level) {
		gameLevel = level;
		try {
			tile = SetTile();
		} catch (NullReferenceException e) {
			Debug.LogError(e.Message);
			return;
		}

		GameSystem.init.ClearTileMap();
		ClearTiles();

		if (tileData.tileData.Count > 0) {
			for (int i = 0; i < (int)gameLevel * (int)gameLevel; ++i) {
				SpwanTile(tileCount++.ToString(), null, (int)tileData.tileData[i]);
			}
		} else {
			for (int i = 0; i < (int)gameLevel * (int)gameLevel; ++i) {
				SpwanTile(tileCount++.ToString());
			}
		}

		GridLayoutGroup gridLayout;
		if (null == tileParent.GetComponent<GridLayoutGroup>()) {
			tileParent.AddComponent<GridLayoutGroup>();
		}
		gridLayout = tileParent.GetComponent<GridLayoutGroup>();

		float tileWidth = tile.GetComponent<Tile>().width;

		gridLayout.constraintCount = (int)gameLevel;
		gridLayout.cellSize = new Vector2(tileWidth, tileWidth);
	}

	private GameObject SetTile() {
		GameObject tileTemp;

		switch (gameLevel) {
			case GameLevel.three:
				tileData = DataManager.init.gameData.threeTileData;
				tileTemp = tileThree;
				break;
			case GameLevel.four:
				tileData = DataManager.init.gameData.fourTileData;
				tileTemp = tileFour;
				break;
			case GameLevel.five:
				tileData = DataManager.init.gameData.fiveTileData;
				tileTemp = tileFive;
				break;
			case GameLevel.six:
				tileData = DataManager.init.gameData.sixTileData;
				tileTemp = tileSix;
				break;
			case GameLevel.seven:
				tileData = DataManager.init.gameData.sevenTileData;
				tileTemp = tileSeven;
				break;
			case GameLevel.eight:
				tileData = DataManager.init.gameData.eightTileData;
				tileTemp = tileEight;
				break;
			default:
				throw new NullReferenceException($"{TAG} :: SetTile() error");
		}

		currScore = tileData.currScore;
		bestScore = tileData.bestScore;

		return tileTemp;
	}

	private void ClearTiles() {
		tileCount = 0;
		foreach (Transform tile in tileParent.GetComponentsInChildren<Transform>()) {
			if (tile.name == tileParent.name) continue;
			Destroy(tile.gameObject);
		}
	}

	public void SpwanTile(string name, Transform tr = null, int tileText = 0) {
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

		if(tileText == 0) {
			tileText = UnityEngine.Random.Range(0, 3) == 2 ? 4 : 2;
        }

		temp.GetComponent<Tile>().tileNumberText.text = tileText.ToString();
		temp.GetComponent<Tile>().ChangeTileImage(tileText);
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
		if (isGameOver) {
			gameOverPanel.Play("FadeInPanel");
			gameOverText.SetBool("FadeIn", true);
			Debug.Log("GameOver");
		}
	}

	public void ChangeThema() {
		++themaIndex;
		background.sprite = backgroundImages[themaIndex];
    }

	public Sprite[] GetTileThema() {
		Sprite[] temp = (Sprite[])tileSprites[themaIndex];
		return temp;
    }

	public void SetTileData() {
		tileData.tileData.Clear();
		foreach(Tile tile in tileParent.GetComponentsInChildren<Tile>()) {
			tileData.tileData.Add(int.Parse(tile.tileNumberText.text));
        }

        switch (gameLevel) {
			case GameLevel.three:
				DataManager.init.gameData.threeTileData = tileData;
				break;
			case GameLevel.four:
				DataManager.init.gameData.fourTileData = tileData;
				break;
			case GameLevel.five:
				DataManager.init.gameData.fiveTileData = tileData;
				break;
			case GameLevel.six:
				DataManager.init.gameData.sixTileData = tileData;
				break;
			case GameLevel.seven:
				DataManager.init.gameData.sevenTileData = tileData;
				break;
			case GameLevel.eight:
				DataManager.init.gameData.eightTileData = tileData;
				break;
			default:
				throw new NullReferenceException($"{TAG} :: SetTile() error");
		}
    }

	public void SetScore(int score) {
		backScore = score;

		currScore += score;
		if (currScore > bestScore)
			bestScore = currScore;
	}

	public void GoBack() {
		SpawnTileGround(gameLevel);
		if(currScore == bestScore) {
			bestScore -= backScore;
        }
		currScore -= backScore;

		backScore = 0;
	}

	public void GoHome() {
		SetTileData();
		backScore = 0;
	}
}