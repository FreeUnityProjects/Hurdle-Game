using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playrb;
    private Animator playanimate;
    public float jumpforce = 10.0f;
    public bool isOnGround = true;
    public bool isGameOver = false;
    public float GravityModifier = 1.0f;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpsound;
    public AudioClip crashsound;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playrb = GetComponent<Rigidbody>();
        playanimate = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround==true && isGameOver==false)
        {
            playrb.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
            isOnGround = false;
            playanimate.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioPlayer.PlayOneShot(jumpsound,1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
      

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playanimate.SetBool("Death_b", true);
            playanimate.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over!!!");
            explosionParticle.Play();
            dirtParticle.Stop();
            audioPlayer.PlayOneShot(crashsound, 2.0f);
        }
    }
}
