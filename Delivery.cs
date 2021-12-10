using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Delivery : MonoBehaviour
{
    
    
    [SerializeField] Color32 hasPackageColor = new Color32 (166, 248, 137, 255);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyTime = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.color = noPackageColor;
    }

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
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(other.gameObject, destroyTime);
        }
        else if (other.tag == "Destination" && hasPackage == true)
        {
            Debug.Log("Package delivered.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Destroy(other.gameObject, destroyTime);
        }
        
    }
}
