using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour {
  public TMPro.TextMeshProUGUI timerText;
  private Timer timer;

  void Start() {
    timer = Timer.Instance;
  }

  // Update is called once per frame
  void Update() {
    if (timer == null) {
      return;
    } else {
      int minutes = (int)(timer.elapsedTime / 60);
      int seconds = (int)(timer.elapsedTime % 60);
      timerText.text = string.Format("Tiempo: {0:00}:{1:00}", minutes, seconds);
    }
  }
}