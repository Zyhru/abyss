
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public GameObject pauseMenuUI, player;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
         
            if (!paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
        
        
    }




    public void Pause()
    {
        Time.timeScale = 0f;
        paused = true;
        pauseMenuUI. gameObject.SetActive(true);
        player.gameObject.SetActive(false);
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenuUI.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
    }






    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    
}
