using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))] // TextMeshProコンポーネント(UI用)が必要であることを明示的に指定
public class TimerScript : MonoBehaviour
{
    [SerializeField] private float m_Time = 0f; // タイマーカウント用
    const float START_TIME = 120f; // 開始時のタイマー時間(120s)
    public static TimerScript instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ResetTime();
    }

    void Update()
    {
        // 時間更新
        m_Time -= Time.deltaTime;
        // テキストを変更
        SetTimeText();

        // 任意の時間以下ならテキストのカラーを変更(未実装)

        if(m_Time <= 0.0f)
        {
            // 終了処理
        }
    }
    private void SetTimeText()
    {
        // mm:ss形式に変換
        string time_text = string.Format("{0:D2}:{1:D2}",
            Mathf.FloorToInt(m_Time / 60), // 分
            Mathf.FloorToInt(m_Time % 60)  // 秒
        );

        GetComponent<TextMeshProUGUI>().text = time_text;
    }

    public float GetTime()
    {
        return m_Time;
    }

    public float AddTime(float time)
    {
        m_Time += time;
        return m_Time;
    }

    public void ResetTime()
    {
        m_Time = START_TIME;
    }
}
