using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : RaycastObject {

    private RaycastObject lastRaycastObject;
    float hitTimeLength;

    // Use this for initialization
    void Start()
    {
        hitTimeLength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ray myRay = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(myRay.origin, myRay.direction * 1000.0f);
        RaycastHit hitObject;
        if (Physics.Raycast(myRay, out hitObject, Mathf.Infinity))
        {
            RaycastObject rayCastHitObject = hitObject.collider.GetComponent<RaycastObject>();
            if (rayCastHitObject != null)
            {
                if (rayCastHitObject != lastRaycastObject)
                {
                    if (lastRaycastObject != null)
                        lastRaycastObject.OnRaycastExit();
                    rayCastHitObject.OnRaycastEnter(hitObject);
                    lastRaycastObject = rayCastHitObject;
                    hitTimeLength = 0;
                }
                else
                    rayCastHitObject.OnRayCast(hitObject);
            }

            else if (lastRaycastObject != null)
            {
                lastRaycastObject.OnRaycastExit();
                lastRaycastObject = null;
                hitTimeLength = 0;
            }
        }
        else if (lastRaycastObject != null)
        {
            lastRaycastObject.OnRaycastExit();
            lastRaycastObject = null;
            hitTimeLength = 0;
        }
    }

    private void FixedUpdate()
    {
        //show the internal mind
        Ray myRay = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(myRay.origin, myRay.direction * 1000.0f);
        RaycastHit hitObject;
        if (Physics.Raycast(myRay, out hitObject, Mathf.Infinity))
        { 
            RaycastObject rayCastHitObject = hitObject.collider.GetComponent<RaycastObject>();
            if (rayCastHitObject != null && rayCastHitObject == lastRaycastObject)
            {
                hitTimeLength += Time.deltaTime;
                Debug.LogFormat("Staying at {0} for {1} sec", hitObject.collider.gameObject.name, hitTimeLength);
            }
        }
        if (hitTimeLength >= 5)
        {
            Debug.LogFormat("Hello");
        }
    }
}
