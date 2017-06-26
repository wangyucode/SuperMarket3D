using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCustomer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Door_Out"))
        {
            Destroy(gameObject);
        }
    }
}
