using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlayerController : MonoBehaviour
{
    public MasterGameController MGC;
    bool Reached;
    float Dif;
    
    void OnEnable()
    {
        Dif = MGC.Score * 0.02f;
        if (Dif <= 0.15f)
        {
            Dif = 0.15f;
        }

        Reached = false;
        transform.localPosition = new Vector3(0f, -3f, 0f);
        StartCoroutine("FailCheck");
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.localPosition += new Vector3(0f, 0.5f - Dif, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "Enemy")
        {
            Reached = true;
        }
    }

    IEnumerator FailCheck()
    {
        yield return new WaitForSeconds(4.1f);
        if (Reached == false)
        {
            MGC.Lost = true;
        }
    }
}
