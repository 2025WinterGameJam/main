using UnityEngine;
using UnityEngine.Networking;

public class ShareXScript : MonoBehaviour
{
    [SerializeField] private GameObject m_HoverObject;

    public void OnClick()
    {
        // 獲得スコア取得
        int score = ScoreScript.instance.GetScore();

        // シェアURL生成
        string esctext = UnityWebRequest.EscapeURL("踏み切りシミュレーターで" + score + "円稼ぎました！\nプレイはこちらから: https://unityroom.com/games/crossing_simulator \n");
        string esctag = UnityWebRequest.EscapeURL("踏み切りシミュレーター #unityroom");
        string url = "https://x.com/intent/tweet?text=" + esctext + "&hashtags=" + esctag;

        // ブラウザで開く
        Application.OpenURL(url);
    }

    public void Hover()
    {
        // ホバーしたら説明表示
        m_HoverObject.SetActive(true);
    }

    public void HoverExit()
    {
        // ホバー外れたら説明非表示
        m_HoverObject.SetActive(false);
    }
}
