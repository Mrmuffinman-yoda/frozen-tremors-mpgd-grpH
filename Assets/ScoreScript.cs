using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int itemsCollected = 0;
    public int totalItems = 6;
    public string endText ="All items collected! time to go home";
    TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(itemsCollected == totalItems){
            score.text =  endText;
        }
        score.text = "Items collected: "+ itemsCollected +"/" + totalItems;
    }
}
