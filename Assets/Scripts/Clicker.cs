using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    [SerializeField] TextMeshProUGUI slimesText;
    [SerializeField] Button autoClickButton;
    [SerializeField] TextMeshProUGUI shopButton;
    [SerializeField] Image slimeArrow;
    [SerializeField] TextMeshProUGUI clickValueText;

    public int slimes;
    public bool autoClickerBuyed = false;
    public int clickValue = 1;
    public int shopClickValue = 10;

    private int movement = 100;

   

    void Start()
    {
        UpdateGUI();
        CompareBuyed();
       
    }

    private void UpdateGUI()
    {
        slimesText.text = slimes.ToString();
        clickValueText.text = "Click Value: " + clickValue;
        shopButton.text = "Click+1 (" + shopClickValue + ")";
    }

    public void BuyClickValue()
    {
        if (slimes > shopClickValue)
        {
            slimes -= shopClickValue;
            clickValue++;
            shopClickValue *= 2;
            
            UpdateGUI();
        }
        else
        {
            return;
        }
        
    }

    private void CompareBuyed()
    {
        if (autoClickerBuyed)
        {
            StartCoroutine("AutoClick");
            autoClickButton.interactable = false;
        }
    }

    public void Click()
    {
        slimes += clickValue;
        UpdateGUI();
    }

    public void BuyAutoClick()
    {

        if (slimes < 100)
        {
            return;
        }
        else
        {
           
            autoClickerBuyed = true;
            autoClickButton.interactable = false;
            slimes -= 100;
            UpdateGUI();
            StartCoroutine("AutoClick");
        }
        

    }

    private IEnumerator AutoClick()
    {
        while (autoClickerBuyed)
        {


           

            slimeArrow.transform.Translate(new Vector3(movement, 0, 0), Space.Self);
            Click();
            yield return new WaitForSeconds(0.5f);
            
            slimeArrow.transform.Translate(new Vector3(-movement, 0, 0), Space.Self);
            yield return new WaitForSeconds(0.5f);
            
            
        }
        
    }

    public void HidePanel()
    {
        Panel.gameObject.SetActive(false);
        UpdateGUI();
        CompareBuyed();

    }
    
}
