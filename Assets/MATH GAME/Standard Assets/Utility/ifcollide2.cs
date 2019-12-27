using UnityEngine;
using System.Collections;

public class ifcollide2 : MonoBehaviour {
  
    public GameObject explosion;
    public GameObject smoke;
 /// <summary>
 /// /
 /// </summary>
   public AudioSource screaming;
    public AudioSource hit;
    void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.tag == "numbers")
            {

            //   Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(smoke, transform.position, Quaternion.identity);
          //  GetComponent<AudioSource>().Play();
            hit.Play();
            }
     
        }

    }