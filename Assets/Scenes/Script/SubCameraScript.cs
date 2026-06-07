using UnityEngine;

public class SubCameraScript : MonoBehaviour {
    private GameObject subCameraObject;
    public static bool isSubCameraActive;

    void Start() {
        // タグを使ってすべてのカメラオブジェクトを取得
        subCameraObject = GameObject.FindGameObjectWithTag("SubCamera");

        // 初期設定として SubCamera を無効にする
        isSubCameraActive = false;
        SetSubCameraObjectsActive();
    }

    public void SetSubCameraObjectsActive() {
        bool isActive = isSubCameraActive;
        isSubCameraActive = !isSubCameraActive;
        GameObject obj = subCameraObject;
        obj.SetActive(isActive);
    }
}
