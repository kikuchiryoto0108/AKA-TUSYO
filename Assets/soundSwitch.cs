using UnityEngine;
using System.Collections;

public class SoundSwitch : MonoBehaviour {
    public GameObject soundPrefab; // ①で作成したオブジェクトのPrefab

    void OnMouseDown() {
        GameObject soundObject = Instantiate(soundPrefab, transform.position, Quaternion.identity);
        DontDestroyOnLoad(soundObject); // 生成したオブジェクトをシーンをまたいで保持

        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        if (audioSource != null) {
            StartCoroutine(CheckIfAudioFinished(audioSource, soundObject));
        }
        else {
            Debug.LogWarning("音声オブジェクトにAudioSourceがアタッチされていません。");
        }
    }

    private IEnumerator CheckIfAudioFinished(AudioSource audioSource, GameObject soundObject) {
        // 音声が再生中である限り待機
        while (audioSource.isPlaying) {
            yield return null;
        }

        // 音声の再生が終了したらオブジェクトを削除
        Destroy(soundObject);
    }
}