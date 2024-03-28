using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KahviAppear : MonoBehaviour
{
	public GameObject kahvi;

    private void Start()
    {
		kahvi.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Kaffepannu")
		{
			kahvi.SetActive (true);
		}

	}
}
