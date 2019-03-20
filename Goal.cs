using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private bool R_PlayerInGoal;
    private bool B_PlayerInGoal;
    public bool GoalFlg;

    // Start is called before the first frame update
    void Start()
    {
        R_PlayerInGoal = false;
        B_PlayerInGoal = false;
        GoalFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(R_PlayerInGoal == true && B_PlayerInGoal == true)
        {
            GoalFlg = true;
            Debug.Log("ゲームクリア―");
            //SceneManager.LoadScene("GameClear");
        }
    }

    //両方がゴールしたら
    void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "R_Player")
        {
            R_PlayerInGoal = true;
            //Debug.Log("Rめう");
        }
        if (LayerMask.LayerToName(other.gameObject.layer) == "B_Player")
        {
            B_PlayerInGoal = true;
            //Debug.Log("Bめう");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "R_Player")
        {
            R_PlayerInGoal = false;
            //Debug.Log("Rめうめう");
        }
        if (LayerMask.LayerToName(other.gameObject.layer) == "B_Player")
        {
            B_PlayerInGoal = false;
            //Debug.Log("Bめうめう");
        }
    }

}
