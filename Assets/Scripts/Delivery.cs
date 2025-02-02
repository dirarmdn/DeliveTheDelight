using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        Debug.Log(hasPackage);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    { 
        Debug.Log("Ouch");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;
        } 
        
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Delivered Package");
            spriteRenderer.color = noPackageColor;
            Destroy(other.gameObject, destroyDelay);
            hasPackage = false;
        }
    }
}
