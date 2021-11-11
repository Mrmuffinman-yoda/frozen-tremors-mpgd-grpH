using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New tool object", menuName = "Inventory System/Items/Tool")]
public class ToolObject :ItemObject{
    private void Awake() {
        type = ItemType.Tool;
    }
}