using UnityEngine;
using TMPro;
using unityroom.Api;

public class StoreResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText = null;

    void Start()
    {
        int finalScore = ScoreScript.instance.GetScore();
        // unityroomにスコア送信
        UnityroomApiClient.Instance.SendScore(1, finalScore, ScoreboardWriteMode.HighScoreDesc);

        m_scoreText.text = finalScore.ToString("D6"); // 6桁のゼロ埋めでスコアを表示
    }
}