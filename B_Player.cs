using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Player : MonoBehaviour
{
    public static B_Player instance;

    //移動
    private float move_x;
    private float move_y;
    private float speed;
    private float defaultSpeed;

    //プレイヤー同士の当たり判定
    private bool playerHit_up;
    private bool playerHit_right;
    private bool playerHit_down;
    private bool playerHit_left;

    //バフ
    private bool statusUpFlg;

    //スタン
    private bool enemyHitFlg;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        move_x = 0.0f;
        move_y = 0.0f;
        defaultSpeed = 0.035f;
        speed = defaultSpeed;

        playerHit_up = false;
        playerHit_right = false;
        playerHit_down = false;
        playerHit_left = false;

        statusUpFlg = false;
        enemyHitFlg = false;

    }

    // Update is called once per frame
    void Update()
    {
        //初期化
        move_x = 0.0f;
        move_y = 0.0f;

        //移動
        if (enemyHitFlg == false)
        {
            PlayerMove();

            if(statusUpFlg == false)
            {
                //プレイヤー同士の当たり判定
                PlayerHit();
            }
        }
        //硬直
        else
        {
            //スタン
        }

        //速度アップ
        if (statusUpFlg == true)
        {
            //バフ
        }

        Debug.Log("buffのフラグ"+statusUpFlg);
    }

    //移動操作
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move_y = speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move_x = speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move_y = -speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move_x = -speed;
        }

        //移動の加算
        transform.position += new Vector3(move_x, move_y, 0);

    }

    //プレイヤー同士の当たり判定
    void PlayerHit()
    {
        playerHit_up = Physics2D.Raycast(
        transform.position, Vector2.up,
        0.6f, 1 << LayerMask.NameToLayer("R_Player"));

        playerHit_right = Physics2D.Raycast(
        transform.position, Vector2.right,
        0.6f, 1 << LayerMask.NameToLayer("R_Player"));

        playerHit_down = Physics2D.Raycast(
        transform.position, Vector2.down,
        0.6f, 1 << LayerMask.NameToLayer("R_Player"));

        playerHit_left = Physics2D.Raycast(
        transform.position, Vector2.left,
        0.6f, 1 << LayerMask.NameToLayer("R_Player"));

        //当たっているなら
        if (playerHit_up || playerHit_right || playerHit_down || playerHit_left)
        {
            statusUpFlg = true;       //バフがかかる
        }

    }

}
