using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
public class ifcollide : MonoBehaviour {
    public GameObject explosion;
    public GameObject smoke;
 
    public AudioSource shot;
    void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.tag  == "numbers")
            {
         //   Destroy(gameObject);
         Instantiate(explosion, transform.position, Quaternion.identity);
         Instantiate(smoke, transform.position, Quaternion.identity);
         shot.Play();
            }
        if (col.gameObject.tag == "ufo")
            {

            //   Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(smoke, transform.position, Quaternion.identity);
         //   laugh.Play();
            }
        }
      
}

