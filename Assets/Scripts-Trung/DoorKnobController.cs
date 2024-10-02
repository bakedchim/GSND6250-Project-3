using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnobController : MonoBehaviour
{
    public Material openDoorMaterial;
    // parent game object
    private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        // get the parent game object
        door = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other) {
        // if target is bullet
        if (other.gameObject.CompareTag("Bullet")) {
            Debug.Log("Bullet hit the door knob");
            // Change the door material to openDoorMaterial
            transform.GetComponent<Renderer>().material = openDoorMaterial;
            // get the DoorController script from the parent game object
            DoorController doorController = door.GetComponent<DoorController>();
            // call the OpenDoor method from the DoorController script
            doorController.OpenDoor();
        }
    }
}
