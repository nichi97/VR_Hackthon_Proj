using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour {

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
        //Ray myRay = new Ray(this.transform.position, this.transform.forward);
        //Debug.DrawRay(myRay.origin, myRay.direction * 1000.0f);
        RaycastHit hitObject;
        if (Physics.SphereCast(transform.position, 10f, transform.forward, out hitObject, Mathf.Infinity))
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
                    rayCastHitObject.TurnOffMessage();
                }
                else
                {
                    rayCastHitObject.OnRayCast(hitObject);
                    hitTimeLength += Time.deltaTime;
                    Debug.LogFormat("Staying at {0} for {1} sec", hitObject.collider.gameObject.name, hitTimeLength);

                    //show internal mind
                    if (!rayCastHitObject.haveSeenMsg && hitTimeLength >= 4)
                    {
                        Debug.LogFormat("Turn on HintBox");
                        rayCastHitObject.TurnOnMessage();
                    }
                    else if (rayCastHitObject.haveSeenMsg && hitTimeLength >= 1.5)
                    {
                        Debug.LogFormat("Turn on HintBox");
                        rayCastHitObject.TurnOnMessage();
                    }
                }
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
    


}
