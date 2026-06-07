using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Stage2_ActionScript : MonoBehaviour {
    public Sprite sprite; // 新しい画像（スプライト）
    public Sprite newsprite; // 新しい画像（スプライト）

    void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {
        if (!VarScripts.ACTION) {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

        if (VarScripts.ACTION) {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = newsprite;
        }
    }
}
