using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SC_FPSController controller;
    public CheckTerrainTexture TerrainChecker;
    public UIManager uIManager;
    public GameObject CurrentCatalyst;
    public bool buyMenuUp;
    public int ArcanePower;
    void Start()
    {
        controller = GetComponentInChildren<SC_FPSController>();
        TerrainChecker = GetComponentInChildren<CheckTerrainTexture>();
        uIManager = GetComponentInChildren<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Run();
        TerrainChecker.Check();
        uIManager.UpdateUI();
        uIManager.setBuyMenuActive(buyMenuUp);
        uIManager.ArcanePower.text = "" + ArcanePower;
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(buyMenuUp == false)
            {
                buyMenuUp = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                buyMenuUp = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
    }
}
