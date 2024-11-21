using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI classes like Text.

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")] 
    private TextMeshProUGUI uiText;

    void Start() {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        uiText.text = ScoreManager.score.ToString("#,0"); // This 0 is a zero!
    }
}
