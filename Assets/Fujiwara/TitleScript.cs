using UnityEngine;

public class ugokuView : MonoBehaviour
{
    public float atai;
    float now;
    bool maipura;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        now = 0;
        if (atai < 0)
        { 
            maipura = false;
        }
        else
        {
            maipura = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int randam = (int)Random.Range(60.0f, 120.0f);

        now += (atai / randam);

        if (maipura && now > atai)
        {
            atai = -atai;
            maipura = false;
        }
        else if (!maipura && now < atai)
        {
            atai = -atai;
            maipura = true;
        }

        transform.Translate(now, 0.0f, 0.0f);

    }
}