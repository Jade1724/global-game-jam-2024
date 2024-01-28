using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    private int MAX_INGREDIENTS = 3;
    private int currentIngredientsNum = 0;

    private void OnCollisionEnter(Collision other) {
        if (GameManager.instance.currentPhase == GameManager.CookingPhase.Gathering && other.gameObject.CompareTag("Food") && currentIngredientsNum < MAX_INGREDIENTS) {
            // Check if the colliding object has a Rigidbody
            Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            
            if (otherRigidbody != null)
            {
                // Change the Rigidbody type to Static
                otherRigidbody.isKinematic = true;
                currentIngredientsNum++;

                // Optionally, you may also want to disable the collider to avoid further interactions
                other.gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
