using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObstacleSpawner : MonoBehaviour
{
    public MasterGameController MGC;
    public GameObject Parent;
    public GameObject Obstacle;
    public bool Spawn;

    void OnEnable()
    {
        FlyObstacleController.Speed = MGC.Score * 0.25f;

        if (MGC.Score >= 10)
        {
            FlyObstacleController.Speed = 2f;
        }

        

        Spawn = false;
        StartCoroutine("Timing");
    }

    void Update()
    {
        if (Spawn == true)
        {
            Spawn = false;
            GameObject a = Instantiate(Obstacle) as GameObject;
            a.transform.parent = Parent.transform;
            StartCoroutine("Spacing");
        }
    }

    IEnumerator Timing()
    {
        yield return new WaitForSeconds(0.3f);
        Spawn = true;
    }

    IEnumerator Spacing()
    {
        yield return new WaitForSeconds(1.5f);
        Spawn = true;
    }
}
