// 時間の関係でほぼAIコピーになっちゃってるので後で見直し必要

using UnityEngine;

[RequireComponent(typeof(Camera))] // cameraコンポーネント必須

[ExecuteAlways]
public class CameraAspectKeeper : MonoBehaviour
{
    public Vector2 targetAspect = new Vector2(16, 9);
    private Camera cam;

    // 前回の画面サイズを記憶する変数
    private int lastWidth = -1;
    private int lastHeight = -1;

    void Start()
    {
        cam = GetComponent<Camera>(); // カメラ取得
        UpdateCameraRect(); // 初回実行
    }

    void Update()
    {
        // 現在の画面サイズが、記憶しているサイズと違う場合のみ処理する
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            UpdateCameraRect();
        }
    }

    void UpdateCameraRect()
    {
        if (cam == null) return;

        // 変更後のサイズを記憶更新
        lastWidth = Screen.width;
        lastHeight = Screen.height;

        // 画面比計算
        float targetRate = targetAspect.x / targetAspect.y;
        float currentRate = (float)Screen.width / Screen.height;
        float scale = currentRate / targetRate;

        Rect rect = cam.rect;

        // レターボックスまたはピラーボックスを設定

        // レターボックス
        if (scale < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scale;
            rect.x = 0;
            rect.y = (1.0f - scale) / 2.0f;
        }
        // ピラーボックス
        else
        {
            float scaleHeight = 1.0f / scale;
            rect.width = scaleHeight;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleHeight) / 2.0f;
            rect.y = 0;
        }

        cam.rect = rect;
    }
}