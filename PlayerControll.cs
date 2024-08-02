using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerControll : MonoBehaviour
{
    private Rigidbody PlayerRB;
    public int upspeed=100;
    public float gravitymodifier=4;
    public bool isOnGround=true;
    public bool GameOver=false;
    private Animator playeranim;
    public ParticleSystem explosionParticle;
    public ParticleSystem runparticle;
    public AudioClip jumpsound;
    public AudioClip crashsound;
    private AudioSource playeraudio;
    public TextMeshProUGUI Instrtext;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB=GetComponent<Rigidbody>();
       
        Physics.gravity *=gravitymodifier;
        playeranim=GetComponent<Animator>();
        playeraudio=GetComponent<AudioSource>();
        isOnGround=true;
        GameOver=false;
        
         if(!Input.GetKeyDown(KeyCode.Space)){
             Instrtext.text="TAP TO JUMP";
        }
       
      
    }
      IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(3.0f); // Adjust the time delay as needed
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && isOnGround && !GameOver)
    {
        PlayerRB.AddForce(Vector3.up * upspeed, ForceMode.Impulse);
        isOnGround = false;
        playeranim.SetTrigger("Jump_trig");
        runparticle.Stop();
        playeraudio.PlayOneShot(jumpsound, 1.0f);

        Instrtext.text = "";
    }

    if (GameOver)
    {
        StartCoroutine(DelayedLoadScene());
    }
        
     /*if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }*/
        /*if(GameOver==true){
            SceneManager.LoadScene(2);
        }*/
        
    }
    
    public void OnCollisionEnter(Collision Collision){
        if(Collision.gameObject.CompareTag("Ground")){
        isOnGround=true;
        runparticle.Play();
        }
        else if(Collision.gameObject.CompareTag("Obstacle")){

            Instrtext.text="";
            runparticle.Stop();
            explosionParticle.Play();
            playeranim.SetBool("Death_b",true);
            playeranim.SetInteger("DeathType_int",1);
            playeraudio.PlayOneShot(crashsound);
            
            GameOver=true;
            isOnGround=true;
            

        }
    }
     
        
      
    
    /*    private void RestartGame()
    {
         // Reset relevant variables and game state
        isOnGround = true;
        GameOver = false;
        SceneManager.LoadScene(1);
    }*/
    


    
  
}

