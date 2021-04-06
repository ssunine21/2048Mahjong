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
        // 1000점을 등록
        Social.ReportScore(1000, GPGSIds.leaderboard_3_x_3_score, (bool bSuccess) => {
            if (bSuccess) {
                Debug.Log("ReportLeaderBoard Success");
            } else {
                Debug.Log("ReportLeaderBoard Fall");
            }
        }
        );
        Social.ShowLeaderboardUI();
    }

    // 업적보기
    public void OnShowAchievement() {
        Social.ShowAchievementsUI();
    }

    // 업적추가
    //public void OnAddAchievement() {

    //    Social.ReportProgress(GPGSIds.achievement_achievements1, 100.0f, (bool bSuccess) => {
    //        if (bSuccess) {
    //            Debug.Log("AddAchievement Success");
    //            text.text = "AddAchievement Success";
    //        } else {
    //            Debug.Log("AddAchievement Fall");
    //            text.text = "AddAchievement Fail";
    //        }
    //    }
    //    );
    //}

}