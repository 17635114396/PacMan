using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMaterialManager : MonoBehaviour
{
    public Material[] allMaterial;
    public GameObject[] go;
    int i;
    GameObject gameMode;//传递游戏音效
    
    // Start is called before the first frame update
    void Start()
    {
        gameMode = GameObject.Find("Camera");
        i = GameObject.Find("Canvas").GetComponent<MyButtonManager>().materialIndex;
    }

    // Update is called once per frame
    void Update()
    {
        i = GameObject.Find("Canvas").GetComponent<MyButtonManager>().materialIndex;
        if (i != 0)
            Changing(i);
    }

    /// <summary>
    /// 替换贴图
    /// </summary>
    /// <param name="go">替换的物体</param>
    /// <param name="i">替换的贴图编号</param>
    public void ReplaceMaterial(GameObject go, int i)
    {
        go.GetComponent<Renderer>().material = allMaterial[i];
    }

    /// <summary>
    /// 播放更换勾选音效
    /// </summary>
    //void PlayAudioForCheck() {}

    ///// <summary>
    ///// 根据不同的选项更换索引号
    ///// </summary>
    //public void Ocean()
    //{
    //    i = 4;
    //    //ReplaceMaterial(go[0], i);
    //    //PlayAudioForCheck();
    //}
    //public void Grass()
    //{
    //    i = 1;
    //    //ReplaceMaterial(go[0], i);
    //    //PlayAudioForCheck();
    //}
    //public void Desirt()
    //{
    //    i = 3;
    //    //ReplaceMaterial(go[0], i);
    //    //PlayAudioForCheck();
    //}
    //public void Ston()
    //{
    //    i = 2;
    //    //ReplaceMaterial(go[0], i);
    //    //PlayAudioForCheck();
    //}

    /// <summary>
    /// 根据索引号，改变贴图
    /// </summary>
    /// <param name="i"></param>
    void Changing(int i)
    {
        ReplaceMaterial(go[0], i);
    }
}
