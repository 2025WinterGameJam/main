using UnityEngine;

public class SoundSet : MonoBehaviour
{

    AudioSource Sound;
    public AudioClip Inport;

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
            Sound.PlayOneShot(Inport);
        }

        if (collision.gameObject.tag == "Car" && gameObject.tag == "Factory")
        {
            Sound.PlayOneShot(Inport);
        }
    }
}
