using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    //Stats de base:
    public int pointDeVie;

    //public bool bulletEnnemisTreFor = true;
    public float bulletTimer = 0.0f;
    public GameObject bulletEnnemis;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= 2.0f && gameObject.tag =="EnnemisTreForts")
        {
            Instantiate(bulletEnnemis, transform.position, transform.rotation);
            bulletTimer = 0.0f;
        }
    }
}
