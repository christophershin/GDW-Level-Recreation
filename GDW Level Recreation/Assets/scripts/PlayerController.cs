using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public int HP = 4;
    public float speed;
    public float jumpingPower;
    private float jumpMultiplier;
    private float gravityMultiplier; 
    [SerializeField] private float maxGravityMulti = 1f;

    private bool isFacingRight = true;

    private bool dashBool = false;
    private float dashTime = 0f;
    
    

    [SerializeField] private int DashSpeed = 50;
    [SerializeField] private float MaxDashCoolDown = 1;
    [SerializeField] private Image dashBar;
    private float DashCoolDown;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Animator animator;

    void Start()
    {

        dashBool = true;
    }





    void Update()
    {
        DashCoolDown+=Time.deltaTime;

        if(dashTime<=0f)
            horizontal = Input.GetAxisRaw("Horizontal");


        // jumping 
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            gravityMultiplier = 0f;
            jumpMultiplier = 1f;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            
            if(jumpMultiplier>0f)
            {
                jumpMultiplier-=Time.deltaTime;
            }

        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.2f);
            rb.velocity -= new Vector2(0, jumpMultiplier);
            
        }


        // increase falling speed for more natural feel.
        gravityMulitplication();



        // dash input
        if(DashCoolDown>=MaxDashCoolDown)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(dashBool)
                    dashTime = 0.12f;
                    DashCoolDown = 0;

            }
        }


        if (horizontal != 0f)
        {
            animator.SetBool("isWalking", true);
            Debug.Log("Walking");
        }

        if (horizontal == 0f)
        {
            animator.SetBool("isWalking", false);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Dash();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    private void Dash()
    {
        dashTime-=Time.deltaTime;

        if(dashTime>0)
        {
            rb.velocity = new Vector2(horizontal*DashSpeed, rb.velocity.y);

        }

        dashBar.fillAmount = DashCoolDown/MaxDashCoolDown;
        
    }

    private void gravityMulitplication(){
        if(rb.velocity.y < 0 && !IsGrounded()){

            gravityMultiplier += Time.deltaTime;

            if(gravityMultiplier<maxGravityMulti)
            {
                rb.velocity -= new Vector2(0,gravityMultiplier);
            }
            

        }

    }
}