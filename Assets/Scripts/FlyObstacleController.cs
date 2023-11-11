using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObstacleController : MonoBehaviour
{
    public static float Speed;

    void Awake()
    {
        transform.localPosition = new Vector3(5f, Random.Range(-1.1f, 1.1f), 0f);
    }

    void Update()
    {
        transform.localPosition += new Vector3(-2.75f - Speed, 0f, 0f) * Time.deltaTime;
    }

    void OnDisable()
    {
        Destroy(this.gameObject);
    }
}
