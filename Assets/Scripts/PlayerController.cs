using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimation;
    public ParticleSystem explosion;
    public ParticleSystem dirt;

    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip explosionSound;

    public float jumpForce = 600;
    public float gravityForce;
    private bool estSurSol;

    private bool gameOver = false;
    private float gravityEarth = -9.81f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity = new Vector3(0, gravityEarth * gravityForce, 0);
        estSurSol = true;
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estSurSol && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimation.SetTrigger("Jump_trig");
            estSurSol = false;
            dirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            estSurSol = true;
            dirt.Play();
            if(gameOver)
            {
                dirt.Stop();
            }

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            dirt.Stop();
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            explosion.Play();
            explosion.Play();
            playerAudio.PlayOneShot(explosionSound, 1.0f);
        }
    }

    public bool GetGameOverStatut()
    {
        return gameOver;
    }

}
