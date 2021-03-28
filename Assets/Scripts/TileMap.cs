using UnityEditor;
using UnityEngine;

public class TileMap {
	public Tile first;
	public Tile second;

	public void SecondToFirst() {
		first.Release();
		first = second;
		first.Selection();
		second = null;
	}

	public void Clear() {
		if (!(first is null))
			first.Release();

		if (!(second is null))
			second.Release();

		first = null;
		second = null;
	}

	public void Merge() {
		first.GoToSecond(second.transform.position);

		second.RankUp();
		TileManager.init.SpwanTile(first.name, first.transform);
		Clear();
	}
}