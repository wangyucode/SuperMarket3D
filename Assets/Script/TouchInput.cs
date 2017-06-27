using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public LayerMask floorLayer;
    public GameObject counterPrefab;
    public float counterHeight= 0.5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition = Vector2.zero;
        bool isTouched = false;
#if UNITY_STANDALONE|| UNITY_EDITOR
        if (Input.GetMouseButtonUp(0))
        {
            touchPosition = Input.mousePosition;
            isTouched= true;
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchPosition = Input.GetTouch(0).position;
            isTouched = true;
        }
#endif
        if (isTouched)
        {
            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            // Create a particle if hit
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo,50, floorLayer))
            {
                generateCounter(hitInfo);
                
            }

        }
    }

    private void generateCounter(RaycastHit hitInfo)
    {
        Vector3 formatPosition = hitInfo.point;
        formatPosition.x = (int)formatPosition.x + 0.5f;
        formatPosition.y = counterHeight;
        formatPosition.z = (int)formatPosition.z + 0.5f;

        GameObject counter = Instantiate(counterPrefab);
        counter.transform.position = formatPosition;
    }
}
