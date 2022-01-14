using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OxygenBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    public Text oxygenBarValue;

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
        oxygenVal = 300;
        slider.value = oxygenVal;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        oxygenBarValue.text = oxygenVal.ToString() + "cm3";
        
    }

    /*public void setMaxOxygen(int oxygen)
    {
        upperOxygenBound = oxygen;
        setOxygen(oxygen);
    }*/
    public void udpate(){
        //Debug.Log("is in update");
        bool timer = true;

        if(timer){
            //Debug.Log("is in timer");
            if(oxygenVal >= 0){
                oxygenVal -= Time.deltaTime;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                oxygenBarValue.text = ((int)oxygenVal).ToString() + "cm3"; 
                Debug.Log(oxygenVal);
            }
            else{
                SceneManager.LoadScene("loss");                
            }  
        }
        
    }
}
