
using UnityEngine;
using 

public class Gazer : MonoBehaviour {

    private RaycastObject lastRaycastObject;
    float hitTimeLength;
    bool enabled;

    // Use this for initialization
    void Start()
    {
        hitTimeLength = 0;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //when the gazed object is interactive raycast object
        if (!enabled && lastRaycastObject is InteractiveRaycastObject)
        {
            if ()
            lastRaycastObject.TurnOffMessage();
            return;
        }

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
                    if ( (!rayCastHitObject.haveSeenMsg && hitTimeLength >= 4)
                            || (rayCastHitObject.haveSeenMsg && hitTimeLength >= 1.5) )
                    {
                        if (rayCastHitObject is InteractiveRaycastObject)
                            enabled = false;
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
