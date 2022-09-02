using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointIntraceExit : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints; 
  
    void Awake()
    {
        transform.position = new Vector3(waypoints[StateNameController.IndexWaypoint].transform.position.x,waypoints[StateNameController.IndexWaypoint].transform.position.y, transform.position.z);
        
        if (StateNameController.lookLeft)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = Vector3.one;            
        }
    }

    


    private void Update()
    {

    }
}
