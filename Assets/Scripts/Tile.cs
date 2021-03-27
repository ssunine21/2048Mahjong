using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteOutline))]
public class Tile : MonoBehaviour {
	private readonly float MOVE_SPEED = 12f;

	public GameLevel gameLevel;
	public TextMeshProUGUI tmPro;

	public bool isMove = false;

	private Vector2 _target;
	public Vector2 target {
		get { return _target; }
		set {
			_target = value;
			isMove = true;
		}
	}

	private SpriteOutline spriteOutline;

	private void Start() {
		int Rand = Random.Range(0, 3);
		tmPro.text = Rand == 2 ? "4" : "2";
		spriteOutline = this.GetComponent<SpriteOutline>();
	}

	private void FixedUpdate() {
		Move();
	}

	private void Move() {
		if (isMove) {
			this.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 0;
			this.transform.Translate((target - (new Vector2(transform.position.x, transform.position.y)))
				* MOVE_SPEED * Time.deltaTime);

			Vector3 targetVec3 = new Vector3(target.x, target.y);
			if(transform.position == targetVec3) {
				this.gameObject.SetActive(false);
			}
		}
	}

	public void Selection() {
		spriteOutline.isOutline = true;
	}

	public void Release() {
		spriteOutline.isOutline = false;
	}
}