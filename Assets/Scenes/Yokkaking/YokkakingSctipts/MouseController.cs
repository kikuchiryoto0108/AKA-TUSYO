using UnityEngine;

public class MouseController : MonoBehaviour
{
    private GameObject draggableObject; // 現在ドラッグ中のオブジェクト
    private Vector2 offset; // マウスとオブジェクトの距離の差分

    private Vector2 startPosition; // 初期位置を保存する変数
    private Vector2 currentPosition; // 現在の位置を取得

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // マウスのワールド座標
        currentPosition = draggableObject ? draggableObject.transform.position : Vector2.zero; // 現在の位置

        // 左クリックを押した瞬間
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // マウスからrayを発射

            if (hit.collider != null && hit.collider.CompareTag("object")) // クリックしたオブジェクトが"object"タグか
            {
                draggableObject = hit.collider.gameObject; // ドラッグ対象オブジェクトを設定
                VarScripts.isDragging = true; // ドラッグ中
                offset = (Vector2)draggableObject.transform.position - mousePosition; // クリック位置との差分を取得

                startPosition = hit.transform.position; // 初期値位置を触れたオブジェクトに設定
            }
        }

        // 左クリックを押し続けている間
        if (Input.GetMouseButton(0) && VarScripts.isDragging && draggableObject != null)
        {
            draggableObject.transform.position = mousePosition + offset; // マウスの位置に追従
        }

        // 左クリックを離したとき
        if (Input.GetMouseButtonUp(0))
        {
            if (VarScripts.isDragging && draggableObject != null)
            {
                VarScripts.isDragging = false; // ドラッグ中止

                if (draggableObject.CompareTag("object") && currentPosition != startPosition) // 初期位置じゃなければ
                {
                    ResetPosition(); // 初期位置に戻す
                }
                draggableObject = null; // ドラッグ対象オブジェクトをリセット
            }
        }
    }

    // 初期位置に戻る関数
    void ResetPosition()
    {
        if (draggableObject != null)
        {
            draggableObject.transform.position = startPosition; // 初期位置に戻る
        }
    }
}
