using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingObject : InteractiveRaycastObject
{

    protected new void Start()
    {
        base.Start();
        
    }
    /*
    public void setPwMode(bool val) { pwMode = val; }
    public bool getPwMode() { return pwMode; }
    */

    [SerializeField]
    Canvas page;
    // Update is called once per frame
    protected new void Update()
    {
        if (getInInteraction())
        {
            page.GetComponent<Page>().gameObject.SetActive(true);
            if (OVRInput.Get(OVRInput.Button.One)
                || OVRInput.Get(OVRInput.Button.Two)
                || OVRInput.Get(OVRInput.Button.Three)
                || OVRInput.Get(OVRInput.Button.Four))
            {
                setInInteraction(false);
                page.GetComponent<Page>().gameObject.SetActive(false);
            }
        }

        base.Update();


    }
}
