using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Score = null;
    public static int ScoreNum = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text ScoreText = Score.GetComponent<Text>();
        ScoreText.text = "Score:" + ScoreNum;
    }
}