using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObject : MonoBehaviour {

    public virtual void OnRaycastEnter(RaycastHit hitInfo)
    {
        Debug.LogFormat("Raycast entered on {0}", gameObject.name);
    }

    public virtual void OnRayCast(RaycastHit hitInfo)
    {   
        Debug.LogFormat("Raycast stayed on {0}", gameObject.name);

    }

    public virtual void OnRaycastExit()
    {
        Debug.LogFormat("Raycast exited on {0}", gameObject.name);
    }

}
