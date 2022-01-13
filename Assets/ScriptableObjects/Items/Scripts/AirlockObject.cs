using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Airlock object", menuName = "Inventory System/Items/Airlock")]
public class AirlockObject :ItemObject{
    private void Awake() {
        type = ItemType.Airlock;
    }

}
