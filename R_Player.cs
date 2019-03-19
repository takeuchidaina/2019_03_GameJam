using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player : MonoBehaviour
{
    public static R_Player instance;

    private float move_x;
    private float move_y;
    private float speed;
    private float CT;
    private bool playerHit_up;
    private bool playerHit_right;
    private bool playerHit_down;
    private bool playerHit_left;
    private bool enemyHit_up;
    private bool enemyHit_right;
    private bool enemyHit_down;
    private bool enemyHit_left;
    private bool statusUpFlg;
    private bool enemyHitFlg;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        move_x = 0.0f;
        move_y = 0.0f;
        speed = 0.035f;  //スピード

        CT = 15.0f;     //クールタイム

        playerHit_up = false;
        playerHit_right = false;
        playerHit_down = false;
        playerHit_left = false;
        enemyHit_up = false;
        enemyHit_right = false;
        enemyHit_down = false;
        enemyHit_left = false;

        statusUpFlg = false;    //バフがかかっているかどうか
        enemyHitFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        move_x = 0.0f;
        move_y = 0.0f;

        PlayerMove();

        PlayerHit();

        if (statusUpFlg == true)
        {
            StatusUpCoolTime();
        }

    }

    //十字移動
    void PlayerMove()
    {
        if (enemyHitFlg == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                move_y = speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                move_x = speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                move_y = -speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                move_x = -speed;
            }
        }

        transform.position += new Vector3(move_x, move_y, 0);

    }

    //プレイヤー同士の当たり判定
    void PlayerHit()
    {
        if(statusUpFlg == false)
        {
            playerHit_up = Physics2D.Raycast(
            transform.position, Vector2.up,
            0.6f, 1 << LayerMask.NameToLayer("B_Player"));

            playerHit_right = Physics2D.Raycast(
            transform.position, Vector2.right,
            0.6f, 1 << LayerMask.NameToLayer("B_Player"));

            playerHit_down = Physics2D.Raycast(
            transform.position, Vector2.down,
            0.6f, 1 << LayerMask.NameToLayer("B_Player"));

            playerHit_left = Physics2D.Raycast(
            transform.position, Vector2.left,
            0.6f, 1 << LayerMask.NameToLayer("B_Player"));


            if (playerHit_up || playerHit_right || playerHit_down || playerHit_left)
            {
                Debug.Log("当たっている");
                PlayerStatusUp();       //バフがかかる
            }
            else
            {
                Debug.Log("当たってない");
            }
        }
        if(enemyHitFlg == false)
        {
            enemyHit_up = Physics2D.Raycast(
            transform.position, Vector2.up,
            0.6f, 1 << LayerMask.NameToLayer("B_Enemy"));

            enemyHit_right = Physics2D.Raycast(
            transform.position, Vector2.right,
            0.6f, 1 << LayerMask.NameToLayer("B_Enemy"));

            enemyHit_down = Physics2D.Raycast(
            transform.position, Vector2.down,
            0.6f, 1 << LayerMask.NameToLayer("B_Enemy"));

            enemyHit_left = Physics2D.Raycast(
            transform.position, Vector2.left,
            0.6f, 1 << LayerMask.NameToLayer("B_Enemy"));

            if(enemyHit_up || enemyHit_right || enemyHit_down || enemyHit_left)
            {
                enemyHitFlg = true;
            }
        }


    }

    //バフ
    void PlayerStatusUp()
    {
        statusUpFlg = true;
        speed = 0.05f;      //バフ
    }

    //バフのクールタイム
    void StatusUpCoolTime()
    {
        //CT 15秒
        if (0 >= CT - Time.time)
        {
            Debug.Log("CT終了");
            speed = 0.035f;
            statusUpFlg = false;
            CT = 10.0f;
        }
    }

}
