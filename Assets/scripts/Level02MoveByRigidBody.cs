using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02MoveByRigidBody : MonoBehaviour
{
    [SerializeField]
    public FloatingJoystick joystick;
   [SerializeField]
    private float SpeedFactor = 10f;

    private Rigidbody2D Rb;  
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Rb.velocity = new Vector3(horizontalInput, verticalInput, 0f).normalized * SpeedFactor; 
    }
}
