using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeText : MonoBehaviour
{
    [SerializeField] public bool tmpResult = false;  //デバッグ用
    [SerializeField] public static double BestRecord ;//最高記録(1/100秒)
    [SerializeField] public static double Record ;//現在記録(1/100秒)
    [SerializeField] public double CntTime1 = 0;//毎フレーム増える時間(小数点以下の二桁)
    [SerializeField] public double CntTime2 = 0;//毎フレーム増える時間(一桁目と二桁目)
    [SerializeField] public double CntTime3 = 0;//毎フレーム増える時間(三桁目と四桁目)
    [SerializeField] private Text Time1Text;    //小数点以下の二桁の時間を表示する
    [SerializeField] private Text Time2Text;    //一桁目と二桁目の時間を表示する
    [SerializeField] private Text Time3Text;    //三桁目と四桁目の時間を表示する
    [SerializeField] private Text allTimeText;  //全体時間を表示する

    [SerializeField] private Goal goal;

    public static string key = "highScore";

    //[SerializeField] public GameObject objRecordTime;

    // Start is called before the first frame update
    void Start()
    {
        int i;

        BestRecord = PlayerPrefs.GetInt(key, 1999);//保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ6000になる
     // PlayerPrefs.DeleteAll(); //リセットコマンド(有効にすると現在ハイスコアリセット
       /* this.objRecordTime = GameObject.Find("GameObject");
        objRecordTime.GetComponent<Text>().enabled = false;*/
        
        for (i = 0; i < BestRecord; i++)
        {
            CntTime1++;
            if (CntTime1 >= 100)
            {
                CntTime1 = 0;
                CntTime2++;
            }
            if (CntTime2 >= 60)
            {
                CntTime2 = 0;
                CntTime3++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゴールした時プレイヤーのスクリプトのResultFlgをtrueにする
        //if (Player.ResultFlg == false)
        if (goal.GoalFlg == false)
        {
            if (BestRecord > Record)
            {
                CntTime1 -= 100 * Time.deltaTime;
                Record += 100 * Time.deltaTime;
                if (CntTime1 < 0)
                {
                    CntTime1 = 99;
                    CntTime2--;
                }
                if (CntTime2 < 0)
                {
                    CntTime2 = 60;
                    CntTime3--;
                }

                Time1Text.text = ((int)CntTime1).ToString();
                Time2Text.text = CntTime2.ToString();
                Time3Text.text = CntTime3.ToString();
                if (CntTime1 < 10)
                {
                    Time1Text.text = "0" + ((int)CntTime1).ToString();
                }
                if (CntTime2 < 10)
                {
                    Time2Text.text = "0" + CntTime2.ToString();
                }
                if (CntTime3 < 10)
                {
                    Time3Text.text = "0" + CntTime3.ToString();
                }
                allTimeText.text = "-" + Time3Text.text + ":" + Time2Text.text + "." + Time1Text.text;
            }
            else
            {
                CntTime1 += 100 * Time.deltaTime;
                Record += 100 * Time.deltaTime;
                if (CntTime1 >= 100)
                {
                    CntTime1 = 0;
                    CntTime2++;
                }
                if (CntTime2 >= 60)
                {
                    CntTime2 = 0;
                    CntTime3++;
                }

                Time1Text.text = ((int)CntTime1).ToString();
                Time2Text.text = CntTime2.ToString();
                Time3Text.text = CntTime3.ToString();
                if (CntTime1 < 10)
                {
                    Time1Text.text = "0" + ((int)CntTime1).ToString();
                }
                if (CntTime2 < 10)
                {
                    Time2Text.text = "0" + CntTime2.ToString();
                }
                if (CntTime3 < 10)
                {
                    Time3Text.text = "0" + CntTime3.ToString();
                }
                allTimeText.text = "+" + Time3Text.text + ":" + Time2Text.text + "." + Time1Text.text;
            }
        }
        else
        {
            GameObject.Find("Canvas").SendMessage("Result"); tmpResult = false;
        }
    }
}
