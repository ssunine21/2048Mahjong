using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GoogleServiceManager : MonoBehaviour {

    public static GoogleServiceManager init;
    void Awake() {
        if (init == null) {
            init = this;
        } else if (init != this) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }
    void Start() {
        OnLogin();
    }
    void Update() {

    }

    public void OnLogin() {
        if (!Social.localUser.authenticated) {
            Social.localUser.Authenticate((bool bSuccess) => {
                if (bSuccess) {
                    Debug.Log("Success : " + Social.localUser.userName);
                } else {
                    Debug.Log("Fall");
                }
            });
        }
    }

    public void OnLogOut() {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

    public void OnShowLeaderBoard() {
        Social.ReportScore((long)DataManager.init.gameData.threeTileData.bestScore, GPGSIds.leaderboard_3_x_3_score, (bool obj) => AddHandler(obj));
        Social.ReportScore((long)DataManager.init.gameData.fourTileData.bestScore, GPGSIds.leaderboard_4_x_4_score, (bool obj) => AddHandler(obj));
        Social.ReportScore((long)DataManager.init.gameData.fiveTileData.bestScore, GPGSIds.leaderboard_5_x_5_score, (bool obj) => AddHandler(obj));
        Social.ReportScore((long)DataManager.init.gameData.sixTileData.bestScore, GPGSIds.leaderboard_6_x_6_score, (bool obj) => AddHandler(obj));
        Social.ReportScore((long)DataManager.init.gameData.sevenTileData.bestScore, GPGSIds.leaderboard_7_x_7_score, (bool obj) => AddHandler(obj));
        Social.ReportScore((long)DataManager.init.gameData.eightTileData.bestScore, GPGSIds.leaderboard_8_x_8_score, (bool obj) => AddHandler(obj));

        Social.ShowLeaderboardUI();
    }

    // 업적보기
    public void OnShowAchievement() {
        Social.ShowAchievementsUI();
    }

    private void AddHandler(bool isSuccess) {
        if (!isSuccess) {
            Debug.LogError("add fails");
        }
    }

    // 업적추가
    public void OnAddAchievement(string achievementName) {
        Social.ReportProgress(achievementName, 100.0f, (bool obj) => AddHandler(obj));
    }
}