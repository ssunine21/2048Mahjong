using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour {

	public static DataManager init = null;
	private void Awake() {
		if (init == null) {
			init = this;
		} else if (init != this) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);

		gameData = new DataInfo.GameData();
	}

	public DataInfo.GameData gameData;

	private string dataPath;

    private void Start() {
		dataPath = Application.persistentDataPath + "/gameData.dat";
		Load();
    }

	private void Load() {
		if (!File.Exists(dataPath)) return;

		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.OpenRead(dataPath);

		if (file.Length <= 0) return;

		gameData = (DataInfo.GameData)binaryFormatter.Deserialize(file);
		TileManager.init.SetThema(gameData.themaIndex);
	}

	public void Save() {
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create(dataPath);

		binaryFormatter.Serialize(file, gameData);
		file.Close();
	}
}