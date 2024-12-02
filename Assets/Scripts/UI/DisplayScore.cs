using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI classes like Text.

// Display Current Score 
// if you attach this to game scene, it updates score as the player collect coins
// for UI scenes such as GameOver, it just displays the total score 
public class DisplayScore : MonoBehaviour
{
    [Header("Dynamic")] 
    private TextMeshProUGUI uiText;

    void Start() {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        uiText.text = ScoreManager.DisplayScore();
        //uiText.text = ScoreManager.score.ToString("#,0"); // This 0 is a zero!
    }
}
