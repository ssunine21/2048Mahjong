using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour {
    public RawImage mScreen = null;
    public VideoPlayer mVideoPlayer = null;

    private void OnEnable() {
        this.GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
        if (mScreen != null && mVideoPlayer != null) {
            // 비디오 준비 코루틴 호출
            StartCoroutine(PrepareVideo());
        }
    }

    private void OnDisable() {
        StopVideo();
    }

    protected IEnumerator PrepareVideo() {
        // 비디오 준비
        mVideoPlayer.Prepare();

        // 비디오가 준비되는 것을 기다림
        while (!mVideoPlayer.isPrepared) {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer의 출력 texture를 RawImage의 texture로 설정한다
        mScreen.texture = mVideoPlayer.texture;
        PlayVideo();
    }

    public void PlayVideo() {
        this.GetComponent<RawImage>().color = Color.white;
        if (mVideoPlayer != null && mVideoPlayer.isPrepared) {
            // 비디오 재생
            mVideoPlayer.Play();
        }
    }

    public void StopVideo() {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared) {
            // 비디오 멈춤
            mVideoPlayer.Stop();
        }
    }
}