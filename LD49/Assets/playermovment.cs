using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    public CharacterController2D controller;
    // Start is called before the first frame update
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    // Update is called once per frame
    void Update()
    {
         horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
