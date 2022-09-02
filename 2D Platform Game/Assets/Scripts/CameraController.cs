using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform player; //GameObject "Player"
    [SerializeField] private float aheadDistance; //Distanța dintre poziția camerei și poziția Playerului
    [SerializeField] private float DistanceY;
    [SerializeField] private float cameraSpeed; //Viteza cu care se mișcă camera
    private float lookAhead;
    private float lookDown;
    private float dirY = 0f;

    private void Update()
    {
        dirY = Input.GetAxisRaw("Vertical");

        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + DistanceY + lookDown, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance  * player.localScale.x), Time.deltaTime * cameraSpeed);

        lookDown = Mathf.Lerp(lookDown, (DistanceY  * dirY) , Time.deltaTime * cameraSpeed);
    }
}
