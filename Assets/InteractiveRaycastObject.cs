using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycastObject : RaycastObject {

    bool inInteraction;

	// Use this for initialization
	protected new void Start () {
        base.Start();
        inInteraction = false;
	}

    public void setInInteraction(bool val) { inInteraction = val; }
    public bool getInInteraction() { return inInteraction; }
	
    [SerializeField]

	// Update is called once per frame
	protected new void Update () {
        if (!inInteraction && messageOn)
        {
            //quit pwmode
            if (OVRInput.Get(OVRInput.Button.One)
                || OVRInput.Get(OVRInput.Button.Two)
                || OVRInput.Get(OVRInput.Button.Three)
                || OVRInput.Get(OVRInput.Button.Four))
            {
                Debug.LogFormat("Got button one pressed");
                this.TurnOffMessage();
                setInInteraction(true);
            }
        }
        base.Update();

    }
}
