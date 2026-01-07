using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public float destroyPoint;  //このx座標の絶対値を超えたらこれが付いてるオブジェクトは消え去ります。この世から。永遠に。
    public float speed; //電車のスピード
    float direction;

    AudioSource Sound;
    public AudioClip Inport;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = gameObject.transform.position.x / gameObject.transform.position.x; //電車の進行方向
        if(gameObject.transform.position.x > 0 )
        {
            direction *= -1;
        }

        Sound = GetComponent<AudioSource>();

        Sound.PlayOneShot(Inport);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = gameObject.transform.position;
        pos.x += speed * direction;
        gameObject.transform.position = pos;

        float despos = Mathf.Abs(pos.x);
        if(despos >= destroyPoint)
        {
            Destroy(gameObject);
        }
    }
}
