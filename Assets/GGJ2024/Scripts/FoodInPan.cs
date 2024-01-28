using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInPan : MonoBehaviour
{
    public static Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        HideFoodInPan();
    }

    public static void ShowFoodInPan() {
        renderer.enabled = true;
    }
    public static void HideFoodInPan() {
        renderer.enabled = false;
    }
}
