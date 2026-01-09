using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    // 音量管理マネージャー

    [SerializeField] AudioMixer m_Mixer;
    [SerializeField] Slider m_MasterVolSlider;
    [SerializeField] Slider m_BGMVolSlider;
    [SerializeField] Slider m_SEVolSlider;

    public void Start()
    {
        // スライダーの初期値を設定
        m_Mixer.GetFloat("MasterValue", out float masterVolume);
        m_MasterVolSlider.value = Mathf.Pow(10f, masterVolume / 20f);

        m_Mixer.GetFloat("BGMValue", out float BGMVolume);
        m_BGMVolSlider.value = Mathf.Pow(10f, BGMVolume / 20f);

        m_Mixer.GetFloat("SEValue", out float SEVolume);
        m_SEVolSlider.value = Mathf.Pow(10f, SEVolume / 20f);
    }

    public void SetMainVolume()
    {
        float percent = m_MasterVolSlider.value;
        // 0db~-80dbの間で変化
        float volume = Mathf.Clamp(Mathf.Log10(percent) * 20f, -80f, 0f);
        m_Mixer.SetFloat("MasterValue", volume);
    }

    public float GetMainVolume()
    {
        m_Mixer.GetFloat("MasterValue", out float masterVolume);
        return masterVolume;
    }

    public void SetBGMVolume()
    {
        float percent = m_BGMVolSlider.value;
        // 0db~-80dbの間で変化
        float volume = Mathf.Clamp(Mathf.Log10(percent) * 20f, -80f, 0f);
        m_Mixer.SetFloat("BGMValue", volume);
    }

    public float GetBGMVolume()
    {
        m_Mixer.GetFloat("BGMValue", out float BGMVolume);
        return BGMVolume;
    }

    public void SetSEVolume()
    {
        float percent = m_SEVolSlider.value;
        // 0db~-80dbの間で変化
        float volume = Mathf.Clamp(Mathf.Log10(percent) * 20f, -80f, 0f);
        m_Mixer.SetFloat("SEValue", volume);
    }

    public float GetSEVolume()
    {
        m_Mixer.GetFloat("SEValue", out float SEVolume);
        return SEVolume;
    }
}
