using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    //Startボタンを押したとき
    //MainGameシーンに移動
    public void StartButton()
    {   
        SceneManager.LoadScene("InGame");
    }

    //Manualボタンを押したとき
    //Manualシーンに移動
    public void ManualButton()
    {
        SceneManager.LoadScene("Manual");
    }

    //Backボタンを押したとき
    //Titleシーンに移動
    public void BackButton()
    {
        SceneManager.LoadScene("Title");
    }


}
