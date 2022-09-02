using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;


public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton6))
            RestartGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        anim.SetBool("dead",true);
    }

    private void RestartLevel()
    {
        // EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        anim.SetBool("dead",false);
    }

    public void RestartGame()
    {
        // EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);
        StateNameController.AllCoins = 0;
        StateNameController.state = (StateNameController.ControllerState)0;
    }

}
