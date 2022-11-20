using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce;
    public float gravity = -9.18f;
    public float stamLossRate, stamRegenWait, stamina;
    public Player player;

    public CharacterController controller;
    public Transform cam;

    Vector3 velocity;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isSprinting;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        //walking
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(speed * Time.deltaTime * moveDir.normalized);
        }

        //applying gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //sprinting
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        if (isSprinting && stamina > 0 && player.hunger > 0)
        {
            speed = 10f;
            stamina -= stamLossRate * Time.deltaTime;
        }
        else if(stamina <= 0)
        {
            stamRegenWait -= Time.deltaTime;
            stamina = 0;
            speed = 5f;
            if(stamRegenWait <= 0)
            {
                stamina = 1;
                stamRegenWait = 5;
            }
        }
        else
        {
            speed = 5;
            stamina += (stamLossRate* 2) * Time.deltaTime;
            if(stamina >= 100f)
            {
                stamina = 100f;
            }
        }
        //Debug.Log(stamina);

    }

    

    

}
