using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemComponent : MonoBehaviour
{
    [SerializeField]
    private Image image;
    
    [SerializeField]
    private TMP_Text count;

    public void SetCountText(string countText)
    {
        count.text = countText;
    }

    public void SetImageSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
