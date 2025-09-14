using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Move: MonoBehaviour // - Вместо «PlayerMove» должно быть имя файла скрипта
{
    public Rigidbody2D rb;
    public Animator animator;
    private float HorizontalMove = 0f;
    private bool isLKeyPressed = false;
    public int speed = 3;
    private bool faceRight = true; // Добавляем переменную faceRight

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        TopCheckRadius = TopCheck.GetComponent<CircleCollider2D>().radius;  
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            isLKeyPressed = true;
        }
        else
        {
            isLKeyPressed = false;
        }

        if (isLKeyPressed)
        {
            HorizontalMove = 0f;
        }
        else
        {
            HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        }
        
               if (Input.GetKeyDown(KeyCode.L))
        {
            // Включаем анимацию блокировки урона
            animator.SetBool("Block", true);
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            // Выключаем анимацию блокировки урона
            animator.SetBool("Block", false);
        }
               if (Input.GetKeyDown(KeyCode.Space))
        {
            // Включаем анимацию блокировки урона
            animator.SetBool("Firebol", true);
        }
        else
        {
            // Выключаем анимацию блокировки урона
            animator.SetBool("Firebol", false);
        }




        Walk();
        Reflect();
        Jump();
        CheckingGround();
         SquatCheck() ;

        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
    }
 
    
    void Walk()
    {
        rb.velocity = new Vector2(HorizontalMove * speed, rb.velocity.y);
    }

    void Reflect()
    {
        if ((HorizontalMove > 0 && !faceRight) || (HorizontalMove < 0 && faceRight))
        {
            transform.localScale *= new Vector2(1, 1);
            transform.Rotate(0f,180f,0f);
            faceRight = !faceRight;
        }
    }
public float jumpForce = 7f;
void Jump()
{
    if (Input.GetKeyDown(KeyCode.UpArrow) && onGround && !jumpLock)
    {
        rb.AddForce(Vector2.up * jumpForce);
        animator.SetBool("Jumping", true);
    }
    else
    {
        animator.SetBool("Jumping", false);
    }
}

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.17f;
    public LayerMask Ground;
  void CheckingGround()
{
    onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    animator.SetBool("Jumping", onGround);
}


public Transform TopCheck;
private float TopCheckRadius;
public LayerMask Roof;
public Collider2D poseStand;
public Collider2D poseSquat;
private bool jumpLock = false;
void SquatCheck() 
{
if(Input.GetKey(KeyCode.DownArrow) && onGround)
{
    animator.SetBool("squat", true);
    poseStand.enabled = false;
    poseStand.enabled = true;
    jumpLock = true;
}
else if (!Physics2D.OverlapCircle(TopCheck.position, TopCheckRadius, Roof))
{
    animator.SetBool("squat", false);
    poseStand.enabled = true;
    poseStand.enabled = false;
    jumpLock = false;
}
}


}
