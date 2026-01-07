using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}