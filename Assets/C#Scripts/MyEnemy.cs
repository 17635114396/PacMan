using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemy : MonoBehaviour
{
    Transform player;//传递玩家位置
    GameObject gameMode;

    public Transform[] Enemy;

    NavMeshAgent nav;//导航初始化
    public bool isProtect;//是否为守护怪
    bool isRight = true;//守护怪是否向右走

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameMode = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Nav();
    }

    /// <summary>
    /// 守护怪和小怪地自动导航设置
    /// </summary>
    void Nav()
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
                nav.SetDestination(player.position);
            }
        }
        else if(gameMode.GetComponent<MyPacManGameModeBase>().gameState == GameState.Win)
        {
            nav.enabled = false;
        }
    }
}
