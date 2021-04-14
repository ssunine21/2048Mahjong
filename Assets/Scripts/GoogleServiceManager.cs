using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class GoogleServiceManager : MonoBehaviour {

    public static GoogleServiceManager init;
    void Awake() {
        if (init != null) { DontDestroyOnLoad(this.gameObject); return; }
        init = this;
        Destroy(this.gameObject);
    }

    private void Start() {
        Cloud.Initialize(false, true);

#if UNITY_ANDROID
        OnLogin();
#endif
    }

    public void SubmitScoreToLeaderboards() {
        Leaderboards.Score3x3.SubmitScore((long)DataManager.init.gameData.threeTileData.bestScore);
        Leaderboards.Score4x4.SubmitScore((long)DataManager.init.gameData.fourTileData.bestScore);
        Leaderboards.Score5x5.SubmitScore((long)DataManager.init.gameData.fiveTileData.bestScore);
        Leaderboards.Score6x6.SubmitScore((long)DataManager.init.gameData.sixTileData.bestScore);
        Leaderboards.Score7x7.SubmitScore((long)DataManager.init.gameData.sevenTileData.bestScore);
        Leaderboards.Score8x8.SubmitScore((long)DataManager.init.gameData.eightTileData.bestScore);
    }

    public void OnLogin() {
        if (!Social.localUser.authenticated) {
            Social.localUser.Authenticate((bool bSuccess) => {});
        }
    }
}