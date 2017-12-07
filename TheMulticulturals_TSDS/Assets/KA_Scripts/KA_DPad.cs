using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KA_DPad : MonoBehaviour {

    float DPad_X = Input.GetAxis("X360_DPadX");
    float DPad_Y = Input.GetAxis("X360_DPadY");
    public static int DPadID = 0;

    public GameObject[] DPadArray;

    // Use this for initialization
    void Start ()
    {
                
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (DPad_X != 0)
        {
           
        }
	}
}
