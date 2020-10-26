using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    private int scoreValue = 0;

    private int livesValue = 3;

    public Text winText;

    public Text loseText;

    public Text lives;

    public AudioClip musicClipOne;

    public AudioSource musicSource;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        winText.text = " ";
        loseText.text = " ";
        SetCountText();
        SetLivesText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        
        if (Input.GetKey("escape"))

        {

          Application.Quit();
        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            Destroy(collision.collider.gameObject);
            SetCountText();
        }
        
        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            Destroy(collision.collider.gameObject);
            SetLivesText();
        }  

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
        void SetCountText ()
    {
        score.text = "Score: " + scoreValue.ToString();

        if (scoreValue == 4)
        {
            transform.position = new Vector3(44.0f, 0.0f, 0.0f);
            livesValue = 3;
            SetLivesText ();
        }

        if (scoreValue == 8)
        {
            winText.text = "You Win, Game by Ethan Osborne!";
            Destroy(this);
            musicSource.clip = musicClipOne;
            musicSource.Play();
            if (Input.GetKey("escape"))

        {

          Application.Quit();
        
        }
        }
    }
        void SetLivesText ()
    {
        lives.text = "Lives: " + livesValue.ToString ();

        if (livesValue == 0)
        {
            loseText.text = "You lose, loser!";
            Destroy(this);
        }
    }
    
}