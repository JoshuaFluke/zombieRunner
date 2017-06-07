using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float jumpForce = 100f;
    //drag clip in inspector
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;
    Animator anim;
    private Rigidbody rigidBody;
    private bool jump;
    //reference to audioSource
    private AudioSource audioSource;


    private void Awake()
    {
        Assert.IsNotNull(sfxDeath);
    }




    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStartedGame();
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                jump = true;

            }
        }
	}

    void FixedUpdate()
    {
        if (jump==true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0,jumpForce), ForceMode.Impulse);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "obstacle")
        {
            rigidBody.AddForce(new Vector2(-50,20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();
        }
    }
}
