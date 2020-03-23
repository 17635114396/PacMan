using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraManage : MonoBehaviour
{
    GameObject player;//传递玩家


    public GameObject[] ca;//相机数组

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // lateUpdate is called once per frame
    private void LateUpdate()
    {
        //ShowCamera(GetCamera());
    }

    /// <summary>
    /// 显示相机
    /// </summary>
    /// <param name="i">要显示第几个相机的参数</param>
    public void ShowCamera(int i)
    {
        for (int j = 0; j < ca.Length; j++)
        {
            if (i == j)
            {
                ca[j].GetComponent<Camera>().enabled = true;
            }
            else
            {
                ca[j].GetComponent<Camera>().enabled = false;
            }
        }
    }

    /// <summary>
    /// 获取要显示的相机参数
    /// </summary>
    //int GetCamera()
    //{
    //    int j = player.GetComponent<MyPacManMove>().i;
    //    return j;
    //}
}
