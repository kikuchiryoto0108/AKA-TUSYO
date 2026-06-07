using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject TOUCH1; // 表示・非表示を切り替えたいオブジェクト1
    public GameObject TOUCH2; // 表示・非表示を切り替えたいオブジェクト2

    public bool action = false; // 初期設定

    public AudioClip ShutterSound; // 音を鳴らすやつ
    private AudioSource audioSource;


    void Start()
    {
        TOUCH1.gameObject.SetActive(true); // TOUCH1を表示
        TOUCH2.gameObject.SetActive(false); // TOUCH2を非表示

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
                // ヒットしたオブジェクトがtouch1のタグを持っていて　かつ　TOUCH1に設定されているオブジェクト　かつ　TOUCH2が非表示なら
                if (hit.collider.CompareTag("touch1") && hit.collider.gameObject == TOUCH1.gameObject && TOUCH2.activeSelf == false)
                {
                    TOUCH1.gameObject.SetActive(false); // TOUCH1を非表示する
                    TOUCH2.gameObject.SetActive(true); // TOUCH2を表示する

                    audioSource.clip = ShutterSound; // 音を鳴らす
                    audioSource.Play(); // 音を鳴らす

                    if (action) // actionがtrueなら
                    {
                        VarScripts.ACTION = true; // ACTIONをtrueにする
                    }

                }// ヒットしたオブジェクトがtouch2のタグを持っていて　かつ　TOUCH2に設定されているオブジェクト　かつ　TOUCH1が非表示なら
                else if (hit.collider.CompareTag("touch2") && hit.collider.gameObject == TOUCH2.gameObject && TOUCH1.activeSelf == false)
                {
                    TOUCH1.gameObject.SetActive(true); // TOUCH1を表示する
                    TOUCH2.gameObject.SetActive(false); // TOUCH2を非表示する

                    audioSource.clip = ShutterSound; // 音を鳴らす
                    audioSource.Play(); // 音を鳴らす

                    if (action)
                    {
                        VarScripts.ACTION = false; // ACTIONをfalseにする
                    }
                }
            }
        }
    }
}
