using UnityEngine;
 
public class CameraDrag : MonoBehaviour {
    public bool move;

    public void MoveCam() {
        move = !move;
        if (!move) {
            Vector3 newPos = new Vector3(1.5f, -1.6f, -21);

            transform.position = newPos;
        }
        else {
            Vector3 newPos = new Vector3(11, -1.6f, -21);

            transform.position = newPos;
        }
    }
}