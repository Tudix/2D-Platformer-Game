using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldownArcher;

    [SerializeField] private float attackCooldownKnight;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform swordPoint;
    [SerializeField] private GameObject[] Arrows;
    private Animator anim;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;
    private float cooldownTimer = Mathf.Infinity;
    private float attackCooldown;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (anim.runtimeAnimatorController.name == "Player_Archer")
            attackCooldown = attackCooldownArcher;
        if (anim.runtimeAnimatorController.name == "Player_Sword")
            attackCooldown = attackCooldownKnight;

        if ((Input.GetMouseButton(0) || Input.GetButtonDown("Fire1")) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            {
                Attack();
            }   

        cooldownTimer += Time.deltaTime;

    }

    private void Attack()
    {
            //Archer Attack
        anim.SetTrigger("attack"); // Start attack animation
        anim.SetBool("attacking",true); // If animation of attacking is ON then player can't switch weapons
        //if (anim.runtimeAnimatorController.name == "Player_Archer")            

            //Knight Attack
        // if (anim.runtimeAnimatorController.name == "Player_Sword")

        

        cooldownTimer = 0;
    }

    private void LaunchArrow()
    {
        //Pool Arrows

        Arrows[FindArrow()].transform.position = firePoint.position; //Pick up an arrow to the firePoint (in front of the player)
        Arrows[FindArrow()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        //rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private int FindArrow()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            if (!Arrows[i].activeInHierarchy) // Check which arrow is NOT active
                return i;  // return first inactive arrow in array
        }

        return 0;
    }
    

    private void AttackOff() {
        anim.SetBool("attacking",false);
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Chest"))
    //     {
    //         Debug.Log("Hitted");
    //     }
        
    // }

}
