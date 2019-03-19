using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Player : MonoBehaviour
{
    public static B_Player instance;

    private float move_x;
    private float move_y;
    private float speed;
    private bool playerHit_up;
    private bool playerHit_right;
    private bool playerHit_down;
    private bool playerHit_left;

    private bool statusUpFlg;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        move_x = 0.0f;
        move_y = 0.0f;
        speed = 0.02f;

        playerHit_up = false;
        playerHit_right = false;
        playerHit_down = false;
        playerHit_left = false;
        statusUpFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        move_x = 0;
        move_y = 0;

        PlayerMove();

        PlayerHit();

        if(statusUpFlg == true)
        {
            StatusUpCoolTime();
        }

    }

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

        if (playerHit_up || playerHit_right || playerHit_down || playerHit_left)
        {
            Debug.Log("当たっている");
            PlayerStatusUp();
        }
        else
        {
            Debug.Log("当たってない");
        }
    }

    //バフ
    void PlayerStatusUp()
    {

        if(statusUpFlg == false)
        {
            statusUpFlg = true;
            speed = 0.05f;
        }

    }

    //バフのクールタイム
    void StatusUpCoolTime()
    {
        //CT 15秒
        //終わったらフラグをfalseにしてスピードを0.02fにする
        if (0 >= 15.0f - Time.time)
        {
            Debug.Log("CT終了");
            speed = 0.02f;
        }
    }
}
