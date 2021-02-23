using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting : MonoBehaviour
{
    public GameObject camera;

    public void CoupleTogether()
    {
        camera.transform.parent = GameObject.Find("Target").transform;
    }

    public void unCouple()
    {
        camera.transform.parent = null;
        camera.GetComponent<CameraController>().CameraState(false);
    }
}
