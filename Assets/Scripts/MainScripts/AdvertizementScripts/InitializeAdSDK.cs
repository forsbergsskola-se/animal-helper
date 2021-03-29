using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAdSDK : MonoBehaviour
{
    string gameId = "4068245";
    bool testMode = true;

    void Start () {
        Advertisement.Initialize (gameId, testMode);
    }
}
