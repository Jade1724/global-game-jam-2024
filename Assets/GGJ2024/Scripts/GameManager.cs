using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

     // Singleton instance
    private static GameManager instance;

    private void Awake() {
         // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game manager started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
