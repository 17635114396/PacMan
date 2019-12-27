using UnityEngine;
using System.Collections;

public class moveball : MonoBehaviour//both codes working
    {
    public float force =10f;
    Vector3 dir = Vector3.zero;

    void Main()
        {
        // Preventing mobile devices going in to sleep mode 
        //(actual problem if only accelerometer input is used)
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

 
 
void Update () {
 
     dir.x = -Input.acceleration.y;
     dir.z = Input.acceleration.x;
     if (dir.sqrMagnitude > 1) dir.Normalize();
     GetComponent<Rigidbody>().AddForce(dir * force);
 }


    }