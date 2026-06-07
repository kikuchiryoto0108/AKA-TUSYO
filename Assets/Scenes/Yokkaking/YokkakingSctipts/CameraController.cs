using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool cameraOn;

    private SubCameraScript subCameraScript; // 他のScriptへの参照

    void Start()
    {
        // SubCameraScriptコンポーネントを持つオブジェクトを検索して取得
        subCameraScript = FindObjectOfType<SubCameraScript>();

        cameraOn = false;
    }

    public void ConecctSetSubCameraObjectsActive()
    {
        subCameraScript.SetSubCameraObjectsActive();
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // マウスのワールド座標

        // 左クリックを押した瞬間
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // マウスからrayを発射

            if (hit.collider.CompareTag("camera") && cameraOn == false) // 触ったオブジェクトがcamera　かつ　cameraOnがtrueなら
            {
                cameraOn = true;
                subCameraScript.SetSubCameraObjectsActive(); // アクティブ
            }
            else if (hit.collider.CompareTag("camera") && cameraOn == true)
            {
                cameraOn = false;
                Debug.Log("aa");
                subCameraScript.SetSubCameraObjectsActive(); // アクティブ
            }
        }
    }
}