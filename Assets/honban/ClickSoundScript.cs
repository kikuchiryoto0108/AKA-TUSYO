using UnityEngine;

public class ClickSoundScript : MonoBehaviour
{
    public AudioClip clickSound;  // アタッチするAudioClip

    private AudioSource audioSource;

    void Start() {
        // AudioSourceコンポーネントを追加し、AudioClipを設定
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnMouseDown() {
        // クリックしたときにAudioClipを再生
        Debug.Log("ぼくは航空管制官");
        audioSource.clip = clickSound;
        audioSource.Play();
    }
}
