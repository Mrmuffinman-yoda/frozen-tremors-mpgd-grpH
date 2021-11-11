using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public static int inventorySize = 2;
    //USED ONLY FOR TWO ITEMS CAN CHANGE LATER
    private bool[] filledSlot;
    private GameObject[] slots = new GameObject[inventorySize];
    
    void Start()
    {
        filledSlot = new bool[inventorySize];
        for (int i = 0; i < inventorySize; i++)
        {
            filledSlot[i] = false;
        }
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
        
    }

    public void CreateDisplay(){

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            slots[i] = Instantiate(inventory.Container[i].item.prefab,Vector3.zero, Quaternion.identity, transform);
            slots[i].GetComponent<RectTransform>().localPosition = GetPosition(i);
            filledSlot[i] = true;
        }
    }

    public void UpdateDisplay(){
        if(inventory.Container.Count == 0){
            try{
                //FLUSHES ALL OF THE ITEMS
                for (int i = 0; i < inventorySize; i++)
                {
                    filledSlot[i] = false;
                    Destroy(slots[i], 1f);
                }
            }
            catch{
                return;
            
            }
        }
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if(inventory.Container[i].item && !filledSlot[i]){
                slots[i] = Instantiate(inventory.Container[i].item.prefab,Vector3.zero, Quaternion.identity, transform);
                slots[i].GetComponent<RectTransform>().localPosition = GetPosition(i);
                filledSlot[i] = true;
            }
        }
    }
    

    //HARCODED POSITIONS
    //MIGHT NEED TO IMPROVE LATER
    public Vector3 GetPosition(int i){
        if(i<1){
            return new Vector3(-65,0,0f);
        }
        return new Vector3(65,0,0f);
    }
}
