using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    public InputAction movementH;
    public InputAction shoot;

    public float speed = 4f;
    public Text text;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private float movement = 0f;

    private float moveDirection;

    private float bonusVine = 0;

    public GameObject p2heart1, p2heart2, p2heart3;

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
        p2heart1.gameObject.SetActive(true);
        p2heart2.gameObject.SetActive(true);
        p2heart2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = movementH.ReadValue<float>();
        
        if (shoot.triggered)
        {
            if (Chain2.isFired2)
            {
                animator.SetTrigger("isAttacking");
            }
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
            StaticNameController.player2score += 100;
            Destroy(collision.gameObject);
        }
    }
    public void loseFunction()
    {
        StaticNameController.player2Lives--;
        if(StaticNameController.player1Lives > 0 || StaticNameController.player2Lives > 0)
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
        text.text = "Player 2 score: " + StaticNameController.player2score.ToString();
        
        switch (StaticNameController.player2Lives)
        {
            case 3:
                p2heart1.gameObject.SetActive(true);
                p2heart2.gameObject.SetActive(true);
                p2heart3.gameObject.SetActive(true);
                break;
            case 2:
                p2heart1.gameObject.SetActive(true);
                p2heart2.gameObject.SetActive(true);
                p2heart3.gameObject.SetActive(false);
                break;
            case 1:
                p2heart1.gameObject.SetActive(true);
                p2heart2.gameObject.SetActive(false);
                p2heart3.gameObject.SetActive(false);
                break;
        }
    }
    public void endLevel()
    {
        StaticNameController.player2score++;
    }
    public void bonusVineActivate()
    {
        bonusVine = bonusVine + 7f;
    }
    private void bonusVineHandler()
    {
        if(bonusVine > 0)
        {
            StaticNameController.player2VineActive = true;
            bonusVine = bonusVine - Time.deltaTime;
        }
        else
        {
            StaticNameController.player2VineActive = false;
        }
    }
}
