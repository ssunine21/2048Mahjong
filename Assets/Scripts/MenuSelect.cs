using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour {
    static readonly private int MENU_ANIM_NUM = Animator.StringToHash("menuNum");

    public Button prevBtn;
    public Button nextBtn;

    private TileMenu[] tileMenus;

    private int _currSelectedNum;
    public int currSelectedNum {
        get { return _currSelectedNum; }
        set {
            if (value <= 0) {
                _currSelectedNum = 0;
                ButtonEnable(prevBtn, false);
            } else if (value >= 5) {
                _currSelectedNum = 5;
                ButtonEnable(nextBtn, false);
            } else {
                _currSelectedNum = value;
                ButtonEnable(prevBtn, true);
                ButtonEnable(nextBtn, true);
            }
        }
    }

    private void Awake() {
        tileMenus = GetComponentsInChildren<TileMenu>();
    }

    private void Start() {
        prevBtn.onClick.AddListener(PrevMenu);
        nextBtn.onClick.AddListener(NextMenu);

        InitMenu();
    }

	private void OnEnable() {
        InitMenu();
	}

	private void PrevMenu() {
        MenuFadeChange(--currSelectedNum);
    }

    private void NextMenu() {
        MenuFadeChange(++currSelectedNum);
    }

    private void InitMenu() {
        currSelectedNum = currSelectedNum;
        MenuFadeChange(currSelectedNum);
    }

    private void ButtonEnable(Button button, bool isEnabled) {
        if (isEnabled) {
            button.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            button.enabled = true;
        } else {
            button.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            button.enabled = false;
        }
    }

    private void MenuFadeChange(int currNum) {
        foreach(TileMenu tile in tileMenus) {
            tile.IsFadeIn(false);
		}

        tileMenus[currNum].IsFadeIn(true);
    }
}