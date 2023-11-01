using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    private GameObject currentDoor;

    public float rayRange = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
        {
            if(hit.collider.gameObject.tag == "playerDoor")
            {
                currentDoor = hit.collider.gameObject;
                currentDoor.SendMessage("DoorCheck");
            }
        }
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "playerDoor" && !doorIsOpen)
        {
            currentDoor = hit.gameObject;
            Door(doorOpenSound, true, "doorOpen", currentDoor);
        }
    }*/
}
