using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timeToPlant;
    public float maxBombTime;
    public float currentBombTime;
    public float timeToDiffuse;
   public float currentDiffuseTime;
    // Start is called before the first frame update
    void Start()
    {
        currentBombTime = maxBombTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBombTime > 0)
        {
            currentBombTime -= Time.deltaTime;
        }
       
        if (currentBombTime <= 0)
        {
            Debug.Log("Explode");
        }
    }
}
