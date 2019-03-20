using UnityEngine;

public class Script : MonoBehaviour
{

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 50), "game_maoudamashii_6_dangeon15"))
        {
            AudioManager.Instance.PlayBGM("game_maoudamashii_6_dangeon15");
        }
        if (GUI.Button(new Rect(110, 100, 100, 50), "game_maoudamashii_6_dangeon19"))
        {
            AudioManager.Instance.PlayBGM("game_maoudamashii_6_dangeon19");
        }
        if (GUI.Button(new Rect(210, 100, 100, 50), "深遠の彼方"))
        {
            AudioManager.Instance.PlayBGM("深遠の彼方");
        }
        if (GUI.Button(new Rect(310, 100, 100, 50), "BGMSTOP"))
        {
            AudioManager.Instance.StopBGM();
        }
        /*if (GUI.Button(new Rect(10, 200, 100, 50), "ClearJingle"))
        {
            AudioManager.Instance.PlaySE("ClearJingle");
        }
        if (GUI.Button(new Rect(110, 200, 100, 50), "Jump"))
        {
            AudioManager.Instance.PlaySE("Jump");
        }
        if (GUI.Button(new Rect(210, 200, 100, 50), "Coin"))
        {
            AudioManager.Instance.PlaySE("Coin");
        }
        if (GUI.Button(new Rect(310, 200, 100, 50), "Select"))
        {
            AudioManager.Instance.PlaySE("Select");
        }
        if (GUI.Button(new Rect(410, 200, 100, 50), "SESTOP"))
        {
            AudioManager.Instance.StopSE();
        }*/

    }
}