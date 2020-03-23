using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMagicSkillManager : MonoBehaviour
{
    GameObject tudun;
    GameObject player;
    Transform t;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        t.position = player.transform.position;
    }

   //创建土遁墙
    public void TuDun()
    {
        GameObject.Instantiate(Resources.Load("Prefabs/TuDun"), t,true);
    }
}
