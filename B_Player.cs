using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Player : MonoBehaviour
{
    public static B_Player instance;

    private float move_x;
    private float move_y;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        move_x = 0.0f;
        move_y = 0.0f;
        speed = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        move_x = 0;
        move_y = 0;
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("上");
            move_y = speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("右");
            move_x = speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("下");
            move_y = -speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("左");
            move_x = -speed;
        }

        transform.position += new Vector3(move_x, move_y, 0);

    }
}
