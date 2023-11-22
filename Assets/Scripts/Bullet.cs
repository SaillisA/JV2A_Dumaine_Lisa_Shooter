using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private int aleaDrop;
    public Rigidbody2D monRigidBody;
    public float speed;
    public int bulletDegat;
    public GameObject drop;
    public GameObject piece;

    public Joueur joueurChangementScore;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;

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

            enemiEnCollision.pointDeVie -= bulletDegat;

            if (enemiEnCollision.pointDeVie <= 0)
            {
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
