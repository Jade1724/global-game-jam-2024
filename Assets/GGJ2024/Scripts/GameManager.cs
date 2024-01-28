using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum CookingPhase {
        Standby,
        Gathering,
        Cutting,
        Cooking,
        Serving
    };

    private const int COOKING_DURATION = 60; 
    private const int LIFE_STEAK = 1;
    public int score;

    public CookingPhase currentPhase = CookingPhase.Standby;
    public int remainingTime = COOKING_DURATION;
    private int remainingLife = LIFE_STEAK;
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
        // Start Gathering phase after 5 seconds
        Invoke("StartGathering", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPhase == CookingPhase.Standby) {
            if (isCountingDown) {
                isCountingDown = false;
                CancelInvoke("CountDownTime");
            }
        } else {
            if (!isCountingDown) {
                isCountingDown = true;
                InvokeRepeating("CountDownTime", 0f, 1f);
            }
        }
    }

    // Transit from Standby phase to Gathering phase. 
    // Timer starts countdown. 
    void StartGathering() {
        currentPhase = CookingPhase.Gathering;
        ShowOrder.ShowOrderText();
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