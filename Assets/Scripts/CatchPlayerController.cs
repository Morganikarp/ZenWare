using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayerController : MonoBehaviour
{
    public MasterGameController MGC;
    Vector3 Target;
    float[] Spawn = { -5f, 0f, 5f };
    float[] SpawnRestrained = { -5f, 5f };
    string[] Axis = { "X", "Y" };
    float PosX;
    float PosY;
    float StartDelay;
    bool Send;
    public bool InRange;
    bool Halt;
    float Dif;

    void OnEnable()
    {
        Send = false;
        InRange = false;
        Halt = false;
        
        if (MGC.Score == 0f)
        {
            Dif = 0.8f;
        }

        if (MGC.Score >= 1f)
        {
            Dif = MGC.Score / 2f;

            if (Dif > 2.5f)
            {
                Dif = 2.5f;
            }

        }

        StartDelay = Random.Range(0.5f, 3f);

        if (Axis[Random.Range(0, Axis.Length)] == "X")
        {
            PosX = Spawn[Random.Range(0, Spawn.Length)];
            PosY = SpawnRestrained[Random.Range(0, SpawnRestrained.Length)];
        }

        else
        {
            PosY = Spawn[Random.Range(0, Spawn.Length)];
            PosX = SpawnRestrained[Random.Range(0, SpawnRestrained.Length)];
        }

        transform.localPosition = new Vector3(PosX, PosY, 0f);
        Target = new Vector3(PosX * -1f, PosY * -1, 0f);

        StartCoroutine("SendBall");
        StartCoroutine("FailCheck");
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && InRange == true)
        {
            Halt = true;
        }


        if (Halt == false && Send == true)
        {
            transform.localPosition = new Vector3((Mathf.Lerp(transform.localPosition.x, Target.x, Time.deltaTime * Dif)), (Mathf.Lerp(transform.localPosition.y, Target.y, Time.deltaTime * Dif)), 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "Enemy")
        {
            InRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D a)
    {
        if (a.gameObject.tag == "Enemy")
        {
            InRange = false;
        }
    }

    IEnumerator SendBall()
    {
        yield return new WaitForSeconds(StartDelay);
        Send = true;
    }

    IEnumerator FailCheck()
    {
        yield return new WaitForSeconds(4f);
        if (Halt == false)
        {
            MGC.Lost = true;
        }
    }
}