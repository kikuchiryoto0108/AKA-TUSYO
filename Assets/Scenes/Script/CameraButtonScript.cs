using UnityEngine;

public class CameraButtonScript : MonoBehaviour {
    private SubCameraScript subCameraScript; // 他のScriptへの参照

    void Start() {
        // SubCameraScriptコンポーネントを持つオブジェクトを検索して取得
        subCameraScript = FindObjectOfType<SubCameraScript>();
    }

    void OnMouseDown() {
        // オブジェクトがクリックされたときに呼び出される
        Debug.Log("オブジェクトがクリックされました");

        if (subCameraScript != null) {
            subCameraScript.SetSubCameraObjectsActive();
            Debug.Log("SetSubCameraObjectsActiveが呼び出されました");
        } else {
            Debug.LogError("subCameraScriptが見つかりませんでした");
        }
    }
}