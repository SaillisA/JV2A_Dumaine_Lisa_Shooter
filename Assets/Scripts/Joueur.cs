using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEtTir : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gigaBullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public GameObject drop;
    public GameObject joueur;
    public int dropCompteur = 0;



    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*speed;
        }       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dropCompteur > 0)
            {
                dropCompteur -= 1;
                Instantiate(gigaBullet, parent.position, parent.rotation);
            }
            else
            {
                Instantiate(bullet, parent.position, parent.rotation);
            }
        }

        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            dropCompteur = 5;
            Destroy(collision.gameObject);
        }
    }

}
