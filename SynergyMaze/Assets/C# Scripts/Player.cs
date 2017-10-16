using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    
    private Rigidbody2D myRigidbody;
	private Animator myAnimator; // use to change the animation

    [SerializeField]
    private float movementSpeed; // use to control player movement speed

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxis("Horizontal"); //x axis
        float ver = Input.GetAxis("Vertical"); //y axis

        // TODO
        // Change the animiation of the player object to match
        // the direction is moving towards.

        if (myRigidbody.velocity.x < -0.01 && myRigidbody.velocity.y == 0) {
            myAnimator.SetInteger("state", 4);
		}
        else if (myRigidbody.velocity.x > 0.01 && myRigidbody.velocity.y == 0) {
            myAnimator.SetInteger("state", 2);
        }
        else if (myRigidbody.velocity.y > 0.01 && myRigidbody.velocity.x == 0) {
            myAnimator.SetInteger("state", 1);
        }
        else if (myRigidbody.velocity.y < -0.01 && myRigidbody.velocity.x == 0) {
            myAnimator.SetInteger("state", 3);
        }
        else {
            myAnimator.SetInteger("state", 0);
        }
        
        HandleMovement(hor, ver);
    }

    private void HandleMovement(float horizontal, float vertical) {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }
}
