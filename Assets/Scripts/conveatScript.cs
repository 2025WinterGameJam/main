using UnityEngine;

public class conveatScript : MonoBehaviour
{
    public float destroySecond = 0;

    float startTime; //ステージ開始時間
    float elaspedTime;//経過時間

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
        elaspedTime = 0;
    }

    private void FixedUpdate()
    {
        elaspedTime = Time.time - startTime;

        if(elaspedTime > destroySecond)
        {
            Destroy(gameObject);
        }
    }
}
