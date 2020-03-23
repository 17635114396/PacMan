using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemy : MonoBehaviour
{
    Transform player;//传递玩家位置
    GameObject gameMode;

    public Transform[] Enemy;

    public NavMeshAgent nav;//导航初始化
    public bool isProtect;//是否为守护怪
    bool isRight = true;//守护怪是否向右走

    GameObject pacman;
    Vector3 escapeDestionation;//逃离目标
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameMode = GameObject.Find("Camera");
        pacman = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Nav();
        //GetEscapeDestion(player.position);
    }

    /// <summary>
    /// 守护怪和小怪地自动导航设置
    /// </summary>
    void Nav()
    {
        if (this.GetComponent<MeshRenderer>().enabled == true)
        {
            if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Playing)
            {
                if (isProtect == true)
                {
                    if (isRight == true)
                    {
                        if (transform.position.x > 1.4f)
                        {
                            isRight = false;
                            nav.SetDestination(new Vector3(-1.7f, 0.1f, 1.5f));
                        }
                        else
                        {
                            isRight = true;
                            nav.SetDestination(new Vector3(1.5f, 0.1f, 1.5f));
                        }
                    }
                    else
                    {
                        if (transform.position.x < -1.5f)
                        {
                            isRight = true;
                            nav.SetDestination(new Vector3(1.5f, 0.1f, 1.5f));
                        }
                        else
                        {
                            isRight = false;
                            nav.SetDestination(new Vector3(-1.7f, 0.1f, 1.5f));
                        }
                    }
                }
                else
                {
                    TracePlayer();
                }
            }
            else if (gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Win)
            {
                nav.enabled = false;
            }
        }
    }

    /// <summary>
    /// 追踪玩家行为
    /// </summary>
    public void TracePlayer()
    {
        nav.SetDestination(player.position);
        nav.speed = 1.5f;
    }

    /// <summary>
    /// 回到老巢后显示真身
    /// </summary>
    /// <param name="other">老巢碰撞体</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyRebornPos")
        {
            //yield return new WaitForSeconds(5.0f);
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    ///// <summary>
    ///// 逃离执行
    ///// </summary>
    ///// <param name="position"></param>
    //void EscapePacman(Vector3 position) {
    //    nav.speed = 0.2f;
    //    nav.destination = position;
    //}

    ///// <summary>
    ///// 取得逃离目标点
    ///// </summary>
    ///// <param name="position"></param>
    //void GetEscapeDestion(Vector3 position) {
    //    escapeDestionation.x = -position.x;
    //    escapeDestionation.z = -position.z;
    //    escapeDestionation.y = position.y;
    //}

    ///// <summary>
    ///// 判断主角霸体时执行逃离
    ///// </summary>
    //public void SetEscape()
    //{
    //    if (pacman.gameObject.GetComponent<MyPacManMove>().isBaTi == true)
    //    {
    //        GetEscapeDestion(player.position);
    //        EscapePacman(escapeDestionation);
    //    }
    //}
}
