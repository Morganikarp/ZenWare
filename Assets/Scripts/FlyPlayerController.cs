using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlayerController : MonoBehaviour
{
    public MasterGameController MGC;
    Rigidbody2D rb2d;
    public bool Dead;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Dead = false;
    }

    void OnEnable()
    {
        transform.position = new Vector3(-3f, 1f, 0f);
        Dead = false;
    }

    void Update()
    {
        if (Dead == true)
        {
            MGC.Lost = true;
        }

        if (Input.GetKeyDown("space") && Dead == false)
        {
            rb2d.velocity = Vector2.up * 2.5f;
        }
    }
}
