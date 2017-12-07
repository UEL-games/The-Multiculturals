using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KA_Canvas : MonoBehaviour
{

    public Text BulletInfo;
    public Text DPadInfo;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletInfo.text = KA_Shoot.NameOfBullet;
        DPadInfo.text = KA_Shoot.DPadID;
    }
}
