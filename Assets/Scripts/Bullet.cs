using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int aleaDrop;
    public Rigidbody2D monRigidBody;
    public float speed;
    public int bulletDegat;
    public GameObject drop;
    public GameObject piece;



    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Ennemis enemiEnCollision = collision.gameObject.GetComponent<Ennemis>();
        //ennemis de base avec 1 pv
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
                }

            }
        }
        Destroy(gameObject);

    }


}
