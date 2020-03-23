using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectionables : MonoBehaviour
{
    bool SuperColleatables;//是否为超级食物

    // Start is called before the first frame update
    void Start()
    {
        //CreateCollectonables();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //脚本生成豆子
    //void CreateCollectonables() {
    //    var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);//初始化
    //    go.GetComponent<Collider>().isTrigger = true;//是否碰撞
    //    go.transform.localScale = new Vector3(0.2f,0.2f, 0.2f);//大小
    //    go.transform.position = new Vector3(1f, 0.5f, -4.5f);//位置
    //    go.GetComponent<MeshRenderer>().material.color = Color.yellow;//颜色
    //    go.tag = "Collections";//设置标签
    //}

}
