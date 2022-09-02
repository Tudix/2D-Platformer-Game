using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //rb.bodyType = RigidbodyType2D.Static;            
            boxCollider.enabled = false;
            anim.SetTrigger("pickup"); //Activate "pickup" animation when the arrow hit
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
