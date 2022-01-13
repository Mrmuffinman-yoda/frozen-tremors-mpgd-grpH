using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Atenna object", menuName = "Inventory System/Items/Antenna")]
public class AntennaObject :ItemObject{
    private void Awake() {
        type = ItemType.Antenna;
    }

}
