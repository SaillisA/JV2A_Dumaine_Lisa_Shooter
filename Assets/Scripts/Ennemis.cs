using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    //Stats de base:
    public int pointDeVie;
    public int pointDeScore;

    //public bool bulletEnnemisTreFor = true;
    public float balleTempsRecharge = 0.0f;
    public float positionEnnemisTemps = 0.0f;
    public GameObject bulletEnnemis;
    public float vitesse;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        balleTempsRecharge += Time.deltaTime;
        positionEnnemisTemps += Time.deltaTime;

        if (balleTempsRecharge >= 2.0f && gameObject.tag =="EnnemisTreForts")
        {
            Instantiate(bulletEnnemis, transform.position, transform.rotation);
            balleTempsRecharge = 0.0f;
        }

        //deplacement des ennemis
        if (positionEnnemisTemps <= 4.0f || positionEnnemisTemps >= 12.0f && positionEnnemisTemps <= 16.0f)
        {
            transform.position += Vector3.right * vitesse;
        }

        if (positionEnnemisTemps >= 4.0f && positionEnnemisTemps <= 12.0f)
        {
            transform.position += Vector3.left * vitesse;
        }

        if(positionEnnemisTemps >= 16.0f)
        {
            positionEnnemisTemps = 0;
        }
    }
}
