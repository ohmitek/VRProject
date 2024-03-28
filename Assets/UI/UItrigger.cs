using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItrigger : MonoBehaviour
{

    public GameObject uiprefab;
    public GameObject uiTrigger;


    void Start()
    {
        uiprefab.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            uiprefab.SetActive(true);
            Destroy(uiTrigger);
        }
        
       

    }
}
