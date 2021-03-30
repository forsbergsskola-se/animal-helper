using UnityEngine;
 
public class CameraDrag : MonoBehaviour {
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private bool move;
    
    public void MoveCam() {
         if (Input.GetMouseButtonDown(0)) {
            dragOrigin = Input.mousePosition;
            return;
        }
       
         if (!Input.GetMouseButton(0)) return;
        
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        /*
        move = !move;
        if (move) {
            Vector3 move = new Vector3(dragSpeed, 0, 0);
     
            transform.Translate(move, Space.World);
        }
        else {
            Vector3 move = new Vector3(-dragSpeed, 0, 0);
     
            transform.Translate(move, Space.World);
        }
        */
    }
    
}