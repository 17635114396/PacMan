using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLightManager : MonoBehaviour
{
    GameObject player;//传递主角是否无敌
    public Light[] allLight;
    bool isLight = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<MyPacManMove>().isBaTi == true)//主角无敌时开启灯场
        {
            MyOpenLight(0);
            MyOpenLight(1);
        }
        else//关闭灯场
        {
            MyCloseLight(1);
        }
        //根据按键开关灯
        if (Input.GetKeyDown(KeyCode.Tab))
        {
        //    if (isLight == true)
        //    {
        //        isLight = false;
        //        MyCloseLight(0);
        //        MyCloseLight(1);
        //    }
        //    else
        //    {
        //        isLight = true;
        //        MyOpenLight(0);
        //        MyOpenLight(1);
        //    }
        }

    }

    /// <summary>
    /// 关灯
    /// </summary>
    /// <param name="i"></param>
    public void MyCloseLight(int i)
    {
        allLight[i].GetComponent<Light>().enabled = false;
    }

    /// <summary>
    /// 开灯
    /// </summary>
    /// <param name="i"></param>
    public void MyOpenLight(int i)
    {
        allLight[i].GetComponent<Light>().enabled = true;
    }


}
