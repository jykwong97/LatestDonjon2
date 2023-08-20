using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private bool walking = false; // Variable to track if the player is walking

    // AudioClips
    public AudioClip walk;
    public AudioClip sprite;
    private AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<AudioSource>();

        // Check if AudioSource component is present, and add one if not found
        if (player == null)
        {
            player = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            animator.SetBool("IsRun", true);
            walking = true; // Player is walking

            // Check if the walk sound is not currently playing before playing it
            if (!player.isPlaying)
            {
                player.clip = walk;
                player.Play();
            }
        }
        else
        {
            animator.SetBool("IsRun", false);
            walking = false; // Player is not walking
            player.Stop(); // Stop the walk sound when the player stops walking
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && walking) // Check if the player is walking and Left Shift is pressed
        {
            animator.SetTrigger("Sprite"); // Trigger the "sprite" animation
            player.clip = sprite;
            player.Play(); // Play the sprite sound
        }
    }
}
