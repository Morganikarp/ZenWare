using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerController : MonoBehaviour
{
    public MasterGameController MGC;
    Rigidbody2D rb2d;
    public bool Grounded;
    public bool Dead;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Grounded = false;
        Dead = false;
    }

    void OnEnable()
    {
        transform.position = new Vector3(-6f, 1f, 0f);
        Grounded = false;
        Dead = false;
    }

    void Update()
    {
        if (Dead == true)
        {
            MGC.Lost = true;
        }

        if (Input.GetKeyDown("space") && Grounded == true && Dead == false)
        {
            rb2d.velocity = Vector2.up * 15;
        }
    }
}
