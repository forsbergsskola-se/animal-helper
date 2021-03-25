using UnityEngine;

public class GyroManager : MonoBehaviour
{
    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    public Rigidbody2D rb;
    public float tilt;
    public void EnableGyro()
    {
        // Already activated
        if (gyroActive)
            return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
        else
        {
            Debug.Log("Gyro is not supported on this device");
        }
    }
    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
            Debug.Log(rotation);

        }
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}