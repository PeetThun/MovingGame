using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public bool cubIsOnTheGround = true;
  
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.instance.SetPlayer(gameObject);
    }
    private void Update()
    {
        PlayerMovement();

        if (Input.GetButtonDown("Jump") && cubIsOnTheGround) 
        { 
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            cubIsOnTheGround = false;
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            cubIsOnTheGround = true;
        }
    }
    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

    }

    
}
