using UnityEngine;
using UnityEngine.SceneManagement;

public class TPPoints : Interactions
{
    public string levelName;

    public override void Interact()
    {
        SceneController.instance.LoadScene(levelName);
    }
}
