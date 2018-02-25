using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    [SerializeField]
    GameObject keypad;
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    // Use this for initialization
    void Start () {
        player1.SetActive(true);
        player2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!keypad.GetComponent<KeypadObject>().getLocked())
        {
            player1.SetActive(false);
            player2.SetActive(true);
        }

	}
}
