using UnityEngine;
using TMPro;

public class StoreResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText = null;

    void Start()
    {
        int finalScore = ScoreScript.instance.GetScore();
        m_scoreText.text = finalScore.ToString("D6"); // 6桁のゼロ埋めでスコアを表示
    }
}