using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateCustom : MonoBehaviour {

    public GameObject customerPrefab;
    public GameObject doorOut;
    public GameObject doorIn;

    public float repeatRate=3;

    // Use this for initialization
    void Start () {
        InvokeRepeating("createCustomer", 1, repeatRate);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void createCustomer()
    {
        GameObject customer = Instantiate(customerPrefab);
        customer.transform.position = doorIn.transform.position-new Vector3(0,.5f,0);
        customer.transform.localRotation = Quaternion.Euler(0, 180, 0); 
        NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
        agent.destination = doorOut.transform.position;
    }
}
