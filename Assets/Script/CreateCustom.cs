using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CreateCustom : MonoBehaviour
{

    public GameObject customerPrefab;
    public GameObject doorOut;
    public GameObject doorIn;

    public float repeatRate = 3;

    public Button openButton;
    public Text openText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void createCustomer()
    {
        GameObject customer = Instantiate(customerPrefab);
        customer.transform.position = doorIn.transform.position - new Vector3(0, .5f, 0);
        customer.transform.localRotation = Quaternion.Euler(0, 180, 0);
        NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
        agent.destination = doorOut.transform.position;
    }

    public void startCreateCustomer()
    {
        if (openText.text.Equals("open"))
        {
            openText.text = "close";
            InvokeRepeating("createCustomer", 1, repeatRate);
        }
        else if (openText.text.Equals("close"))
        {
            openText.text = "open";
            CancelInvoke();
        }
    }
}
