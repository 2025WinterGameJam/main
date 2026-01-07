using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    GameObject oj;
    bool Cool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oj = (GameObject)Resources.Load("Car");
        Cool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cool)
        {
            Cool = true;
            int randam = (int)Random.Range(2.0f,5.0f);
            Invoke("Spawn", randam);
        }
    }

    void Spawn()
    {
        Instantiate(oj, transform.position, transform.rotation);
        Cool = false;
    }
}