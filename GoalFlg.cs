using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlg : MonoBehaviour
{
    [SerializeField] private GameObject[] R_Enemy;
    [SerializeField] private GameObject[] B_Enemy;
    private bool R_EnemyDestoryFlg;
    private bool B_EnemyDestoryFlg;

    // Start is called before the first frame update
    void Start()
    {
        R_EnemyDestoryFlg = false;
        B_EnemyDestoryFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<R_Enemy.Length; i++)
        {
            if (R_Enemy[i] != null)
            {
                break;
            }
            if (i == R_Enemy.Length - 1)
            {
                R_EnemyDestoryFlg = true;
            }
        }

        for (int i = 0; i < B_Enemy.Length; i++)
        {
            if (B_Enemy[i] != null)
            {
                break;
            }
            if (i == B_Enemy.Length - 1)
            {
                B_EnemyDestoryFlg = true;
            }
        }

        if (R_EnemyDestoryFlg == true && B_EnemyDestoryFlg == true)
        {
            Debug.Log("めうめうめう");
        }

    }
}
