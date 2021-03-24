using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaPopup : MonoBehaviour
{
    public Image image;
    public Image rarityImage;
    public GameObject prefab;
    public Color[] rarityColors;
    private int turnOff = 0;
    public void ClaimButton()
    {
        Destroy(gameObject);
    }
}
