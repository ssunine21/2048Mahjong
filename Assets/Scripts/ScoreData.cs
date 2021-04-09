using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScoreData {

    public ArrayList tileData;

    private float _currScore;
    public float currScore {
        get { return _currScore; }
        set { _currScore = value; }
    }
    private float _bestScore;
    public float bestScore {
        get { return _bestScore; }
        set { _bestScore = value; }
    }

    public ScoreData() {
        tileData = new ArrayList();
    }

    public void SetData(int curr, int best, ArrayList tileList) {
        currScore = curr;
        bestScore = best;
        tileData = tileList;
    }
}