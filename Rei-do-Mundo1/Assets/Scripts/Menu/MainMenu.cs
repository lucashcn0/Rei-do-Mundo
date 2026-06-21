using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Rukasu_Boss");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
