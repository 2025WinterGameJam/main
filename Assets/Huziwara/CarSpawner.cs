using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    GameObject oj;
    bool Cool;
    public int GoWait;
    bool Go;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oj = (GameObject)Resources.Load("Car");
        Cool = false;
        Invoke("GoSign",GoWait);
    }

    // Update is called once per frame
    void Update()
    {
        if (Go)
        {
            if (!Cool)
            {
                Cool = true;
                int randam = (int)Random.Range(2.0f, 5.0f);
                Invoke("Spawn", randam);
            }
        }
    }

    void Spawn()
    {
        Instantiate(oj, transform.position, transform.rotation);
        Cool = false;
    }

    void GoSign()
    {
        Go = true;
    }
}