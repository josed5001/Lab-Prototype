using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockScript : MonoBehaviour
{
   public TextMeshProUGUI textMeshPro;
    void Update()
    {
        float time = Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        string clockText = string.Format("{0:00}:{1:00}", minutes, seconds);
        textMeshPro.SetText(clockText);

    }
}
