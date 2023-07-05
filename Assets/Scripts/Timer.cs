using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
  public static Timer Instance { get; private set; }

  public bool isTimerRunning = false;
  public float startTime = 0f;
  public float elapsedTime { get; private set; } = 0f;
  
  private void Awake() {
    if (Instance == null) {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
      return;
    }
  }

  private void Update() {
    // si presiono tecla T, inicio el tiempo
    if (Input.GetKeyDown(KeyCode.T)) {
      StartTime();
    }
    // si presiono tecla R, reinicio el tiempo
    if (Input.GetKeyDown(KeyCode.R)) {
      startTime = Time.time;
      elapsedTime = 0f;
    }
    // si presiono tecla P, pauso el tiempo
    if (Input.GetKeyDown(KeyCode.P)) {
      isTimerRunning = !isTimerRunning;
    }
    if (isTimerRunning) {
      UpdateTime();
    }
  }

  public void StartTime() {
    startTime = Time.time;
  }

  public void UpdateTime() {
    elapsedTime = Time.time - startTime;
  }
}