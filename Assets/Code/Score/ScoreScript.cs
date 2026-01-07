using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))] // TextMeshProコンポーネント(UI用)が必要であることを明示的に指定
public class ScoreScript : MonoBehaviour
{
    [SerializeField] private int m_Score = 0;
    public static ScoreScript instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ResetScore();
        DontDestroyOnLoad(this);
    }


    void Update()
    {
        
    }

    private void SetScoreText()
    {
        GetComponent<TextMeshProUGUI>().text = m_Score.ToString("D6"); // 6桁のゼロ埋めでスコアを表示
    }

    public int AddScore(int point)
    {
        m_Score += point;
        // スコア表示を更新
        SetScoreText();
        return m_Score;
    }
    public int GetScore()
    {
        return m_Score;
    }

    public void ResetScore()
    {
        m_Score = 0;
        // スコア表示を更新
        SetScoreText();
    }
}
