using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultscript : MonoBehaviour
{
    [SerializeField] public static double CntTime1 = 0;//毎フレーム増える時間(小数点以下の二桁)
    [SerializeField] public static double CntTime2 = 0;//毎フレーム増える時間(一桁目と二桁目)
    [SerializeField] public static double CntTime3 = 0;//毎フレーム増える時間(三桁目と四桁目)
    [SerializeField] private Text RecordTimeText;    //リザルト　かかった時間表示
    [SerializeField] private Text differenceTimeText;//リザルト　かかった時間と最高記録の差を表示
    [SerializeField] private Text differenceTimeText2;
    [SerializeField] public GameObject objRecordTime;
    [SerializeField] public GameObject objNewRecordText1;
    [SerializeField] public GameObject objNewRecordText2;
    [SerializeField] public GameObject objNewRecordTime;
    [SerializeField] public GameObject objDelayRecordText1;
    [SerializeField] public GameObject objDelayRecordText2;
    [SerializeField] public GameObject objDelayRecordTime;
    // Start is called before the first frame update
    void Start()
    {
        this.objRecordTime = GameObject.Find("RecordTime");
        this.objNewRecordText1 = GameObject.Find("NewRecordText1");
        this.objNewRecordText2 = GameObject.Find("NewRecordText2");
        this.objNewRecordTime = GameObject.Find("NewRecordTime");
        this.objDelayRecordText1 = GameObject.Find("DelayRecordText1");
        this.objDelayRecordText2 = GameObject.Find("DelayRecordText2");
        this.objDelayRecordTime = GameObject.Find("DelayRecordTime");
        objRecordTime.GetComponent<Text>().enabled = false;
        objNewRecordText1.GetComponent<Text>().enabled = false;
        objNewRecordText2.GetComponent<Text>().enabled = false;
        objNewRecordTime.GetComponent<Text>().enabled = false;
        objDelayRecordText1.GetComponent<Text>().enabled = false;
        objDelayRecordText2.GetComponent<Text>().enabled = false;
        objDelayRecordTime.GetComponent<Text>().enabled = false;
    }
    //プレイヤーのスクリプト内でゴール時にResult関数を呼び出す↓
    //GameObject.Find("Canvas").SendMessage("Result");
    void Result()
    {   
        int i;
        CntTime1 = 0;
        CntTime2 = 0;
        CntTime3 = 0;
        for (i = 0; i < TimeText.Record; i++)
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
        RecordTimeText.text = "記録  "+ CntTime3.ToString() + "分" + CntTime2.ToString() + "秒" + CntTime1.ToString();

        objRecordTime.GetComponent<Text>().enabled = true;

        if (TimeText.BestRecord > TimeText.Record)
        {
            double Time1 = 0;
            double Time2 = 0;
            double Time3 = 0;
            for (i = 0; i < TimeText.BestRecord - TimeText.Record; i++)
            {
                Time1++;
                if (Time1 >= 100)
                {
                    Time1 = 0;
                    Time2++;
                }
                if (Time2 >= 60)
                {
                    Time2 = 0;
                    Time3++;
                }
            }
            differenceTimeText.text = Time3.ToString() + "分" + Time2.ToString() + "秒" + Time1.ToString();

            objNewRecordText1.GetComponent<Text>().enabled = true;
            objNewRecordText2.GetComponent<Text>().enabled = true;
            objNewRecordTime.GetComponent<Text>().enabled = true;
            
            //ハイスコア更新
            PlayerPrefs.SetInt(TimeText.key, (int)TimeText.Record);
            //ハイスコアを保存
        }
        else
        {
            double Time1 = 0;
            double Time2 = 0;
            double Time3 = 0;
            objNewRecordText1.GetComponent<Text>().enabled = false;
            objNewRecordText2.GetComponent<Text>().enabled = false;
            objNewRecordTime.GetComponent<Text>().enabled = false;
            for (i = 0; i < TimeText.Record - TimeText.BestRecord; i++)
            {
                Time1++;
                if (Time1 >= 100)
                {
                    Time1 = 0;
                    Time2++;
                }
                if (Time2 >= 60)
                {
                    Time2 = 0;
                    Time3++;
                }
            }
            differenceTimeText2.text = Time3.ToString() + "分" + Time2.ToString() + "秒" + Time1.ToString();

            objDelayRecordText1.GetComponent<Text>().enabled = true;
            objDelayRecordText2.GetComponent<Text>().enabled = true;
            objDelayRecordTime.GetComponent<Text>().enabled = true;

        }
     /*   // オブジェクトからTextコンポーネントを取得
        Text RecordTimeText = objRecordTime.GetComponent<Text>();
        // テキストの表示を入れ替える
        RecordTimeText.text = "000000";*/
        
    }
}
