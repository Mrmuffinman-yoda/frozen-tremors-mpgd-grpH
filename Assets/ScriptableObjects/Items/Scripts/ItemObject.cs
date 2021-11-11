using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType{
    Scrap,
    Tool,
    Fuel
}
public abstract class ItemObject : ScriptableObject 
{
    public GameObject prefab;
    public ItemType type;

}
    
