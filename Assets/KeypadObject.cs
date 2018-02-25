using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadObject : InteractiveRaycastObject
{

    bool pwMode;

	// Use this for initialization
	protected new void Start () {
        base.Start();
        pwMode = false;
	}

    public void setPwMode(bool val) { pwMode = val; }
    public bool getPwMode() { return pwMode; }

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
        
        base.Update();
        
		
	}

}
