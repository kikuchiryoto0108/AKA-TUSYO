using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemScript : MonoBehaviour {
    void Awake() {
        // シーン内のすべてのEventSystemを取得
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

        if (eventSystems.Length == 0) {
            // EventSystemが存在しない場合、新しいEventSystemを追加
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
        else if (eventSystems.Length > 1) {
            // 複数のEventSystemが存在する場合、追加のEventSystemを削除または無効化
            for (int i = 1; i < eventSystems.Length; i++) {
                Destroy(eventSystems[i].gameObject);
            }
        }
    }
}