using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuySlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ItemImage;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Cost;
    public string WeaponName;
    public int Price;
    WizardManager wizardManager;
    public bool isCatalyst;
    public bool isSpell;
    public GameObject item;
    public bool itemBought;
    void Start()
    {
        wizardManager = GetComponentInParent<WizardManager>();
        Name.text = WeaponName;
        Cost.text = "" + Price;
    }

    // Update is called once per frame
    public void buyItem()
    {
        if (itemBought == false)
        {


            if (wizardManager.ArcanePower >= Price)
            {
                wizardManager.ArcanePower -= Price;
                if (isCatalyst)
                {
                    wizardManager.CurrentCatalyst = item;
                }

            }
            else
            {
                Debug.Log("you dont have enough power to obtain that");
            }
            Debug.Log(wizardManager.ArcanePower);
            itemBought = true;
        }
    }
    void Update()
    {
        
    }
}
