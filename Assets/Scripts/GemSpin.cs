using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpin : MonoBehaviour {

	
	void Update ()
    {
        transform.Rotate(new Vector3(0, 135, 0) * Time.deltaTime);
	}
}
