using UnityEngine;

public class BGM : MonoBehaviour
{
    private static BGM instance;
    private AudioSource audioSource;

    public AudioClip bgmClip; // BGMの音源

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); // すでに存在する場合は新しいものを削除
            return;
        }

        // インスタンスを保持
        instance = this;
        DontDestroyOnLoad(gameObject);

        // AudioSourceを追加
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true; // ループ再生
        audioSource.Play();
    }
}
