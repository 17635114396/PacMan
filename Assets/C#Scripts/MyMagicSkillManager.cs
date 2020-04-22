using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMagicSkillManager : MonoBehaviour
{

    GameObject player;
    Transform t;
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        player=GameObject.Find("TuDunPos");
    }

    // Update is called once per frame
    void Update()
    {
        t.position = player.transform.position;
    }

   //创建土遁墙
    public void TuDun()
    {
        //Transform tuDunPos = GameObject.Find("TuDunPos").transform;//引用变量生成的土遁会一直跟着主角移动
        i++;
        Debug.Log(i);
        var Tudunobject= GameObject.Instantiate(Resources.Load("Prefabs/TuDun"), t, true);
        Destroy(Tudunobject,4f);
        GameObject.FindGameObjectWithTag("TuDun").transform.position = player.transform.position+new Vector3(1,0,1);
    }

}
