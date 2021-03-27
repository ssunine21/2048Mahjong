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

		if (!(hit.collider is null)) {
			if(tileMap.first is null) {
				tileMap.first = hit.transform.GetComponent<Tile>();
				tileMap.first.Selection();
			} else {
				tileMap.second = hit.transform.GetComponent<Tile>();
				IsNearby();
			}

			Debug.Log(hit.collider.name);
		}
	}

	private void IsNearby() {
		int nearNum = (int)tileMap.first.gameLevel;
		int firstNum = int.Parse(tileMap.first.name);
		int secondNum = int.Parse(tileMap.second.name);

		if(firstNum == secondNum) {
			tileMap.Clear();
			return;
		}

		if ((Mathf.Abs(firstNum - secondNum) == 1
			|| Mathf.Abs(firstNum - secondNum) == nearNum)
			&& tileMap.first.tmPro.text.Equals(tileMap.second.tmPro.text)) {
			tileMap.Merge();
		}

		tileMap.SecondToFirst();
	}
}