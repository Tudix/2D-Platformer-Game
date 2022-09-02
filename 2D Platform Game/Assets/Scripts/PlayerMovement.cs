using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState {idle, running, jumping, falling}

    
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");

        if ((!anim.GetBool("attacking") || !(anim.runtimeAnimatorController.name == "Player_Archer") )  && !anim.GetBool("dead"))
        {
            rb.velocity = new Vector2(dirX * moveSpeed , rb.velocity.y); //move main character to left or right

            if(Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); //main character jump on OY axe
            }

            UpdateAnimationState();
        }
        
    }

    private void UpdateAnimationState()
    {

        MovementState state;
            if (dirX > 0f) // running right animation
            {
                state = MovementState.running;
                //sprite.flipX = false;
                transform.localScale = Vector3.one;
            }
            else if(dirX < 0f) // running left animation
            {
                state = MovementState.running;
                //sprite.flipX = true;
                transform.localScale = new Vector3(-1,1,1); //rotate the object
            }
            else
            {
                state = MovementState.idle; // idle animation
            }

            if (rb.velocity.y > .1f) //velocity.y doesn't accept 0 value
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }

            anim.SetInteger("state",(int)state);   
                
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f , jumpableGround);
    }

    public bool canAttack()
    {            
        if (anim.runtimeAnimatorController.name == "Player_Archer")
            return IsGrounded(); //Player can attack when isGrounded
        if (anim.runtimeAnimatorController.name == "Player_Sword")          
            return true; //Player can attack everytime     
            
        return false;
    }

    

}
