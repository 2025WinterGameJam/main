using UnityEngine;
using UnityEngine.UI;

public class GaugeMove : MonoBehaviour
{
     Slider slider;
    public static float Gauge = 0;
    bool Cool = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider= GetComponent<Slider>();

        float max = 1000f;
        float min = 0f;
        Gauge = 1000f;

        slider.maxValue = max;
        slider.minValue = min;
        slider.value = Gauge;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cool)
        {
            Cool = true;
            Invoke("TimeLoss", 1);
        }

        slider.value = Gauge;
    }

    void TimeLoss()
    {
        Gauge -= 10;
        Cool = false;
    }
}