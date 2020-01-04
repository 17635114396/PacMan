using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class moveball2 : MonoBehaviour {

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
     //   if (SystemInfo.deviceType == DeviceType.Desktop)
            {
            // Player movement in desktop devices

            // Definition of force vector X and Y components
            float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
            // Building of force vector
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            // Adding force to rigidbody
           GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
            }
        
        ////else//rmj accelerometer removed
        ////    {
        ////    // Player movement in mobile devices

        ////    // Building of force vector 
        ////    Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
        ////    // Adding force to rigidbody
        ////    GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        ////    }


        }

}
