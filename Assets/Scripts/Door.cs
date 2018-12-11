using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    [SerializeField]
    private string sceneToLoad;

    private PlayerCharacter player;

    private bool isPlayerInTrigger;

    private void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Activate") && isPlayerInTrigger)
        {
            Debug.Log("Player activated door");
            PlayerPrefs.SetInt("Score", player.scoreCount);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}