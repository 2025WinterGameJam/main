using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    bool stop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            transform.Translate(0.0f, 0.005f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Down")
        {
            stop = true;
            transform.Translate(0.0f, -0.05f, 0.0f);
            Invoke("Go", 3);

            //collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Train")
        {
            TimerScript.instance.AddTime(-10.0f);
            //GaugeMove.Gauge -= 100;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Factory")
        {
            //ScoreManager.ScoreNum += 100;
            ScoreScript.instance.AddScore(100);
            Destroy(gameObject);
        }
    }

    void Go()
    {
        stop = false;
    }
}