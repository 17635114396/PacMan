using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLightManager : MonoBehaviour
{
    public Light[] allLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 关灯
    /// </summary>
    /// <param name="i"></param>
    public void MyCloseLight(int i) {
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
