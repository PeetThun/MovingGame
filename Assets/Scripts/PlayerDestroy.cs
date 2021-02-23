using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public GameObject camera;

    public void DestroyPlayer()
    {
        Destroy(camera);
        Destroy(this.gameObject);
    }
}
