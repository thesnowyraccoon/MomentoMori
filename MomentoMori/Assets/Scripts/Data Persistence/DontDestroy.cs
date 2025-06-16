using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //Saving Data Between Scenes (Without Duplicating Objects)
    //17 April 2023
    //Night Run Studio
    //https://youtu.be/hzdADY2LkJU?si=LaiPhD7ZzTNHrPPU

    private static GameObject[] persistentObjects = new GameObject[6]; //array with the objects that will persist from scene to scene
    //the value in the new GameObject is the amount of items we want to move between scenes
    public int objectIndex; //PersistentObjects get there own numbers

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
    }
}

    //Player- Object Index 0
    //Canvas- Object Index 1
    //Camera- Object Index 2
    //Tarots1- Object Index 3
    //Tarots2- Object Index 4
    //Tarots3- Object Index 5
