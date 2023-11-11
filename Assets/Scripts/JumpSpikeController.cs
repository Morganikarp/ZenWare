using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSpikeController : MonoBehaviour
{
    public static float Speed;
    float Dif;

    void Awake()
    {
        transform.position = new Vector3(1.2f, -0.5f, 0f);
    }

    void Update()
    {
        transform.position += new Vector3(-5f * Speed,0f, 0f) * Time.deltaTime;
    }
    
    void OnDisable()
    {
        Destroy(this.gameObject);
    }
}
