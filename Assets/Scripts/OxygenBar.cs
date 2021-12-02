using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private Text oxygenBarValue;
    private int upperOxygenBound= 100;
    private int lowerOxygenBound = 0;

    public float oxygenVal;

    public void setOxygen()
    {
        /*if (oxygenVal < lowerOxygenBound)
        {
            throw new System.ArgumentException("Cannot set oxygen to less than "+lowerOxygenBound.ToString());
        } else if (oxygenVal > upperOxygenBound)
        {
            throw new System.ArgumentException("Cannot set oxygen to more than " + upperOxygenBound.ToString());
        }*/
        oxygenVal = 100;
        slider.value = oxygenVal;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        oxygenBarValue.text = oxygenVal.ToString() + "%";
        
    }

    /*public void setMaxOxygen(int oxygen)
    {
        upperOxygenBound = oxygen;
        setOxygen(oxygen);
    }*/
    public void udpate(){
        bool timer = true;

        if(timer){
            if(oxygenVal >= 0){
                oxygenVal -= Time.deltaTime;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                oxygenBarValue.text = ((int)oxygenVal).ToString() + "%"; 
            }
            else{
                
                timer = false;
            }  
        }
        
    }
}
