using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_EnemyLoitering : MonoBehaviour
{
    int[] moveArray = new int[42] {
        2, 2, 2, 2, 2, 2, 2, 2,
        4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
        8, 8, 8, 8, 8, 8, 8, 8,
        6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6
    };
    int cnt;
    int cntcnt;//cntを1増やす用のcnt
    float speed;
    private Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        int[] moveArray = new int[42] {
        2, 2, 2, 2, 2, 2, 2, 2,
        4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
        8, 8, 8, 8, 8, 8, 8, 8,
        6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6
    };
        /*int cnt = 0;
        int cntcnt = 0;
        float speed = 0.05f;*/
        Vector3 vector = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        cntcnt++;
        if (cntcnt >= 9)
        {
            cntcnt = 0;
            cnt++;
        }
        if (cnt >= moveArray.Length)
        {
            cnt = 0;
        }

        //Debug.Log(cnt);
        moveEnemy(moveArray[cnt]);//移動処理
    }

    void moveEnemy(int num)
    {
        switch (num)
        {
            case 2:
                vector.x = 0f;
                vector.y = -0.05f;
                break;
            case 4:
                vector.x = -0.05f;
                vector.y = 0f;
                break;
            case 6:
                vector.x = 0.05f;
                vector.y = 0f;
                break;
            case 8:
                vector.x = 0f;
                vector.y = 0.05f;
                break;
            default:
                break;
        }
        transform.position += new Vector3(vector.x, vector.y, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "R_Player")
        {
            Destroy(this.gameObject);
        }
    }

}
