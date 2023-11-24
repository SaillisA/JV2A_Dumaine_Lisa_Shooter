using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Joueur : MonoBehaviour
{
    public GameObject balle;
    public GameObject gigaBalle;

    //pour tirer les balles
    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public GameObject joueur;
    public int bonusCompteur = 0;
    public float speed = 0.5f;

    //pour l'Ui
    public TextMeshProUGUI piecesAffiche;
    public int piecesCompteur = 0;

    public TextMeshProUGUI score;
    public int scoreCompteur;

    public TextMeshProUGUI vie;
    public int vieCompteur = 5;

    //VFX
    public GameObject joueurDegat;
    public GameObject joueurExplose;


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
                Instantiate(gigaBalle, parent.position, parent.rotation);
            }
            else
            {
                Instantiate(balle, parent.position, parent.rotation);
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


        if(vieCompteur <=0 )
        {
            vie.text = "Vitalite : mort";
            Debug.Log("Joueur mort");
            Instantiate(joueurExplose,joueur.gameObject.transform.position, joueur.gameObject.transform.rotation);
            Destroy(joueur.gameObject);
        }

        score.text = "Score : " + scoreCompteur;


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

            piecesAffiche.text = "Pieces : " + piecesCompteur;
            Debug.Log(piecesCompteur);
        }
        if (collision.gameObject.tag == "ballesEnnemis")
        {
            Debug.Log("Ouille");
            vieCompteur--;
            vie.text = "Vitalite : " + vieCompteur;
            Destroy(collision.gameObject);
            Instantiate(joueurDegat,joueur.gameObject.transform.position, joueur.gameObject.transform.rotation);
        }
    }
}
