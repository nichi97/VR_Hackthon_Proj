using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadObject : InteractiveRaycastObject
{

    bool pwMode;
    bool locked;

    public void setLocked(bool val) { locked = val; }
    public bool getLocked() { return locked; }

    // Use this for initialization
    protected new void Start () {
        base.Start();
        pwMode = false;
        locked = true;
	}

    public void setPwMode(bool val) { pwMode = val; }
    public bool getPwMode() { return pwMode; }

    [SerializeField]
    GameObject door;

    // Update is called once per frame
    protected new void Update () {
        if (pwMode)
        {
            if (OVRInput.Get(OVRInput.Button.Three)
                || OVRInput.Get(OVRInput.Button.Four))
            {
                pwMode = false;
                setInInteraction(false);
            }
        }
        if (!locked)
        {
            door.SetActive(false);
        }

        
        base.Update();
        
		
	}

}
