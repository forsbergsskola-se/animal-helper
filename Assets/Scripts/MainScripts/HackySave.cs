using UnityEngine;

public static class HackySave {
    private static InventorySlot _wheel;
    private static InventorySlot _front;
    private static InventorySlot _spoiler;
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
            Debug.Log("Getting Wheel: " + _wheel);
            return _wheel;
        }
        set{
            Debug.Log("Setting Wheel: " + value);
            _wheel = value;
        }
    }
    public static InventorySlot Front {
        get{
            Debug.Log("Getting Front: " + _front);
            return _front;
        }
        set{
            Debug.Log("Setting Front: " + value);
            _front = value;
        }
    }
    public static InventorySlot Spoiler {
        get{
            Debug.Log("Getting Spoiler: " + _spoiler);
            return _spoiler;
        }
        set{
            Debug.Log("Setting Spoiler: " + value);
            _spoiler = value;
        }
    }
}