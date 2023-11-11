using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSpikeSpawner : MonoBehaviour
{
    public MasterGameController MGC;
    public GameObject Parent;
    public GameObject Spike;
    public bool Spawn;

    void OnEnable()
    {
        Spawn = false;
        StartCoroutine("Timing");
    }

    void Update()
    {
        if (Spawn == true)
        {
            Spawn = false;
            GameObject a = Instantiate(Spike) as GameObject;
            a.transform.parent = Parent.transform;

            if (MGC.Score < 10)
            {
                JumpSpikeController.Speed = 1f + (JumpSpikeController.Speed * 0.15f);
            }

            if (MGC.Score >= 10)
            {
                JumpSpikeController.Speed = 3f;
            }

            StartCoroutine("Spacing");
        }
    }

    IEnumerator Timing()
    {
        yield return new WaitForSeconds(0.5f);
        Spawn = true;

    }

    IEnumerator Spacing()
    {
        yield return new WaitForSeconds(1f);
        Spawn = true;
    }
}
