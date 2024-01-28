using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    private int MAX_INGREDIENTS = 1;
    private int currentIngredientsNum = 0;

    private void OnCollisionEnter(Collision other) {
        if (GameManager.currentPhase == GameManager.CookingPhase.Gathering && other.gameObject.CompareTag("Food") && currentIngredientsNum < MAX_INGREDIENTS) {
            // Check if the colliding object has a Rigidbody
            Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            
            if (otherRigidbody != null)
            {
                // Change the Rigidbody type to Static
                otherRigidbody.isKinematic = true;
                currentIngredientsNum++;
                
                // Put the other object into ingredientsBoard;
                GameManager.ingredientsUnderCooking.Add(other.gameObject);

                // Optionally, you may also want to disable the collider to avoid further interactions
                // other.gameObject.GetComponent<Collider>().enabled = false;

                if (currentIngredientsNum == MAX_INGREDIENTS) {
                    GetComponent<AudioSource>().Play();
                    GameManager.currentPhase = GameManager.CookingPhase.Cutting;
                }
            }
        }

        if (GameManager.currentPhase == GameManager.CookingPhase.Cutting && other.gameObject.CompareTag("Destroyer")) {
            GetComponent<AudioSource>().Play();
            foreach (GameObject obj in GameManager.ingredientsUnderCooking) {
                obj.GetComponent<Renderer>().enabled = false;
            }
            GameManager.currentPhase = GameManager.CookingPhase.Cooking;
        }
    }
}
