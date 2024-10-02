using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public float openTime = 1.0f;

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorCoroutine());
    }   

    public void CloseDoor()
    {
        StartCoroutine(CloseDoorCoroutine());
    }

    IEnumerator OpenDoorCoroutine()
    {
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = transform.position + new Vector3(0, 10, 0);
        float t = 0;
        while (t < openTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            yield return null;
        }
        transform.position = targetPosition;
    }  

    IEnumerator CloseDoorCoroutine()
    {
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = transform.position - new Vector3(0, 10, 0);
        float t = 0;
        while (t < openTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            yield return null;
        }
        transform.position = targetPosition;
    }  
}
