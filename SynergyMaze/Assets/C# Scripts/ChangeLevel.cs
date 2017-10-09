using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other){
        Debug.Log("im at least inside");
        if(other.gameObject.name == "Player")
        {
            Debug.Log("its colliding! ");
            SceneManager.LoadScene("Level_Two");
        }

    }
}