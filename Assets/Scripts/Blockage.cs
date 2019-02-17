using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    [SerializeField]
    PlayerCharacter player;

    private void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>();
    }

    private void Update ()
    {
        CheckRing();
	}

    public void CheckRing()
    {
        if (player.hasRing == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}