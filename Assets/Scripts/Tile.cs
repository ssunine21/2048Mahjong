using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteOutline))]
public class Tile : MonoBehaviour {
	private readonly int UP = Animator.StringToHash("Up");
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
	private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

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
		spriteOutline.isOutline = true;
	}

	public void Release() {
		spriteOutline.isOutline = false;
	}

	public void RankUp() {
		animator.SetTrigger(UP);
		tmPro.text = (int.Parse(tmPro.text) * 2).ToString();
	}

	public void GoToSecond(Vector2 secondPos) {
		target = secondPos;
	}
}