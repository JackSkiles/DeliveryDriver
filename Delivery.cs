using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Delivery : MonoBehaviour
{
    
    bool hasPackage;
    bool delivered = true;


    void OnCollisionEnter2D(Collision2D other)
    {
        string[] phrases = new string[6];
        phrases[0] = "Damn!";
        phrases[1] = "That's the last time I drink and drive";
        phrases[2] = "This is worse than the time.";
        phrases[3] = "I hope that was a speed bump.";
        phrases[4] = "Yow!";
        phrases[5] = "Can't think of anything more to say.";
        int phrase = Random.Range(0, 6);
        Debug.Log(phrases[phrase]);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && delivered == true)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            delivered = false;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Destination" && hasPackage == true)
        {
            Debug.Log("Package delivered.");
            delivered = true;
            hasPackage = false;
            Destroy(other.gameObject);
        }
        
    }
}
