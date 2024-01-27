using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum CookingPhase {
        Standby,
        Gathering,
        Cutting,
        Cooking,
        Serving
    };

    public const int COOKING_DURATION = 60; 
    public int score;

    private CookingPhase currentPhase = CookingPhase.Standby;
    public int remainingTime = COOKING_DURATION;
    private int remainingLife;
    private bool isCountingDown;


     // Singleton instance
    public static GameManager instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPhase != CookingPhase.Standby && !isCountingDown) {
            isCountingDown = true;
            InvokeRepeating("CountDownTime", 0f, 1f);
        } else {
            if (isCountingDown) {
                CancelInvoke("CountDownTime");
            }
        }
    }

    void CountDownTime() {
        remainingTime--;
        if (remainingTime <= 0) {
                remainingLife--;
                if (remainingLife == 0) {
                    Debug.Log("Game Over");
                } else {
                    remainingTime = COOKING_DURATION;
                    currentPhase = CookingPhase.Standby;
                }
            }
    }
}