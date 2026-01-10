using UnityEngine;

[RequireComponent(typeof(CrossingInfoScript))]
public class Crossing : MonoBehaviour
{
    [Header("画像の割当て")]
    [SerializeField] private Sprite openSprite;   // 開いている時の画像
    [SerializeField] private Sprite closedSprite; // 閉まっている時の画像
    [SerializeField] private GameObject poleObject;

    private SpriteRenderer spriteRenderer;

    AudioSource sound;
    public AudioClip crossOpenSource;
    public AudioClip crossClosedSource;

    // 現在の状態（外部から読み取り専用）
    public bool IsClosed { get; private set; } = false;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        // 初期状態（開いている状態）をセット
        SetState(false, false);
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
    public void SetState(bool shouldClose, bool playSound = true)
    {
        IsClosed = shouldClose;

        if (IsClosed)
        {
            // 閉じる時の見た目（遮断機を下ろすなど）
            spriteRenderer.sprite = closedSprite;
            Debug.Log(gameObject.name + " が閉じました");
            // 子オブジェクトであるポールの角度と位置を変更
            poleObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            poleObject.transform.localPosition = new Vector3(1.3f, -0.1f, 0.0f);
            // タグ変更
            tag = "Down";

            // 情報を表示
            GetComponent<CrossingInfoScript>().UpdateCrossingInfo(true, CrossingManager.Instance.GetIndex(this));
            // 最大数締め切ってて再度閉めようとした時に文章の再更新走らせないとどこが次に開くかがわからない欠点ががが

            //オーディオ再生
            if(playSound)
            {
            sound.PlayOneShot(crossOpenSource);
            }
        }
        else
        {
            // 開く時の見た目
            spriteRenderer.sprite = openSprite;
            Debug.Log(gameObject.name + " が開きました");
            // 子オブジェクトであるポールの角度と位置を変更
            poleObject.transform.localRotation = Quaternion.Euler(0, 0, 45);
            poleObject.transform.localPosition = new Vector3(0.9f, 1.0f, 0.0f);
            // defaut 1.0, 0.8

            // タグ変更
            tag = "Up";

            // 情報を非表示
            GetComponent<CrossingInfoScript>().UpdateCrossingInfo(false, 0);

            //オーディオ再生
            if(playSound)
            {
            sound.PlayOneShot(crossClosedSource);
            }
        }
    }
}