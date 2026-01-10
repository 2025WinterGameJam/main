using System.Collections.Generic;
using UnityEngine;

public class CrossingManager : MonoBehaviour
{
    // シングルトン化（どこからでもアクセスしやすくする）
    public static CrossingManager Instance;

    // 閉まっている踏切を順番に格納するリスト
    private List<Crossing> closedCrossings = new List<Crossing>();

    // 同時に閉じられる最大数
    public const int MaxClosedCount = 3;

    void Awake()
    {
        // 簡易的なシングルトン設定
        if (Instance == null) Instance = this;
    }

    /// <summary>
    /// 踏切がクリックされた時に呼ばれる処理
    /// </summary>
    /// <param name="crossing">クリックされた踏切</param>
    public void OnCrossingClicked(Crossing crossing)
    {
        // すでに閉まっている場合 -> 開く処理
        if (crossing.IsClosed)
        {
            OpenCrossing(crossing);
        }
        // 開いている場合 -> 閉じる処理（制限チェック付き）
        else
        {
            CloseCrossing(crossing);
        }
    }

    // 踏切を閉じる処理
    private void CloseCrossing(Crossing crossing)
    {
        bool wasAllClose = false;
        // 既に3つ閉まっている場合
        if (closedCrossings.Count >= MaxClosedCount)
        {
            // リストの最初（一番古く閉じたもの）を取得して強制的に開く
            Crossing oldest = closedCrossings[0];
            OpenCrossing(oldest);
            wasAllClose = true;
        }

        // 新しく閉じる踏切をリストの末尾に追加
        closedCrossings.Add(crossing);
        crossing.SetState(true); // 閉じる

        // 今回追加したのは2回実行したことになってしまうが3つ閉まっていた時に他の部分の文字も更新しないといけないのでforeachで更新をかける
        if(wasAllClose)
        {
            foreach(var c in closedCrossings)
            {
                c.GetComponent<CrossingInfoScript>().UpdateCrossingInfo(true, GetIndex(c));
            }
        }

        Debug.Log($"現在の閉鎖数: {closedCrossings.Count} / {MaxClosedCount}");
    }

    // 踏切を開く処理
    private void OpenCrossing(Crossing crossing)
    {
        // リストから削除
        if (closedCrossings.Contains(crossing))
        {
            closedCrossings.Remove(crossing);
        }

        // 開閉状況表示を更新
        foreach (var c in closedCrossings)
        {
            c.GetComponent<CrossingInfoScript>().UpdateCrossingInfo(true, GetIndex(c));
        }

        crossing.SetState(false); // 開く
    }

    public int GetIndex(Crossing crossing)
    {
        return closedCrossings.IndexOf(crossing) + 1;
    }
}