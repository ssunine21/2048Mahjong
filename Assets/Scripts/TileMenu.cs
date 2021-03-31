using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileMenu : MonoBehaviour {
    static readonly private int FADE_IN = Animator.StringToHash("FadeIn");

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void IsFadeIn(bool isFadeIn) {
        animator.SetBool(FADE_IN, isFadeIn);
    }
}