

using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{


    public GameObject[] menus;
   
    
    
    private void Start()
    {
        AudioManager.instance.Play("MenuMusic");
        
        
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Settings()
    
    {
        
        
        // GET WIT ME
        // IM CATCHING VIBES FROM SILLY

        // 1. User clicks on settings and show settings menu
     
        menus[0].gameObject.SetActive(false);
        menus[1].gameObject.SetActive(true);

    }
    
    public void SetQuality(int quality)
    {
        
        QualitySettings.SetQualityLevel(quality);
        
        
    }

    public void Back()
    {
        menus[0].gameObject.SetActive(true);
        menus[1].gameObject.SetActive(false);
    }

    public void Tutorial()
    {
        
        menus[0].gameObject.SetActive(false);
        menus[1].gameObject.SetActive(false);
        menus[2].gameObject.SetActive(true);
    }
     
}
