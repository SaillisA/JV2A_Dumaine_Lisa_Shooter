using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private int aleaDrop;
    public Rigidbody2D monRigidBody;
    public float vitesse;
    public int balleDegat;
    public GameObject drop;
    public GameObject piece;

    //vfx explosions :
    public GameObject explosionBlanche;
    public GameObject explosionBleue;
    public GameObject explosionViolette;
    public Joueur joueurChangementScore;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up* vitesse;

        joueurChangementScore = FindObjectOfType<Joueur>();

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Ennemis enemiEnCollision = collision.gameObject.GetComponent<Ennemis>();
        
        if (enemiEnCollision == true)
        {

            enemiEnCollision.pointDeVie -= balleDegat;

            if (enemiEnCollision.pointDeVie <= 0)
            {
                //Affichage des explosions avec une couleur differente en fonctions de quel ennemis c'est
                if(enemiEnCollision.pointDeScore == 1)
                {
                    Instantiate(explosionBlanche,collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
                if(enemiEnCollision.pointDeScore == 3)
                {
                    Instantiate(explosionBleue,collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
                if(enemiEnCollision.pointDeScore == 5)
                {
                    Instantiate(explosionViolette,collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }

                Destroy(collision.gameObject);
                aleaDrop = Random.Range(1, 5);

                if (aleaDrop == 1)
                {
                    Instantiate(drop, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
                else
                {
                    Instantiate(piece, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                };


                
                joueurChangementScore.scoreCompteur+= enemiEnCollision.pointDeScore;

            }
        }
        Destroy(gameObject);

    }


}
