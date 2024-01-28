using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowOrder : MonoBehaviour
{
    public static string orderText;
    public static TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        orderText = "Red Chunky Hot Meat";
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public static void ShowOrderText() {
        textMeshPro.text = orderText;
    }
}
