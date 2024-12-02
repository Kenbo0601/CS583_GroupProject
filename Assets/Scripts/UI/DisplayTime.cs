using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTime : MonoBehaviour
{
    [Header("Dynamic")] 
    private TextMeshProUGUI gt;
    
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        // Ensure that the component exists
        if (gt == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on this GameObject.");
        }
    }

    void Update()
    {
        TimeManager.UpdateTime();
        gt.text = TimeManager.DisplayTime();
    } 
}
