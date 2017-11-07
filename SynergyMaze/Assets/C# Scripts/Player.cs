using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private Rigidbody2D myRigidbody;
    private Animator myAnimator; // use to change the animation
    public string url;
    public float hor;
    public float ver;
    float lastMoveTime;
    string movements;
    [SerializeField]
    private float movementSpeed; // use to control player movement speed

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        url = @"file:///C:\Users\DLuna\Downloads\furry-spork-masterWithController\SynergyMaze\Assets\Input\input.txt";
    }

    // Update is called once per frame
    void Update()
    {
        //float hor = Input.GetAxis("Horizontal"); //x axis
        //float ver = Input.GetAxis("Vertical"); //y axis

        if (movements == null || movements.Length <= 120)
        {
            StartCoroutine(getNextMovements());

        }

        if (movements == null || movements.Length == 0)
        {
            ver = 0;
            hor = 0;
        }
        else
        {
            int nextMove = int.Parse(movements.Substring(0, 1));
            movements = movements.Substring(1);
            switch (nextMove)
            {
                case 0:
                    ver = 1;
                    hor = 0;
                    break;
                case 1:
                    ver = 0;
                    hor = 1;
                    break;
                case 2:
                    ver = -1;
                    hor = 0;
                    break;
                case 3:
                    ver = 0;
                    hor = -1;
                    break;
            }
        }



        // TODO
        // Change the animiation of the player object to match
        // the direction is moving towards.

        if (myRigidbody.velocity.x < -0.0001 && myRigidbody.velocity.y == 0)
        {
            myAnimator.SetInteger("state", 4);
        }
        else if (myRigidbody.velocity.x > 0.0001 && myRigidbody.velocity.y == 0)
        {
            myAnimator.SetInteger("state", 2);
        }
        else if (myRigidbody.velocity.y > 0.0001 && myRigidbody.velocity.x == 0)
        {
            myAnimator.SetInteger("state", 1);
        }
        else if (myRigidbody.velocity.y < -0.0001 && myRigidbody.velocity.x == 0)
        {
            myAnimator.SetInteger("state", 3);
        }
        else
        {
            myAnimator.SetInteger("state", 0);
            HandleMovement(0, 0);

        }
        HandleMovement(hor, ver);
    }

    private void HandleMovement(float horizontal, float vertical)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
    private IEnumerator getNextMovements()
    {
        WWW www = new WWW(url);
        yield return www;
        movements = www.text;
    }
}
