using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public GameObject[] tutorials;


    public void NextButton()
    {
        tutorials[0].gameObject.SetActive(false);
        tutorials[1].gameObject.SetActive(true);
        tutorials[2].gameObject.SetActive(false);
    }

    public void BackButton()
    {
        tutorials[0].gameObject.SetActive(true);
        tutorials[1].gameObject.SetActive(false);
        tutorials[2].gameObject.SetActive(true);
    }


    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        tutorials[3].gameObject.SetActive(true);
    }
    
    
}
