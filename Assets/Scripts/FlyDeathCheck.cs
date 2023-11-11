using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDeathCheck : MonoBehaviour
{
    FlyPlayerController Cir;

    void Start()
    {
        Cir = gameObject.transform.parent.gameObject.GetComponent<FlyPlayerController>();
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "Enemy")
        {
            Cir.Dead = true;
        }
    }
}
