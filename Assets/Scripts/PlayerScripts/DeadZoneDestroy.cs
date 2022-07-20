using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneDestroy : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DeadZone")
        {
            gameObject.SetActive(false);
        }
    }
}
