using UnityEngine;

public static class HackySave {
    public static InventorySlot _wheel;
    public static InventorySlot _front;
    public static InventorySlot _spoiler;
    private static InventorySlot _body;
    
    public static InventorySlot Body {
        get{
            Debug.Log("Getting Body: " + _body);
            return _body;
        }
        set{
            Debug.Log("Setting Body: " + value);
            _body = value;
        }
    }
    public static InventorySlot Wheel {
        get{
            Debug.Log("Getting Body: " + _wheel);
            return _wheel;
        }
        set{
            Debug.Log("Setting Body: " + value);
            _wheel = value;
        }
    }
    public static InventorySlot Front {
        get{
            Debug.Log("Getting Body: " + _front);
            return _front;
        }
        set{
            Debug.Log("Setting Body: " + value);
            _front = value;
        }
    }
    public static InventorySlot Spoiler {
        get{
            Debug.Log("Getting Body: " + _spoiler);
            return _spoiler;
        }
        set{
            Debug.Log("Setting Body: " + value);
            _spoiler = value;
        }
    }
}