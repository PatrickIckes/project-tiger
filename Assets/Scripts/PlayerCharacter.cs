using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    public Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start () {
        Debug.Log("This is start!");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            //TODO: Move the character to the right
            myRigidBody.velocity = new Vector2(5, myRigidBody.velocity.y);
        }
        //This is the syntax for printing to the console!
        //Debug.Log("Test!");
        //Comment
	}
}
