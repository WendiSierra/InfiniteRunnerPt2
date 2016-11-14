using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public bool grounded;
	public LayerMask isGround;

	private Rigidbody2D rb2d;
	private Collider2D circle2d;
	private Animator anim;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		circle2d = GetComponent<CircleCollider2D> ();
		anim = GetComponent<Animator> ();

	}

	void Update () {
		rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);

		grounded = Physics2D.IsTouchingLayers (circle2d, isGround);
		
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			if (grounded == true) {

				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpForce);
			}
		}

		anim.SetFloat ("Speed", rb2d.velocity.x);
		anim.SetBool ("Grounded", grounded);
	}
}
