using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gatcha
{
    public class GatchaItemDisplay : MonoBehaviour
    {
        public GatchaScriptableObjects gatchaItem;
        public GatchaScriptableObjects gatchaItem2;
        public GatchaScriptableObjects gatchaItem3;
        public void Start()
        {
            gatchaItem.DebugPrint();
            gatchaItem2.DebugPrint();
            gatchaItem3.DebugPrint();
        }

    }
}
