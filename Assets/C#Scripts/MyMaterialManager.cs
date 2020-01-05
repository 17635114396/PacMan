using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMaterialManager : MonoBehaviour
{
    public Material[] allMaterial;
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
}
