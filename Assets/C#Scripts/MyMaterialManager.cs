using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMaterialManager : MonoBehaviour
{
    public Material[] allMaterial;
    public GameObject[] go;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 替换贴图
    /// </summary>
    /// <param name="go">替换的物体</param>
    /// <param name="i">替换的贴图编号</param>
    public void ReplaceMaterial(GameObject go,int i)
    {
        go.GetComponent<Renderer>().material = allMaterial[i];
    }

    /// <summary>
    /// 根据不同的选项更换地图贴图
    /// </summary>
    public void Ocean()
    {
        i = 4;
        ReplaceMaterial(go[0], i);
    }
    public void Grass() {
        i = 1;
        ReplaceMaterial(go[0], i);
    }
    public void Desirt()
    {
        i = 3;
        ReplaceMaterial(go[0], i);
    }
    public void Ston()
    {
        i = 2;
        ReplaceMaterial(go[0], i);
    }
}
