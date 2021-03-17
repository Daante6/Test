using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    public InputAction movementH;
    public InputAction shoot;

    public Joystick joystick;

    public float speed = 4f;
    public Text text;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private float movement = 0f;

    private float moveDirection;

    private float bonusVine = 0;

    public GameObject p1heart1, p1heart2, p1heart3;

    private void Awake()
    {
        
    }
    void OnEnable()
    {
        movementH.Enable();
        shoot.Enable();
    }

    void OnDisable()
    {
        movementH.Disable();
        shoot.Disable();
    }

    private void Start()
    {
        p1heart1.gameObject.SetActive(true);
        p1heart2.gameObject.SetActive(true);
        p1heart2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //keyboard controls
        moveDirection = movementH.ReadValue<float>();
        //joystick controls
        /*if(joystick.Horizontal > 0.1)
        {
            moveDirection = 1;
        }
        else if(joystick.Horizontal < -0.1)
        {
            moveDirection = -1;
        }
        else
        {
            moveDirection = 0;
        }
        */
        if (shoot.triggered)
        {
            shootFunction();
        }

        animator.SetFloat("Speed", Mathf.Abs(moveDirection)); //animator variable
        

        if(moveDirection < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        UIUpdate();
        bonusVineHandler();
    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
        rb.MovePosition(rb.position + new Vector2(moveDirection * speed * Time.fixedDeltaTime, 0f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            loseFunction();
        }
        else if (collision.collider.tag == "Wall")
        {
            //player hits wall
        }
        else if (collision.collider.tag == "Bonus")
        {
            bonusVineActivate();
            Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "Roof")
        {
            loseFunction();
        }
        else if (collision.collider.tag == "Bonus_Points")
        {
            StaticNameController.player1score += 100;
            Destroy(collision.gameObject);
        }
    }
    public void loseFunction()
    {
        StaticNameController.player1Lives--;
        if (StaticNameController.player1Lives > 0 || StaticNameController.player2Lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    void UIUpdate()
    {
        //lives left UI text
        text.text = "Player 1 score: " + StaticNameController.player1score.ToString();
        
        switch (StaticNameController.player1Lives)
        {
            case 3:
                p1heart1.gameObject.SetActive(true);
                p1heart2.gameObject.SetActive(true);
                p1heart3.gameObject.SetActive(true);
                break;
            case 2:
                p1heart1.gameObject.SetActive(true);
                p1heart2.gameObject.SetActive(true);
                p1heart3.gameObject.SetActive(false);
                break;
            case 1:
                p1heart1.gameObject.SetActive(true);
                p1heart2.gameObject.SetActive(false);
                p1heart3.gameObject.SetActive(false);
                break;
        }
    }
    public void endLevel()
    {
        StaticNameController.player1score++;
    }
    public void bonusVineActivate()
    {
        bonusVine = bonusVine + 7f;
    }
    private void bonusVineHandler()
    {
        if(bonusVine > 0)
        {
            StaticNameController.player1VineActive = true;
            bonusVine = bonusVine - Time.deltaTime;
        }
        else
        {
            StaticNameController.player1VineActive = false;
        }
    }
    public void shootFunction()
    {
        if (Chain.isFired)
        {
            animator.SetTrigger("isAttacking");
        }
        else
        {
            
        }
    }
}
