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
    public GameObject loadedItem;
    public GameObject loadPostion;
    public bool buyMenuUp;
    public int ArcanePower;
   public bool CatalystLoaded;
    public GameObject knife;
    public bool knifeLoaded;
    public bool hasBook;
    public bool bookLoaded;
    public GameObject book;
    public bool bookToggle;
    public GameObject bookLocation;
    public int i;

    public float bookTimerMax;
    public float currentBookTimer;
    void Start()
    {
        controller = GetComponentInChildren<SC_FPSController>();
        TerrainChecker = GetComponentInChildren<CheckTerrainTexture>();
        uIManager = GetComponentInChildren<UIManager>();
        CatalystLoaded = false;
       
        
        loadItemOnHand(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBook && Input.GetKey(KeyCode.E))
        {
            bookToggle = true;
            if (bookLoaded == false)
            {


                loadItemOnHand(3);
            }
            currentBookTimer -= Time.deltaTime;
            if (currentBookTimer <= 0)
            {
               
                placeBook();
                
            }
        }
        if (hasBook && Input.GetKey(KeyCode.E) == false)
        {
            currentBookTimer = bookTimerMax;
        }
        if (book == null)
        {
            hasBook = false;
        }
        if (Input.GetKeyUp(KeyCode.E) &&hasBook)
        {

            bookToggle = !bookToggle;
           
            loadItemOnHand(3);
        }
       if(bookToggle == false)
        {
            loadItemOnHand(i);
        }
        controller.Run();
        TerrainChecker.Check();
        uIManager.UpdateUI();
        uIManager.setBuyMenuActive(buyMenuUp);
        uIManager.ArcanePower.text = "" + ArcanePower;
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (buyMenuUp == false)
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
        float scrollWheel = Input.GetAxisRaw("Mouse ScrollWheel");
        //Debug.Log(scrollWheel);
       
        
        if (scrollWheel < 0&&i==1)
        {
            i--;
            Debug.Log("Scroll wheel: " + scrollWheel);
            Debug.Log(i+"subtract");
            loadItemOnHand(i);
        }
        else if (scrollWheel>0)
        {
            i++;
            Debug.Log(i + "add");
            Debug.Log("Scroll wheel: " + scrollWheel);
            if (i > 1)
            {
                i = 1;
                Debug.Log(i + "add fixed");
                loadItemOnHand(i);
            }
        }
     
      
    }
    public void unloadItemOnHand(int i)
    {

    }
    public void loadItemOnHand(int z)
    {
       
        if (z == 1&&CatalystLoaded==false&&CurrentCatalyst!=null)
        {
            bookToggle = false;
            
            if (loadedItem != null)
            {
                Destroy(loadedItem);
            }
            loadedItem = Instantiate(CurrentCatalyst, loadPostion.transform.position, Quaternion.identity);
            loadedItem.transform.rotation.eulerAngles.Set(0, 0, 0);
            loadedItem.transform.parent = loadPostion.transform.transform;
            loadedItem.transform.localRotation = Quaternion.identity;

            CatalystLoaded = true;
            knifeLoaded = false;
            bookLoaded = false;
        }
        if (z == 0&& knifeLoaded ==false){
            bookToggle = false;
            if (loadedItem != null)
            {
                Destroy(loadedItem);
            }
            Debug.Log("loaded knife");
            loadedItem = Instantiate(knife, loadPostion.transform.position, Quaternion.identity);
            loadedItem.transform.rotation.eulerAngles.Set(0, 0, 0);
            loadedItem.transform.parent = loadPostion.transform.transform;
            loadedItem.transform.localRotation = Quaternion.identity;
            CatalystLoaded = false;
            knifeLoaded = true;
            bookLoaded = false;

        }
        if (z == 3)
        {
            if (loadedItem != null)
            {
                Destroy(loadedItem);
            }
            Debug.Log("loaded book");
            loadedItem = Instantiate(book, loadPostion.transform.position, Quaternion.identity);
            loadedItem.transform.rotation.eulerAngles.Set(0, 0, 0);
            loadedItem.transform.parent = loadPostion.transform.transform;
            loadedItem.transform.localRotation = Quaternion.identity;
            CatalystLoaded = false;
            knifeLoaded = false;
            bookLoaded = true;

        }
        
    }
    void placeBook()
    {
        hasBook = false;
        Destroy(loadedItem);
        loadItemOnHand(i);
        GameObject groundBook = Instantiate(book, bookLocation.transform.position, Quaternion.identity);
        book = null;
    }
}
