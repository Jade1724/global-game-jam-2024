using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowRemainingTime : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = GameManager.instance.remainingTime.ToString();
    }
}
