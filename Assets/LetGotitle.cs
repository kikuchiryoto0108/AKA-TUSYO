using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LetGotitle : MonoBehaviour {
    void Start() {
        StartCoroutine(GoToTitleScene());
    }

    void Update() {

    }

    IEnumerator GoToTitleScene() {
        yield return new WaitForSeconds(1);  // 1•b‘Ò‹@
        SceneManager.LoadScene("TitleScene");  // TitleScene‚ÉˆÚ“®
        Destroy(this);
    }
}