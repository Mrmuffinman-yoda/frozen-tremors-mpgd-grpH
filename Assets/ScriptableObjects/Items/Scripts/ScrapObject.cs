using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Scrap object", menuName = "Inventory System/Items/Scrap")]
public class ScrapObject :ItemObject{
    private void Awake() {
        type = ItemType.Scrap;
    }

}
