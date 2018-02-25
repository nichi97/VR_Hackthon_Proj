using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {
    bool locked;
	// Use this for initialization
	void Start () {
        locked = true;
	}

    public void setLocked(bool val) { locked = val; }
    public bool getLocked() { return locked; }

    // Update is called once per frame
    void Update () {
		
	}
}
