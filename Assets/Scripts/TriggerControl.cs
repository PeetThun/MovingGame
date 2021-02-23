using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerControl : MonoBehaviour
{
    public GameObject EndSceen;
    public CameraController cam;
    

    private void Start()
    {
        Time.timeScale = 1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EndSceen.gameObject.SetActive(true);
            Time.timeScale = 0;
            cam.FreezCamera();
            SceneManager.LoadScene("YouWin");
            
        }
        
    }
}
