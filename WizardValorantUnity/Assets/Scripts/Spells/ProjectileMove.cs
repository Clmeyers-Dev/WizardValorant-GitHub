using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float firerate;


    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
       
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
            
        }
        Destroy(gameObject, 8);

    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        Destroy(gameObject);
    }
}
