using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float projectTimer;
    private float lifetime;
    private float direction;
    private bool hit;
     

    private BoxCollider2D boxCollider;
    private Animator anim;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction; // Adding speed on axe OX | left or right
        transform.Translate(movementSpeed,0,0); //Move projectile

        lifetime += Time.deltaTime;
        if ( lifetime > projectTimer ) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Terrain") || collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Platform"))
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("impact"); //Activate "impact" animation when the arrow hit
        }
        
    }

    public void SetDirection (float _direction)
    {

        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX; // flip the projectile

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
