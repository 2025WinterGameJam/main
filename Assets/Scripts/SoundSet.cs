using UnityEngine;

public class SoundSet : MonoBehaviour
{

    AudioSource Sound;
    public AudioClip Inport;

    private static float TimeCount = 0.0f;

    private const float TimeInterval = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car" && gameObject.tag == "Train")
        {
            // 同時に鳴らすとうるさいので、ある程度間隔をあける
            if(Time.time >= TimeCount + TimeInterval)
            {
                Sound.PlayOneShot(Inport);
                TimeCount = Time.time;
            }
        }

        if (collision.gameObject.tag == "Car" && gameObject.tag == "Factory")
        {
            Sound.PlayOneShot(Inport);
        }
    }
}
