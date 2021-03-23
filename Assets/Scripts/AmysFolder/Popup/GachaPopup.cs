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
    //Test List for SOs
    public ItemObject[] SOsItems;
    public int random;
    public void Start()
    {
        //random = Random.Range(0, rarityColors.Length);
        //Debug.Log("Random Number is" + random);
    }
    public void PopupOff()
    {
        //image.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        prefab.SetActive(false);
    }
    public void PopupOn()
    {
        random = Random.Range(0, SOsItems.Length);
        Debug.Log("Random Number is" + random);
        var i = random;
        image.sprite = SOsItems[i].itemSprite;
        prefab.SetActive(true);
        rarityImage.color = rarityColors[SOsItems[i].rarityLevel];
        //rarityImage.color = rarityColors[i];
    }
    public void Update()
    {
        //image.GetComponent<Image>().color += new Color(0, 0, 0, 110);
        //var i = 0;
        //rarityImage.color = rarityColors[i];
        //i++;
        
    }
}
