using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCircleScript : MonoBehaviour
{
    Vector3 Size;
    bool Grow = true;
    
    public bool NewGame = false;

    public float ShrinkSpd;
    public float GrowSpd;

    bool SingleRun = false;

    void OnEnable()
    {
        SingleRun = true;
    }

    void Update()
    {
        if (Grow == false)
        {
            Small();

            if (SingleRun == true)
            {
                SingleRun = false;
                StartCoroutine("ShrinkingTimer");
            }
        }

        else if (Grow == true)
        {
            Big();

            if (SingleRun == true)
            {
                SingleRun = false;
                StartCoroutine("GrowingTimer");
            }
        }
    }

    void Small()
    {
        Size = new Vector3(0f ,0f ,1f);
        transform.localScale = Vector3.Lerp(transform.localScale, Size, ShrinkSpd * Time.fixedDeltaTime);
    }

    void Big()
    {
        Size = new Vector3(1.8f, 1.8f, 1f);
        transform.localScale = Vector3.Lerp(transform.localScale, Size, GrowSpd * Time.fixedDeltaTime);
    } 
    
    IEnumerator ShrinkingTimer()
    {
        yield return new WaitForSeconds(0.5f);
        NewGame = true;
        Grow = true;
        SingleRun = true;
    }

    IEnumerator GrowingTimer()
    {
        yield return new WaitForSeconds(3.673875f);
        Grow = false;
        SingleRun = true;
    }
}
