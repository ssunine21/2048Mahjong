using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour {
	private readonly int UP = Animator.StringToHash("Up");
	private readonly int ISFADE = Animator.StringToHash("IsFadeIn");
	private readonly float MOVE_SPEED = 12f;

	public GameLevel gameLevel;
	public TextMeshProUGUI tileNumberText;
	public Image tileImage;
	public float width;

	public bool isMove = false;


	private Vector2 _target;
	public Vector2 target {
		get { return _target; }
		set {
			_target = value;
			isMove = true;
		}
	}

	private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

	private void FixedUpdate() {
		Move();
	}

	private void Move() {
		if (isMove) {
			if(!(this.GetComponent<BoxCollider2D>() is null)) {
				this.GetComponent<BoxCollider2D>().enabled = false;
			}
			this.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 0;
			this.transform.Translate((target - (new Vector2(transform.position.x, transform.position.y)))
				* MOVE_SPEED * Time.deltaTime);

			Vector3 targetVec3 = new Vector3(target.x, target.y);
			if(transform.position == targetVec3) {
				Destroy(this.gameObject);
			}
		}
	}

	public void Selection() {
		animator.SetBool(ISFADE, true);
	}

	public void Release() {
		animator.SetBool(ISFADE, false);
	}

	public void RankUp() {
		int nextNumber = (int.Parse(tileNumberText.text) * 2);
		animator.SetTrigger(UP);
		tileNumberText.text = nextNumber.ToString();

		ChangeTileImage(nextNumber);
	}

	public void ChangeTileImage(int nextNumber) {
		int numOfPower = 0;
        while (true) {
			nextNumber >>= 1;
			if (nextNumber == 0) break;

			numOfPower++;
        }

		if (numOfPower > TileManager.init.GetTileThema().Length)
			numOfPower %= numOfPower;

		tileImage.sprite = TileManager.init.GetTileThema()[numOfPower];
    }

	public void GoToSecond(Vector2 secondPos) {
		target = secondPos;
	}
}