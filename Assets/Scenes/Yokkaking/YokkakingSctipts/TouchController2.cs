using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController2 : MonoBehaviour
{
    public GameObject TOUCH3; // 表示・非表示を切り替えたいオブジェクト1
    public GameObject TOUCH4; // 表示・非表示を切り替えたいオブジェクト2

    public bool action2 = false; // 初期設定

    public AudioClip ShutterSound; // 音を鳴らすやつ
    private AudioSource audioSource;


    void Start()
    {
        TOUCH3.gameObject.SetActive(true); // TOUCH1を表示
        TOUCH4.gameObject.SetActive(false); // TOUCH2を非表示

        audioSource = gameObject.AddComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // マウスのワールド座標

        // 左クリックを押した瞬間
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // マウスからrayを発射

            if (hit.collider != null)
            {
                // ヒットしたオブジェクトがtouch3のタグを持っていて　かつ　TOUCH3に設定されているオブジェクト　かつ　TOUCH4が非表示なら
                if (hit.collider.CompareTag("touch3") && hit.collider.gameObject == TOUCH3.gameObject && TOUCH4.activeSelf == false)
                {
                    TOUCH3.gameObject.SetActive(false); // TOUCH1を非表示する
                    TOUCH4.gameObject.SetActive(true); // TOUCH2を表示する

                    audioSource.clip = ShutterSound; // 音を鳴らす
                    audioSource.Play(); // 音を鳴らす

                    if (action2) // action2がtrueなら
                    {
                        VarScripts.ACTION2 = true; // ACTIONをtrueにする
                    }

                }// ヒットしたオブジェクトがtouch4のタグを持っていて　かつ　TOUCH4に設定されているオブジェクト　かつ　TOUCH3が非表示なら
                else if (hit.collider.CompareTag("touch4") && hit.collider.gameObject == TOUCH4.gameObject && TOUCH3.activeSelf == false)
                {
                    TOUCH3.gameObject.SetActive(true); // TOUCH1を表示する
                    TOUCH4.gameObject.SetActive(false); // TOUCH2を非表示する

                    audioSource.clip = ShutterSound; // 音を鳴らす
                    audioSource.Play(); // 音を鳴らす

                    if (action2)
                    {
                        VarScripts.ACTION2 = false; // ACTIONをfalseにする
                    }
                }
            }
        }
    }
}