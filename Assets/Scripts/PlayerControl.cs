using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    private AudioSource playerAudio;
    public AudioClip jump;
    public AudioClip crash;
    public float jumpForce;
    public float gravityModifier;
    public bool onGround = true;
    public bool gameOver = false;
    public bool doublejump=false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && onGround) 
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            onGround = false;
            dirt.Stop();
            playerAudio.PlayOneShot(jump, 2f);
            doublejump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !gameOver && !doublejump && !onGround)
        {
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            doublejump = true;
            Debug.Log("double");
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirt.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game over");
            gameOver = true;
            explosion.Play();
            dirt.Stop();
            playerAudio.PlayOneShot(crash, 2f);
        }
    }
}
