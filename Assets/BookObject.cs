using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookObject : InteractiveRaycastObject
{

    protected new void Start()
    {
        base.Start();
        reading = false;
    }
    /*
    public void setPwMode(bool val) { pwMode = val; }
    public bool getPwMode() { return pwMode; }
    */

    [SerializeField]
    Canvas page1;
    [SerializeField]
    Canvas page2;
    [SerializeField]
    Canvas page3;
    [SerializeField]
    Canvas page4;
    [SerializeField]
    Canvas page5;
    [SerializeField]
    Canvas page6;
    bool reading;

    // Update is called once per frame
    protected new void Update()
    {
        if (getInInteraction())
        {
            if (!reading)
            {
                reading = true;
                page1.GetComponent<Page>().gameObject.SetActive(true);
            }
            else
            {
                if (OVRInput.Get(OVRInput.Button.One)
                    || OVRInput.Get(OVRInput.Button.Two)
                    || OVRInput.Get(OVRInput.Button.Three)
                    || OVRInput.Get(OVRInput.Button.Four))
                {
                    if (page1.GetComponent<Page>().gameObject.activeInHierarchy)
                    {
                        page1.GetComponent<Page>().gameObject.SetActive(false);
                        page2.GetComponent<Page>().gameObject.SetActive(true);
                    }
                    else if (page2.GetComponent<Page>().gameObject.activeInHierarchy)
                    {
                        page2.GetComponent<Page>().gameObject.SetActive(false);
                        page3.GetComponent<Page>().gameObject.SetActive(true);
                    }
                    else if (page3.GetComponent<Page>().gameObject.activeInHierarchy)
                    {
                        page3.GetComponent<Page>().gameObject.SetActive(false);
                        page4.GetComponent<Page>().gameObject.SetActive(true);
                    }
                    else if (page4.GetComponent<Page>().gameObject.activeInHierarchy)
                    {
                        page4.GetComponent<Page>().gameObject.SetActive(false);
                        page5.GetComponent<Page>().gameObject.SetActive(true);
                    }
                    else if (page5.GetComponent<Page>().gameObject.activeInHierarchy)
                    {
                        page5.GetComponent<Page>().gameObject.SetActive(false);
                        page6.GetComponent<Page>().gameObject.SetActive(true);
                    }
                    else if (page6.GetComponent<Page>().gameObject.activeInHierarchy)
                    {
                        page6.GetComponent<Page>().gameObject.SetActive(false);
                        setInInteraction(false);
                        reading = false;
                    }
                }
            }
        }

        base.Update();


    }
}
