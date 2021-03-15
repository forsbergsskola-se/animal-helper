using UnityEngine;

public class PlayerController : MonoBehaviour {
    public InventoryObject inventory;

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {
                var item = hit.collider.GetComponent<Item>();
                if (item) {
                    inventory.AddItem(item.item, 1);
                    Destroy(hit.collider.gameObject);
                    print("Destroyed thing at " + Input.mousePosition);
                }
            }
        }
    }
}