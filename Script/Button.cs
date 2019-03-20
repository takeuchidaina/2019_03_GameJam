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

    //Titleボタンを押したとき
    //Titleシーンに移動
    public void TitleButton()
    {
        SceneManager.LoadScene("Title");
    }

    //NEXTボタン
    //次のシーンに移動
    public void NextButton()
    {
        SceneManager.LoadScene("Manual_2");
    }

    public void NextButton_2()
    {
        SceneManager.LoadScene("Manual_3");
    }

    //BACKボタン
    //前のシーンに移動
    public void BackButton()
    {
        SceneManager.LoadScene("Manual");
    }

    public void BackButton_2()
    {
        SceneManager.LoadScene("Manual_2");
    }
}
