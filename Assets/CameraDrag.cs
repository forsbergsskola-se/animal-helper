using UnityEngine;
using UnityEngine.UI;
 
public class CameraDrag : MonoBehaviour {
    public bool move;
    public GameObject garageUI;
    public GameObject scrapyardUI;
    public Text navText;

  

    public void MoveCam() {
        move = !move;
        if (!move) {
            Vector3 newPos = new Vector3(1.5f, -1.6f, -21);
            scrapyardUI.SetActive(true);
            garageUI.SetActive(false);
            navText.text = "Go to garage";

            transform.position = newPos;
        }
        else {
            Vector3 newPos = new Vector3(11, -1.6f, -21);
            navText.text = "Go to scrapard";
            transform.position = newPos;
            scrapyardUI.SetActive(false);
            garageUI.SetActive(true);
        }
    }
}