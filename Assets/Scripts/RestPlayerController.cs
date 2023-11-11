using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestPlayerController : MonoBehaviour
{
    public MasterGameController MGC;

    void Update()
    {
        if (MGC.Lost == false)
        {
            transform.eulerAngles += new Vector3(0f, 0f, -0.1f * MGC.Score);
        }

        if (Input.GetKeyDown("space"))
        {
            MGC.Lost = true;
        }
    }
}
