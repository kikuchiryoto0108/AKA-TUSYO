using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject soundPrefab; // ①で作成したオブジェクトのPrefab

    void Update()
    {
        if (VarScripts.isDragging == false) // ドラッグしていなかったら
        {
            if (CompareTag("OBJECT")) // 自身のタグがOBJECTだったら
            {
                VarScripts.ACTION = true; // アクションをオン

                Instantiate(soundPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject); // このオブジェクトを消す
            }
            else if (CompareTag("object")) // 自身のタグがobjectだったら
            {
                VarScripts.ACTION = false; // アクションをオフ
            }
        }

        Debug.Log(VarScripts.ACTION);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Action")) // Actionのタグに当たったら
        {
            if (CompareTag("object")) // このオブジェクトのタグがobjcetだったら
            {
                gameObject.tag = "OBJECT"; // タグをOBJECTに変更
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Action")) // Actionのタグから離れたら
        {
            if (CompareTag("OBJECT")) // このオブジェクトのタグがOBJECTだったら
            {
                gameObject.tag = "object"; // タグをobjectに戻す
            }
        }
    }
}