using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New fuel object", menuName = "Inventory System/Items/Fuel")]
public class FuelObject :ItemObject{
    private void Awake() {
        type = ItemType.Fuel;
    }
}