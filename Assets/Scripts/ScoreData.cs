using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour {
    public ArrayList tileData;

    private int _currScore;
    public int currScore {
        get { return _currScore; }
        set { _currScore = value; }
    }
    private int _bestScore;
    public int bestScore {
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