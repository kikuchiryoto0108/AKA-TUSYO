using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {
    public string SceneName;

    void OnMouseDown() {
        SceneManager.LoadScene(SceneName);
    }
}