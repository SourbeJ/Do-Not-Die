using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] Respawn;

    public Sprite[] sprites;
    public CharacterController2D controller;
    public GameManager gameManager;

    public float runSpeed = 40f;
    public float responseSpeed;
    public float horizontalMove = 0f;

    SpriteRenderer sprite;

    bool jump = false;
    bool crouch = false;
    float horizontal = 0f;

    public bool respawn;
    public bool Left;
    public bool Right;
    public bool Jump;

    void Start()
    {
        if(gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();

        int color = PlayerPrefs.GetInt("Color");

        if (color == 1)
            sprite.color = new Color(1, 1, 0, 1);
        if (color == 2)
            sprite.color = new Color(1, 0.6987091f, 0, 1);
        if (color == 3)
            sprite.color = new Color(1, 0, 0, 1);
        if (color == 4)
            sprite.color = new Color(1, 0, 1, 1);
        if (color == 5)
            sprite.color = new Color(0, 0, 1, 1);
        if (color == 6)
            sprite.color = new Color(0, 1, 1, 1);
        if (color == 7)
            sprite.color = new Color(0, 1, 0, 1);
        if (color == 8)
            sprite.color = new Color(0.45f, 0.35f, 0, 1);

        int skin = PlayerPrefs.GetInt("Skin");

        Debug.Log(skin);

        if (skin > -1)
            sprite.sprite = sprites[skin];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            Left = true;
        if (Input.GetKeyUp(KeyCode.Q))
            Left = false;
        if (Input.GetKeyDown(KeyCode.D))
            Right = true;
        if (Input.GetKeyUp(KeyCode.D))
            Right = false;
        if (Input.GetKeyDown(KeyCode.Space))
            Jump = true;


        if (respawn || transform.position.y < -10)
        {
            audioSource.PlayOneShot(Respawn[0]);
            transform.position = Vector3.zero;
            respawn = false;
            Left = false;
            Right = false;
            Jump = false;
            gameManager.Respawn();
        }

        horizontalMove = horizontal;

        if (Left)
        {
            horizontal = Mathf.MoveTowards(horizontalMove, -1, responseSpeed * Time.deltaTime);
        }
        else
        {
            horizontal = Mathf.MoveTowards(horizontalMove, 0, responseSpeed * Time.deltaTime);
        }
        if (Right)
        {
            horizontal = Mathf.MoveTowards(horizontalMove, 1, responseSpeed * Time.deltaTime);
        }
      
        if (Jump)
        {
            jump = true;
            Jump = false;
        }
    }

    public void LeftDown()
    {
        Left = true;
    }
    public void RightDown()
    {
        Right = true;
    }
    public void JumpDown()
    {
        Jump = true;
    }

    public void LeftUp()
    {
        Left = false;
    }

    public void RightUp()
    {
        Right = false;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }  
}
