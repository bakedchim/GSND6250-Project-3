using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPointController : MonoBehaviour
{
    public DoorController[] openDoorControllers;
    public DoorController[] closeDoorControllers;
    
    public PlayerMovement playerMovement;
    
    bool opened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (opened)
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (DoorController doorController in openDoorControllers)
            {
                doorController.OpenDoor();
            }
            foreach (DoorController doorController in closeDoorControllers)
            {
                doorController.CloseDoor();
            }
            opened = true;
            playerMovement.canMove = false;
            Invoke(nameof(ResetPlayerMovement), 1.0f);
        }
    }

    void ResetPlayerMovement()
    {
        playerMovement.canMove = true;
    }
}
