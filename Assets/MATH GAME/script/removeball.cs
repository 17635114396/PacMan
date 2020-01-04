using UnityEngine;
using System.Collections;

public class removeball : MonoBehaviour {

	// Use this for initialization
    void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.name == "groundout")
            {
            Destroy(gameObject);

            }
        }
}
