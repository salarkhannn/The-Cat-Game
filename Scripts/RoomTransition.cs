using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    //this script is used to shift the camera if the player enters a new area

    public GameObject virtualCam;

    //if the player enters a new area, activate it's virtual camera
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger) {
            virtualCam.SetActive(true);
        }
    }

    //if the player exits an area, deactivate it's virtual camera
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) {
            virtualCam.SetActive(false);
        }
    }
}
