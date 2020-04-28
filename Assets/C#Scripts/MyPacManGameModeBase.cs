using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏状态枚举
/// </summary>
public enum GameState
{
    Menu,
    Playing,
    Pause,
    Win,
    GameOver,
    Set
}

public class MyPacManGameModeBase : MonoBehaviour
{
    public GameState gameState;//枚举实例化
    
    bool isDie = false;//是否死亡
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Menu;
    }
    // Update is called once per frame
    void Update()
    {
        SetPause();
        CheckDie();
    }

    /// <summary>
    /// 设置暂停游戏状态
    /// </summary>
    void SetPause()
    {
        if (gameState == GameState.Pause | gameState == GameState.Playing)//游戏中才可以进入暂停
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameState == GameState.Pause)
                {
                    gameState = GameState.Playing;//返回游戏
                }
                else
                {
                    gameState = GameState.Pause;//进入暂停
                }
            }
        }
    }

    /// <summary>
    /// 检测是否死亡
    /// </summary>
    void CheckDie()
    {
        isDie = false;
    }

    /// <summary>
    /// 设置游戏中状态
    /// </summary>
    //public void SetModePlying()
    //{
    //    gameState = GameState.Playing;
    //    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MyAudioManager>().PlayAudio(5);
    //    this.GetComponent<MyAudioManager>().PlayLongAudio(0);
    //}

    /// <summary>
    /// 危局状态，执行相关操作
    /// </summary>
    public void SetWeiju()
    {
        this.GetComponent<MyAudioManager>().PlayLongAudio(11);

    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    //public void ExitGame()
    //{
    //    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MyAudioManager>().PlayAudio(5);
    //    //UnityEditor.EditorApplication.isPlaying = false;//打包前的退出
    //    Application.Quit();//打包后的退出
    //}
}
