using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //Saving Data Between Scenes (Without Duplicating Objects)
    //17 April 2023
    //Night Run Studio
    //https://youtu.be/hzdADY2LkJU?si=LaiPhD7ZzTNHrPPU

    private static GameObject[] persistentObjects = new GameObject[3]; //array with the objects that will persist from scene to scene
    //the value in the new GameObject is the amount of items we want to move between scenes
    public int objectIndex; //PersistentObjects get there own numbers

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (persistentObjects[objectIndex] == null) //Checks if the object is already in the scene
        {
            persistentObjects[objectIndex] = gameObject; //index empty item replaced
            DontDestroyOnLoad(gameObject); // What will be preserved when loading a new scene
        }
        else if (persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }
        //Player- Object Index 0
        //Canvas- Object Index 1
    }

    
}
