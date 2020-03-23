using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MyVideoManager : MonoBehaviour
{
    GameObject gameMode;//传递游戏模式
    public VideoClip[] vc;
    VideoPlayer vPlayer;
    int i = 0;
    float aphle = 0.001f;
    public GameObject cameras;
    public GameObject magicUI;
    //public GameObject magicUI;
    // Start is called before the first frame update
    void Start()
    {
        gameMode = GameObject.Find("Camera");
        vPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        CloseVideo(0);
    }

    /// <summary>
    /// 播放视频
    /// </summary>
    public void PlayVideo(int i)
    {
        aphle = 1;
        cameras.GetComponent<MyCameraManage>().ShowCamera(1);
        vPlayer.targetCameraAlpha = aphle;
        vPlayer.clip = vc[i];
        vPlayer.Play();
    }

    //播放完成接口
    void CloseVideo(int i)
    {
        vPlayer.loopPointReached += EndReached;
    }

    //播放完成所有要做的事情
    void EndReached(VideoPlayer vPlayer)
    {
        vPlayer.targetCameraAlpha = aphle;
        cameras.GetComponent<MyCameraManage>().ShowCamera(0);
        magicUI.GetComponent<MyMagicSkillManager>().TuDun();
        gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Playing;
        //this.transform.localPosition = new Vector3(-1800f, 0, 0);
    }

    //土遁按钮事件
    public void PlayTuDun()
    {
        PlayVideo(0);
        gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Pause;
    }

}
