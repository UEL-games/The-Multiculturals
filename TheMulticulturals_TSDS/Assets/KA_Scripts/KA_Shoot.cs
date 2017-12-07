using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KA_Shoot : MonoBehaviour
{
    // Variables
    public static int BulletID = 0;
    public static string NameOfBullet;
    public GameObject[] BulletArray;
    public Transform BulletSpawn;

    float FireRate = 0.3f;
    float Timer;

    public static string DPadID;
   
    // Use this for initialization
    void Start ()
    {
        BulletName();
	}
	
	// Update is called once per frame
	void Update ()
    {   
        
        // Controller Variables
        float DPad_X = Input.GetAxis("X360_DPadX");
        float DPad_Y = Input.GetAxis("X360_DPadY");
        float TriggerAxis = Input.GetAxis("X360_Triggers");


        if (DPad_X < 0)
        {
            DPadID = "Left";
        }
        else if (DPad_X > 0)
        {
            DPadID = "Right";
        }
        else if (DPad_Y > 0)
        {
            DPadID = "Up";
        }
        else if (DPad_Y < 0)
        {
            DPadID = "Down";
        }



        if (Input.GetButtonDown("X360_RBumper"))
        {
            ChangeBullet();
        }

        if (TriggerAxis < 0)
        {
            Timer = Timer + 1 * Time.deltaTime;
            if (Timer > FireRate)
            {
                Fire();
                Timer = Timer - FireRate;
            }
            else
            {
            }
        }


    }    
    void ChangeBullet()
    {
        // Checks what the bullet number is, if its more not 3 increment number

        if (BulletID != 3 && Input.GetButtonDown("X360_RBumper"))
        {
            BulletID++;
            BulletName();
        }
        else if (BulletID == 3 && Input.GetButtonDown("X360_RBumper"))
        {
            BulletID = 0;
            BulletName();
        }
    }
    void BulletName()
    {

        // Change bullet name for canvas to access
        if (BulletID == 0)
        {
            NameOfBullet = "Black Bullet";
        }
        else if (BulletID == 1)
        {
            NameOfBullet = "Blue Bullet";
        }
        else if (BulletID == 2)
        {
            NameOfBullet = "Green Bullet";
        }
        else if (BulletID == 3)
        {
            NameOfBullet = "Red Bullet";
        }
    }

    void Fire()
    {        

        //Create the bullet from the bullet prefab and type
        var Bullet = (GameObject)Instantiate(BulletArray[BulletID], BulletSpawn.position, BulletSpawn.rotation);


        //Add velocity to the bullet.
        Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * 12;

        //Destroy the bullet after two seconds.
        Destroy(Bullet, 3f);
    }
}
