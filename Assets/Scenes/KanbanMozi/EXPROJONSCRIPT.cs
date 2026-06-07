using UnityEngine;

public class EXPROJONSCRIPT : MonoBehaviour {
    private GameObject nextstage;
    private GameObject clear;

    private CheakGoalScript cheakGoalScript; // 他のScriptへの参照
    private CheakGoalScript2 cheakGoalScript2; // 他のScriptへの参照

    void Start() {
        // タグを使ってすべての対応するオブジェクトを取得
        nextstage = GameObject.FindGameObjectWithTag("NEXTSTAGE");
        clear = GameObject.FindGameObjectWithTag("CLEAR");

        cheakGoalScript = FindObjectOfType<CheakGoalScript>();
        cheakGoalScript2 = FindObjectOfType<CheakGoalScript2>();

        if (clear != null) {
            clear.SetActive(false);
        }
        else {
            Debug.LogError("CLEARタグのオブジェクトが見つかりませんでした。");
        }
    }

    void Update() {
        if (cheakGoalScript == null) {
            // CheakGoalScriptがまだ見つかっていない場合、再度検索を試みる
            cheakGoalScript = FindObjectOfType<CheakGoalScript>();
        }

        if (cheakGoalScript2 == null) {
            // CheakGoalScript2がまだ見つかっていない場合、再度検索を試みる
            cheakGoalScript2 = FindObjectOfType<CheakGoalScript2>();
        }

        if (cheakGoalScript != null && cheakGoalScript.nextScene == "TitleScene") {
            PerformSpecificAction();
        }
        else if (cheakGoalScript2 != null && cheakGoalScript2.nextScene == "TitleScene") {
            PerformSpecificAction();
        }
    }

    void PerformSpecificAction() {
        // NEXTSTAGEタグのオブジェクトを無効化
        if (nextstage != null) {
            nextstage.SetActive(false);
            Debug.Log("NEXTSTAGEタグのオブジェクトを無効化しました。");
        }
        else {
            Debug.LogError("NEXTSTAGEタグのオブジェクトが見つかりませんでした。");
        }

        // CLEARタグのオブジェクトを有効化
        if (clear != null) {
            clear.SetActive(true);
            Debug.Log("CLEARタグのオブジェクトを有効化しました。");
        }
        else {
            Debug.LogError("CLEARタグのオブジェクトが見つかりませんでした。");
        }
    }
}