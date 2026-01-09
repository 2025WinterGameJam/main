using Unity.VisualScripting;
using UnityEngine;

public class ObjectShowScript : MonoBehaviour
{
    // 関数が実行されるとあらかじめSerializeFieldに設定されているオブジェクトの可視性を切り替えます

    [Header("表示非表示を切り替えたい対象オブジェクト")]
    [SerializeField] GameObject m_targetObject;
    public void ObjectVisibleChange()
    {
        // 現在の可視性を取得
        bool state = m_targetObject.activeSelf;
        // 状態を反転
        m_targetObject.SetActive(!state);
    }
}
