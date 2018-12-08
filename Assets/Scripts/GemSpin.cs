using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpin : MonoBehaviour {

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        transform.Rotate(new Vector3(0, 135, 0) * Time.deltaTime);
	}

    public void PlaySound()
    {
        audioSource.Play();
    }
}