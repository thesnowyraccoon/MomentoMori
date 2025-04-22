using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    public PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    public Direction direction;

    public enum Direction { Up, Down, Left, Right, Far }
    void Start()
    {
        confiner = GameObject.FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            confiner.InvalidateBoundingShapeCache();
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject playerRemy)
    {
        Vector3 newPos = playerRemy.transform.position;
    

        switch (direction)
        {
            case Direction.Right:
                newPos.x += 5;
                break;
           case Direction.Left:
                newPos.x -= 5;
                break;
            case Direction.Up:
                newPos.y += 5;
                break;
            case Direction.Down:
                newPos.y -= 5;
                break;
            case Direction.Far:
                newPos = new Vector3(122, -16, 0);
                break;
        }
        playerRemy.transform.position = newPos;
       
    } 
} 
