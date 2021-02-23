using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float RotationSpeed = 0.5f;
    public Transform Target, Player;
    float mouseX, mouseY;

    public Transform ObsTruction;
    float zoomSpeed = 2f;
    private bool hasControl = true;
    private bool cameraFreez = false;


    private void Start()
    {
        ObsTruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
       
        //ViewObstruted();
        if (hasControl == true) 
        { 
           CamControl();  
        }
        else
        {
            LookAtPlayer();
        }

    }
    public void CameraState(bool _hasControl)
    {
        hasControl = _hasControl;
    }
    void LookAtPlayer()
    { 
        transform.LookAt(Player, Vector3.up);
    }
    public void StopCamera()
    { 
        
    }

    public void FreezCamera()
    {
        cameraFreez = true;
    }

    void CamControl()
    {

        if (cameraFreez == false)
        { 
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);
    
            transform.LookAt(Target);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            }

            else
            { 
                Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
                Player.rotation = Quaternion.Euler(0, mouseX, 0);
            }
        
        }
        
       
    }

    void ViewObstruted()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                ObsTruction = hit.transform;
                ObsTruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(ObsTruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }

            else
            {
                ObsTruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }
}
