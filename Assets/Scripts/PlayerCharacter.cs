using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
        Debug.Log("This is start!");
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.D))
        {
            //TODO: Move the character to the right
            movementSpeed = 5;
            myRigidBody.velocity = new Vector2(movementSpeed, myRigidBody.velocity.y);
        }

        if (Input.GetKey(KeyCode.W));
        {
            //Jumping
            myRigidBody.velocity = new Vector2(movementSpeed, myRigidBody.velocity.x);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Move left
            movementSpeed = -5;
            myRigidBody.velocity = new Vector2(movementSpeed, myRigidBody.velocity.y);
        }
        //This is the syntax for printing to the console!
        //Debug.Log("Test!");
	}
}
