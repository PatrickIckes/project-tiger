using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacter player;

    void Update ()
    {
        if (player.hasRing == true)
        {
            this.gameObject.SetActive(false);
        }
	}
}
