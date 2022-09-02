using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaypointLevel : MonoBehaviour
{

    [SerializeField] private string NextScene;
    [SerializeField] private int GoToWaypoint;
    [SerializeField] private bool faceLeft;

    private bool contact=false;

     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton3) ) && contact)
        {
            StateNameController.IndexWaypoint = GoToWaypoint;
            StateNameController.lookLeft = faceLeft;
            SceneManager.LoadScene(NextScene);
        }
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            contact=true;
        }
        
    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contact=false;
        }
    }

}
