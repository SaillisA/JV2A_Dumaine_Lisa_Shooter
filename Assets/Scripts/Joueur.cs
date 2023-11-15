using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Joueur : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gigaBullet;

    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public GameObject bonus;
    public GameObject pieces;
    public GameObject joueur;
    public int bonusCompteur = 0;
    public int piecesCompteur = 0;

    public TextMeshProUGUI score;


    public float speed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bonusCompteur > 0)
            {
                bonusCompteur -= 1;
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
            bonusCompteur = 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Argent")
        {
            piecesCompteur++;
            Destroy(collision.gameObject);

            Debug.Log(piecesCompteur);
        }
    }
}
