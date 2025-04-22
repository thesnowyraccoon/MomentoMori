using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Sprite fullHeart, q3Heart, halfHeart, q2Heart, emptyHeart;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.empty:
                heartImage.sprite = emptyHeart;
                break;
            case HeartStatus.q3:
                heartImage.sprite = q3Heart;
                break;
            case HeartStatus.full:
                heartImage.sprite = fullHeart;
                break;
            case HeartStatus.q2:
                heartImage.sprite = q2Heart;
                break;
            case HeartStatus.half:
                heartImage.sprite = halfHeart;
                break;

        }
    }
    public enum HeartStatus
    {
        empty = 0,
        full = 10,
        q3 = 7,
        half = 5,
        q2 = 2,

    }
}


