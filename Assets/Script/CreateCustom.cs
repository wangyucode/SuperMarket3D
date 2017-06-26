using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateCustom : MonoBehaviour {

    public GameObject customerPrefab;
    public GameObject doorOut;
    public GameObject doorIn;

    // Use this for initialization
    void Start () {
        InvokeRepeating("createCustomer", 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void createCustomer()
    {
        GameObject customer = Instantiate(customerPrefab);
        customer.transform.position = doorIn.transform.position;
        customer.transform.localRotation = Quaternion.Euler(0, 180, 0); 
        NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
        agent.destination = doorOut.transform.position;
    }
}
