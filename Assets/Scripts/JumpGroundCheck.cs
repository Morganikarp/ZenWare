using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGroundCheck : MonoBehaviour
{
    JumpPlayerController Sqr;

    void Start()
    {
        Sqr = gameObject.transform.parent.gameObject.GetComponent<JumpPlayerController>();
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "Ground")
        {
            Sqr.Grounded = true;
        }
        
        if (a.gameObject.tag == "Enemy")
        {
            Sqr.Dead = true;
        }
    }

    void OnTriggerExit2D(Collider2D a)
    {
        if (a.gameObject.tag == "Ground")
        {
            Sqr.Grounded = false;
        }
    }
}
