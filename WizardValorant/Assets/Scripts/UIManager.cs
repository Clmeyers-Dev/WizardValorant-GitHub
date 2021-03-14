using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{

    // Use this for initialization
    public HealthManager statMan;
    public TextMeshProUGUI healthBar;
    public GameObject InteractBar;
    public TextMeshProUGUI ArcanePower;
    public GameObject buyMenuUI;
    public Bomb bomb;
    public TextMeshProUGUI bombTimer;
    //This deterimes if the eqiupment panel is visible by default when the player opens their inventory
    public bool equipimentToggle = false;
    void Start()
    {
        statMan = GetComponentInParent<HealthManager>();
      //  InteractBar.SetActive(false);
        healthBar.text = ""+statMan.currentHealth;
        buyMenuUI.SetActive(false);
    }

    // Update is called once per frame
   
    public void setBuyMenuActive(bool state)
    {
        buyMenuUI.SetActive(state);
    }
    public void UpdateUI()
    {
        /*
         *This sets the max value of the health bar 
         * The second part sets the value of the health bar to the players current Health
         */
         if(bomb == null)
        {
           bomb =  FindObjectOfType<Bomb>();
        }
        if (bomb != null)
        {
            bombTimer.text = ""+bomb.currentBombTime ;
        }
        else
        {
            bombTimer.text = "";
        }
        healthBar.text =""+ statMan.currentHealth;
        
    }
}