using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   // public bool run = false;
  //  public float FrontForwardForce;
    public Rigidbody rb;
    public Animator anim;

    bool alive = true;
    public float speed;
    //   public float move;
  //  public Rigidbody rb;
    float horizontalInput;
    public float horizontalMoving = 2;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMusk;
    public float playerMovementSpeed = 0.1f;
    public bool canJump;
    public bool turnLeft, turnRight;
    public bool slide = false;
   // public Animator anim;
    public bool isJumping = false;
    public bool hitObstacle = false;

    private void Update()
    {
       // rb.AddForce(0, 0, FrontForwardForce * Time.deltaTime);
       /* if(run== true)
        {
            anim.SetBool("Run", run);
            transform.Translate(0, 0, 0.5f);
        }
        else if(run== false)
        {
            anim.SetBool("Run", run);
        }*/
        transform.Translate(0, 0, 0.1f);
        if (Input.GetButton("Jump") && canJump == true)
        {
            jump();
        }
        horizontalInput = Input.GetAxis("Horizontal");

      
        if (Input.GetKeyDown(KeyCode.S))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }
        if (slide == true)
        {
            anim.SetBool("Slide", slide);
            transform.Translate(0, 0, 0.1f);
        }
        else if (slide == false)
        {
            anim.SetBool("Slide", slide);
        }
        turnLeft = Input.GetKeyDown(KeyCode.Q);
        turnRight = Input.GetKeyDown(KeyCode.E);

        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));
    }
    public void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMoving;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);


    }
    void jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce);
            canJump = false;
            anim.SetBool("Jump", true);
            StartCoroutine(ResetJumpAnimation());
        }
    }
    IEnumerator ResetJumpAnimation()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("Jump", false);
        isJumping = false;
    }
    bool IsGrounded()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.3f, groundMusk);
        rb.AddForce(Vector3.up * jumpForce);
        return IsGrounded;
    }
}
