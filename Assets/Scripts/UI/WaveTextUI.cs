
using TMPro;
using UnityEngine;

public class WaveTextUI : MonoBehaviour
{

    
    // Play wave animtion when wave increases

    private Animator anim;
    private TextMeshProUGUI waveText;
    [SerializeField] private WaveSpawner wave;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        waveText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
       // print("Wave Count" + WaveSpawner.instance.WaveCount);
       
        waveText.text = "Wave: " + wave.WaveCount;


    }


    
    
}
