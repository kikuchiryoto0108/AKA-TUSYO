using UnityEngine;
using UnityEngine.SceneManagement;

public class sound2 : MonoBehaviour
{
    public AudioClip sound; // 再生する音
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.Play();

        // 音の長さに応じてオブジェクトを削除
        Destroy(gameObject, sound.length);
    }
}