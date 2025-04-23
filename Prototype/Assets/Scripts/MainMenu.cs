using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Prototype");
        SceneManager.LoadSceneAsync("Health Bar", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Tarot", LoadSceneMode.Additive);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
