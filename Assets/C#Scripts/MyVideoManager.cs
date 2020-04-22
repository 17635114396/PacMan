using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MyVideoManager : MonoBehaviour
{
    GameObject gameMode;//传递游戏模式
    public VideoClip[] vc;
    VideoPlayer vPlayer;
    float aphle = 0.001f;
    public GameObject cameras;
    public GameObject magicUI;
    public int i;//参数判断执行哪一个技能
    public Text[] magicText;
    public Button magicButton;
    public int beginX;//文字起始位置
    public int endX;//文字挺住位置
    public int speedX;//文字移动速度

    //public GameObject magicUI;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;//初始化技能状态为空
        gameMode = GameObject.Find("Camera");
        vPlayer = GetComponent<VideoPlayer>();
        vPlayer.loopPointReached += EndReached;//播放完成执行接口
        magicButton.transform.position= new Vector3(beginX, 166, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 播放视频
    /// </summary>
    public void PlayVideo(int i)
    {
        aphle = 0.5f;//透明度
        cameras.GetComponent<MyCameraManage>().ShowCamera(1);//相机切换
        vPlayer.targetCameraAlpha = aphle;
        vPlayer.clip = vc[i];//视频片段
        vPlayer.Play();//播放该片段
        if (i >= 1)//播放文字
        {
            magicText[i - 1].GetComponent<Text>().enabled = true;//显示文字
            StartCoroutine(StartMoveMagicText());//移动文字
        }
    }

    private IEnumerator StartMoveMagicText()
    {
        while (magicButton.transform.position.x >= endX)
        {
            magicButton.transform.position += new Vector3(-2*speedX, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }
    

    //播放完成所有要做的事情
    void EndReached(VideoPlayer video)
    {
        magicButton.transform.position = new Vector3(beginX, 0, 0);//技能文字隐藏
        if (i == 1)
        {
            TuDunEndReached();
        }
        else if (i == 2)
        {
            KuWuEndReached();
        }
        else if (i == 3) {
            XianRenEndReached();
        }
        //。。。其他技能函数endreach接口
    }

    /// <summary>
    /// 各个技能执行完事件汇总接口
    /// </summary>
    void TuDunEndReached()
    {
        CameraReturn();
        magicUI.GetComponent<MyMagicSkillManager>().TuDun();
    }
    void KuWuEndReached() {
        CameraReturn();
        magicText[0].GetComponent<Text>().enabled = false;
        
    }
    void XianRenEndReached() {
        CameraReturn();
        magicText[1].GetComponent<Text>().enabled = false;
    }

    /// <summary>
    /// 恢复技能，时间和相机渲染
    /// </summary>
    void CameraReturn() {
        i = 0;//技能标签归零
        vPlayer.targetCameraAlpha = aphle;
        cameras.GetComponent<MyCameraManage>().ShowCamera(0);
        gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Playing;
    }

    //土遁按钮事件
    public void PlayTuDun()
    {
        i = 1;//更改当前技能为1
        PlayVideo(0);
        gameMode.GetComponent<MyPacManGameModeBase>().gameState = GameState.Pause;
    }

}
