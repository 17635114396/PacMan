using UnityEngine;
using System.Collections;


using UnityStandardAssets.CrossPlatformInput;
public class ballmove2 : MonoBehaviour {

	public float speed = 1000;

    void Main()
        {
        // Preventing mobile devices going in to sleep mode 
        //(actual problem if only accelerometer input is used)
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

    void Update()
        {

        if (SystemInfo.deviceType == DeviceType.Desktop)
            {
            // Exit condition for desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
            }
        else
            {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
            }



        }


    void FixedUpdate()
        {
     

            {
         

            // Definition of force vector X and Y components
            float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
            // Building of force vector
            Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
            // Adding force to rigidbody
           GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
            }
        
       


        }

}


