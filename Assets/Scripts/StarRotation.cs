using UnityEngine;

public class StarRotation : MonoBehaviour {
    public float RotSpeed = 30f;

    void Update() {
        transform.Rotate(0, 0, RotSpeed * Time.deltaTime);
    }
}
