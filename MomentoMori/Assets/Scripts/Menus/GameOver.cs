using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadSceneAsync("Prototype");
        SceneManager.LoadSceneAsync("Health Bar", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Tarot", LoadSceneMode.Additive);
    }
}
