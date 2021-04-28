using UnityEngine;

public static class HackySave {
    private static InventorySlot _wheel;
    private static InventorySlot _front;
    private static InventorySlot _spoiler;
    private static InventorySlot _body;
    public static InventorySlot Body {
        get{
            return _body;
        }
        set{
            _body = value;
        }
    }
    public static InventorySlot Wheel {
        get{
            return _wheel;
        }
        set{
            _wheel = value;
        }
    }
    public static InventorySlot Front {
        get{
            return _front;
        }
        set{
            _front = value;
        }
    }
    public static InventorySlot Spoiler {
        get{
            return _spoiler;
        }
        set{
            _spoiler = value;
        }
    }
}