using UnityEngine;
using System.Collections;

public class followcube : MonoBehaviour {

    public Transform player;
    private Vector3 playerOffset;

    // Use this for initialization
    void Start()
        {
        playerOffset = transform.position - player.transform.position;
        }

    // Update is called once per frame
    void Update()
        {
     //   transform.LookAt(player.transform);
        transform.position = player.transform.position + playerOffset;
        }

}
