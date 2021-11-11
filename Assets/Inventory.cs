using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int itemDistance = 5;
    // Start is called before the first frame update

    // Update is called once per frame
     void Update(){

        //using raycast to access the current object
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
            var baseMarker = selection.GetComponent<Base>();
            //selecting its rende to calculate distance
            var selectionRender = selection.GetComponent<Renderer>();
            if(selectionRender != null){
                if(Input.GetMouseButtonDown(0)){
                    //checking appropiate grabbing distance
                    float distance = Vector3.Distance(this.transform.position, selectionRender.transform.position);
                    if(distance < itemDistance){
                        var item = selection.GetComponent<Item>();
                        //making sure this object has an item
                        if(item){
                            inventory.AddItem(item.item, 1);
                            Destroy(selectionRender);
                        }
                    }
                }
            }
            if(hit.transform.tag == "base"){
                Debug.Log("hit");
                if(Input.GetMouseButtonDown(0)){
                    ScoreScript.itemsCollected += inventory.Container.Count;
                    inventory.Container = new List<InventorySlot>();
                    //inventory.reset = true;
                    //Destroy(gameObject.GetComponent<DisplayInventory>());
                    //gameObject.AddComponent<DisplayInventory>();
                }
            }
        }

    }
    private void OnApplicationQuit() {
        //we restart the inventory assuming non-continuity
        //***CHECK LATER******
        inventory.Container.Clear();
    }
}
