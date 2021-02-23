using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Parenting>().unCouple();
    }
}
