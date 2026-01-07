using UnityEngine;

public class Crossing : MonoBehaviour
{
    [Header("画像の割当て")]
    [SerializeField] private Sprite openSprite;   // 開いている時の画像
    [SerializeField] private Sprite closedSprite; // 閉まっている時の画像

    private SpriteRenderer spriteRenderer;

    // 現在の状態（外部から読み取り専用）
    public bool IsClosed { get; private set; } = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 初期状態（開いている状態）をセット
        SetState(false);
    }

    // クリックされた時のUnityイベント
    void OnMouseDown()
    {
        // マネージャーに「クリックされたよ」と報告して判断を仰ぐ
        CrossingManager.Instance.OnCrossingClicked(this);
    }

    /// <summary>
    /// 状態を変更して見た目を更新する
    /// </summary>
    /// <param name="shouldClose">閉じるならtrue</param>
    public void SetState(bool shouldClose)
    {
        IsClosed = shouldClose;

        if (IsClosed)
        {
            // 閉じる時の見た目（遮断機を下ろすなど）
            spriteRenderer.sprite = closedSprite;
            Debug.Log(gameObject.name + " が閉じました");
            tag = "Down";
        }
        else
        {
            // 開く時の見た目
            spriteRenderer.sprite = openSprite;
            Debug.Log(gameObject.name + " が開きました");
            tag = "Up";
        }
    }
}