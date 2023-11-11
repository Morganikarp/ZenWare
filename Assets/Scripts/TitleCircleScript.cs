using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCircleScript : MonoBehaviour
{

    public GameObject TitleCircle;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + 0.0025f, 0, 0);

        if (transform.position.x >= 20)
        {
            Respawn();
            Destroy(this.gameObject);
        }
    }

    void Respawn()
    {
        GameObject crl = Instantiate(TitleCircle) as GameObject;
        crl.transform.position = new Vector3(-20, 0, 0);
    }
}

