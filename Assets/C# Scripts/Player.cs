using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    public Transform heroObj;
	public Animator myAnimator; // use this to change the animation
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxis("Horizontal"); //x axis
        float ver = Input.GetAxis("Vertical"); //y axis

        HandleMovement(hor, ver);

		// TODO
		// Change the animiation of the player object to match
		// the direction is moving towards.

		if (Input.GetKey (KeyCode.LeftArrow)) {
			myAnimator.SetBool ("left", true);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			myAnimator.SetBool ("right", true);
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			myAnimator.SetBool ("up", true);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			myAnimator.SetBool ("down", true);
		} else {
			myAnimator.SetBool ("down", false);
			myAnimator.SetBool ("up", false);
			myAnimator.SetBool ("right", false);
			myAnimator.SetBool ("left", false);
			myAnimator.SetBool ("idle", true);
		}
	}

    private void HandleMovement(float horizontal, float vertical) {
        // myRigidbody.velocity = Vector2.left;
        myRigidbody.velocity = new Vector2(vertical, myRigidbody.velocity.y);
        myRigidbody.velocity = new Vector2(horizontal , myRigidbody.velocity.x);
    }
}
