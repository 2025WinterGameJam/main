using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class CarMove : MonoBehaviour
{
    bool stop;
    [SerializeField] private float speed;

    AudioSource Sound;
    public AudioClip Train;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Down")
        {
            stop = true;
        }

        if (collision.gameObject.tag == "Train")
        {
            //Sound.PlayOneShot(Train);
            TimerScript.instance.AddTime(-6.0f);
            // 揺らす
            GetComponent<CinemachineImpulseSource>().GenerateImpulse();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        // とどまり続けてる時に踏み切りが上がったら再び進み始める
        // すぐに踏み切りしめたとしても侵入してるので止まらない。
        if (collision.gameObject.tag == "Up")
        {
            stop = false;
        }
    }

    void Go()
    {
        stop = false;
    }
}