using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 [Serializable]
public class ItemInventory
{
    public ItemProfileSO itemProfile;//scriptableobject
    public int itemCount = 0;
    public int maxStack = 7;
}
