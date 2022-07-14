
using UnityEngine;
using UnityEngine.UI;

public class ChaosMeter : MonoBehaviour
{
    // TODO Increase chaos meter on chaos item pick up or when player kills and enemy 

    [SerializeField] private float decreaseAmount;
    
    private Slider slider;
    private float chaosMeterValue; 
    
 
    void Start()
    {
        slider = GetComponent<Slider>();
        
    }


    void Update()
    {
        DrainMeter();
    }


    public float ChaosMeterValue => chaosMeterValue;

    public float ChaosDecreaseAmount
    {
        get => decreaseAmount;
        set => decreaseAmount = value;
    }

    public void IncreaseChaosMeter(float amount)
    {
        slider.value += amount;
    }


    void DrainMeter()
    {
        
        chaosMeterValue = slider.value;
        if (slider.value <= 0)
        {
            slider.value = 0;
        }
        else
        {
            slider.value -= decreaseAmount * Time.deltaTime;
        }
    }
}