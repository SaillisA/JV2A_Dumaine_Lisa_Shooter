using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisTirs : MonoBehaviour
{
    public Transform parent;
    public GameObject bulletEnnemis;
    public bool bulletEnnemisTreFor = true;
    private int bulletTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer++;

        if (bulletTimer == 120)
        {         
            Instantiate(bulletEnnemis, parent.position, parent.rotation);
            bulletTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("ouille");
            Destroy(collision.gameObject);
        }
    }
}
