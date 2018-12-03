using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered hazard!");
            //PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            //player.transform.position.Set(0, 0, 45);
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //else
        //{
        //    Debug.Log("Something other than the player entered the Hazard!");
        //}
    }
}
