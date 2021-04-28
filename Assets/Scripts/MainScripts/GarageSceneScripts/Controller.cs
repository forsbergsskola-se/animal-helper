using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    public GameObject ItemViewPrefab;

    public GameObject PrefabBlur;
    public GameObject PrefabPopup;
    public GameObject PopupRaceDenied;
    public bool UIDissable = false;
    private Camera _camera;

    public Animator Anim;
    public AudioSource claimAward;
    public AudioSource magnetSound;
    public AudioSource getItemSound;

    public int[] weightsSoft = {50, 40, 30, 20, 10, 1};
    public int[] weightsHard = {30, 30, 30, 30, 10, 10};

    public int gachaCostSoft = 100;
    public int gachaRollHard = 100;
    public int rewardAmount = 3;

    void Start() {
        _camera = Camera.main;
        var moneyWon = GameObject.Find("MoneyWon");
        if (moneyWon != null) {
            moneyWon.GetComponent<MoneyWon>().AddToStash();
        }
        inventory.BlurReset();
    }
    
    public void Update() {
        if(!UIDissable) {
            if (Input.GetMouseButtonDown(0)) {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit)) {
                    var gsButton = hit.collider.CompareTag("GachaSoft");
                    if (gsButton) {
                        if (player.HasEnoughNutsBolts(gachaCostSoft)) {
                            UIDissable = true;
                            StartCoroutine(PlayAnimationSoft());
                        }
                    }
                    
                    var ghButton = hit.collider.CompareTag("GachaHard");
                    if (ghButton) {
                        if (player.HasEnoughScrap(gachaRollHard)) {
                            UIDissable = true;
                            StartCoroutine(PlayAnimationHard());
                        }
                    }
                }
            }
        }
        GachaBlurController();
    }
    
    public void RollGachaSoft() {
        player.NutsBolts -= gachaCostSoft;

        for (int j = 0; j < rewardAmount; j++) {
            var totalWeights = weightsSoft.Sum();
            var random = Random.Range(0, totalWeights);
            var total = weightsSoft[0];
            var i = 0;
            while (total < random) { 
                i++; 
                total += weightsSoft[i];
            }
            PrefabBlur.SetActive(true);
            var popUp = Instantiate(PrefabPopup, GameObject.Find("Canvas").transform);
            popUp.GetComponentInChildren<ItemView>().Display(player.gachaLootTable[i]);
            popUp.GetComponent<GachaPopup>().ColorDisplay(player.gachaLootTable[i]);
            getItemSound.Play();
        }
    }
    
    public void RollGachaHard() {
        player.Scrap -= gachaRollHard;
        
        for (int j = 0; j < rewardAmount; j++) {
            var totalWeights = weightsHard.Sum();
            var random = Random.Range(0, totalWeights);
            var total = weightsHard[0];
            var i = 0;
            while (total < random) { 
                i++; 
                total += weightsHard[i];
            }
            PrefabBlur.SetActive(true);
            var popUp = Instantiate(PrefabPopup, GameObject.Find("Canvas").transform);
            popUp.GetComponentInChildren<ItemView>().Display(player.gachaLootTable[i]);
            popUp.GetComponent<GachaPopup>().ColorDisplay(player.gachaLootTable[i]);
            getItemSound.Play();
        }
    }
    
    
    public void GachaBlurController() {
        if (inventory.claimAmountOfTimes == rewardAmount) {
            PrefabBlur.SetActive(false);
            inventory.BlurReset();
            UIDissable = false;
        }
    }
    
    public void StartRace() {
        if(inventory.EquipedParts.Count != 4) {
            Debug.Log("Your car is not finished");
            PopupRaceDenied.SetActive(true);
            return;
        }
        Debug.Log("Loading Race");
        SceneManager.LoadScene("CarRollScene");
    }
    
    public void ClosePopup() {
        PopupRaceDenied.SetActive(false);
    }

   private IEnumerator PlayAnimationSoft() {
        Anim.SetTrigger("lowerMagnet");
        magnetSound.Play();
        yield return new WaitForSeconds(1.5f);
        RollGachaSoft();
   }

    private IEnumerator PlayAnimationHard() {
        Anim.SetTrigger("lowerMagnet");
        magnetSound.Play();
        yield return new WaitForSeconds(1.5f);
        RollGachaHard();
    }

}