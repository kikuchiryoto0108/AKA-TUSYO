using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip sound1; // 再生する音
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound1;
        audioSource.Play();

        // 音の長さに応じてオブジェクトを削除
        Destroy(gameObject, sound1.length);
    }
}