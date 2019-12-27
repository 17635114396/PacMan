using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class navigation : MonoBehaviour
    {
 //   public Text loading;
   
   
    public void goto_sc1()
        {
        UnityEngine.SceneManagement.SceneManager.LoadScene("game1_over");
      // // loading.text = " Loading ................";
        }
  
    public void goto_sc2()
        {
     
        UnityEngine.SceneManagement.SceneManager.LoadScene("game_1");
        }
    public void goto_sc1_2()
        {

        UnityEngine.SceneManagement.SceneManager.LoadScene("game2_over");
        }
    public void goto_sc3()
        {

        UnityEngine.SceneManagement.SceneManager.LoadScene("game_2");
        }
  
 
    public void quit()
        {
        Application.Quit();
        }
    }
