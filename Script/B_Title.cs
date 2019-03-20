using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Title : MonoBehaviour
{
    public GameObject R_Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        pos.x += 0.01f;    // x座標へ0.01加算

        if (pos.x >= 7.0)
        {
            pos.x = -7;
            myTransform.position = pos;

            Change();
        }

        myTransform.position = pos;  // 座標を設定
    }
    public void Change()
    {
        Instantiate(R_Player, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

