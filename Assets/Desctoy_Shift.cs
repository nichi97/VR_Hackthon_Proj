using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Desctoy_Shift : MonoBehaviour {
    private object Camera1;
    private object Camera2;

    // Use this for initialization
    void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {

        yield return new WaitForSeconds(2);
        Camera1.enabled = false;
        Camera2.enabled = true; 
		
	}
}
