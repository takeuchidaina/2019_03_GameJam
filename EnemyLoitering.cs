using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoitering : MonoBehaviour
{

    int[] moveArray = new int[20] { 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 8, 8, 8, 8, 8, 8, 6, 6, 6, 6 };
    int cnt;
    int cntcnt;
    float speed;
    private Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        int[] moveArray = new int[20] { 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 8, 8, 8, 8, 8, 8, 6, 6, 6, 6 };
        int cnt = 0;
        int cntcnt = 0;
        float speed = 0.05f;
        Vector3 vector= new Vector3(0f,0f,0f);
    }

// Update is called once per frame
void Update()
    {
        cntcnt++;
        if (cntcnt >= 10)
        {
            cntcnt = 0;
            cnt++;
        }        
        Debug.Log(cnt);
        moveEnemy(moveArray[cnt]);
        if (cnt > 18)
        {
            cnt = 0;
        }
    }

    void moveEnemy(int num)
    {
        switch (num)
        {
            case 2:
                vector.x = 0f;
                vector.y = -0.1f;
                break;
            case 4:
                vector.x = -0.1f;
                vector.y = 0f;
                break;
            case 6:
                vector.x = 0.1f;
                vector.y = 0f;
                break;
            case 8:
                vector.x = 0f;
                vector.y = 0.1f;
                break;
            default:
                break;
        }
        transform.position += new Vector3(vector.x,vector.y,0f);
    }
}
