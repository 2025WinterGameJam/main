using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class CrossingInfoScript : MonoBehaviour
{
    // CrossingManager見て現在の開閉状態を見る
    // 一番先頭のは1/3で次のは2/3みたいな感じで表示。
    [SerializeField] private GameObject m_InfoObject; // 情報表示用のUIオブジェクト

    // crossingがクリックされる->managerにアクセス->crossing側でstate変化->その中でこのスクリプトの関数を実行しUI表示+文字更新
    // そうなると当たり判定の分割を先にやっといたほうがいいなこれ

    public void UpdateCrossingInfo(bool isClosed, int index)
    {
        // ここでUIの更新を行う
        // 例: テキストや画像の変更
        if (isClosed)
        {
            // 内部のテキストいじる
            m_InfoObject.GetComponentInChildren<TextMeshProUGUI>().text = index + "/" + CrossingManager.MaxClosedCount;

            // 表示
            m_InfoObject.SetActive(true);
        }
        else
        {
            // 非表示
            m_InfoObject.SetActive(false);
        }
    }
}
