using UnityEngine;
 
public class CameraDrag : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 _dragOrigin;
    private Vector3 _difference;

    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        // Save position of mouse in world space when drag starts (first time clicked)

        if (Input.GetMouseButtonDown(0))
            _dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        // Calculate distance between drag origin and new position if it is still held down

        if (Input.GetMouseButton(0))
        {
            _difference = _dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            print("Origin " + _dragOrigin + " NewPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " = Difference " + _difference);
        }
      
        // Move the camera by that distance
        cam.transform.position += _difference;
    }
}



     /* public float Speed = 5;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += Speed * new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }
    }*/

    /*private Vector3 dragOrigin;
    //private bool move;
    
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
       
    } */
    
