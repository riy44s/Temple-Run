using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    bool alive = true;
    public float speed;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMoving=2;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMusk;
    public float playerMovementSpeed=0.1f;
    public bool canJump;
    public bool turnLeft, turnRight;
    public bool slide = false;
    public Animator anim;
    public bool isJumping = false;
    public bool hitObstacle = false;
    CapsuleCollider CAP;
    private void Start()
    {
        CAP = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        if (Input.GetButton("Jump") && canJump == true)
        {
            jump();
        }
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5 || transform.position.y > 5)
        {
           
            die();
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            slide = true;
        }
        else
        {
            slide = false;
        }
        if(slide == true)
        {
            anim.SetBool("Slide", true);
            CAP.height = 1.13f;
        }
        else if(slide == false)
        {
            StartCoroutine(RestSlideAnimation());
                
        }
    }
    IEnumerator RestSlideAnimation()
    {
       
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Slide", false);
        CAP.height = 1.74f;
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
    public void die()
    {
        alive = false;
        GameManeger.inst.Lives();
        Invoke("Restart", 1.8f);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            anim.SetBool("Jump", false);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            hitObstacle = true;
            anim.SetBool("Dead", hitObstacle);
            die();
        }
    }
   
}
