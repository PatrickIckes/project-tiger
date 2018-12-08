using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private bool isActivated;
    private SpriteRenderer spriteRenderer;
    Animator checkpointAnim;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        checkpointAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        checkpointAnim.SetBool("Fire", false);
    }
    private void Update()
    {
        
    }
    public void SetIsActivated(bool value)
    {
        isActivated = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            Debug.Log("Checkpoint!");
            audioSource.Play();
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
            //spriteRenderer.sprite = activatedSprite;
            checkpointAnim.SetBool("Fire", true);
        }
    }
}
