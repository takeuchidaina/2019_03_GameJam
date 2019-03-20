using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player : MonoBehaviour
{
    public static R_Player instance;

    private BaseCorutine buff;
    private BaseCorutine stan;

    public SkillEffect effect; 

    //移動
    private float move_x;
    private float move_y;
    private float speed;
    private float defaultSpeed;
    private float buffSpeed;

    //プレイヤー同士の当たり判定
    private bool playerHit_up;
    private bool playerHit_right;
    private bool playerHit_down;
    private bool playerHit_left;

    //バフ
    private bool statusUpFlg;
    private float buffTime;

    //スタン
    private bool enemyHitFlg;
    private float stanTime;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        buff = new BaseCorutine();
        stan = new BaseCorutine();

        move_x = 0.0f;
        move_y = 0.0f;
        buffSpeed = 0.04f;
        defaultSpeed = 0.03f;
        speed = defaultSpeed;

        playerHit_up = false;
        playerHit_right = false;
        playerHit_down = false;
        playerHit_left = false;

        statusUpFlg = false;
        buffTime = 10.0f;
        enemyHitFlg = false;
        stanTime = 3.0f;

        effect.Init();

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

            if (statusUpFlg == false)
            {
                //プレイヤー同士の当たり判定
                PlayerHit();
            }
        }

        //速度アップ
        if (statusUpFlg == true)
        {
            if (buff.IsProcess)
            {
                return;
            }
            else
            {
                StartCoroutine(buff.OnTimeAction(StatusUpStart, StatusUpEnd, buffTime));
            }
        }

        //スタン
        if (enemyHitFlg == true)
        {
            if (stan.IsProcess)
            {
                return;
            }
            else
            {
                StartCoroutine(buff.OnTimeAction(StanStart, StanEnd, stanTime));
            }
        }
    }

    void PlayerMove()
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

        //移動の加算
        transform.position += new Vector3(move_x, move_y, 0);
    }

    //プレイヤー同士の当たり判定
    void PlayerHit()
    {
        playerHit_up = Physics2D.Raycast(
        transform.position, Vector2.up,
        0.5f, 1 << LayerMask.NameToLayer("B_Player"));

        playerHit_right = Physics2D.Raycast(
        transform.position, Vector2.right,
        0.5f, 1 << LayerMask.NameToLayer("B_Player"));

        playerHit_down = Physics2D.Raycast(
        transform.position, Vector2.down,
        0.5f, 1 << LayerMask.NameToLayer("B_Player"));

        playerHit_left = Physics2D.Raycast(
        transform.position, Vector2.left,
        0.5f, 1 << LayerMask.NameToLayer("B_Player"));

        //当たっているなら
        if (playerHit_up || playerHit_right || playerHit_down || playerHit_left)
        {
            statusUpFlg = true;
        }

    }

    //バフ開始
    void StatusUpStart()
    {
        speed = buffSpeed;
        effect.Init();
        effect.CutIn();
    }

    //バフ終了
    void StatusUpEnd()
    {
        speed = defaultSpeed;

        statusUpFlg = false;
    }

    //スタン開始
    void StanStart()
    {
        enemyHitFlg = true;
    }

    //スタン終了
    void StanEnd()
    {
        enemyHitFlg = false;
    }
    

    //敵との当たり判定
    void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "B_Enemy")
        {
            enemyHitFlg = true;
        }
    }
}
