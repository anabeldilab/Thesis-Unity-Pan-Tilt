using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorCountUI : MonoBehaviour {
  public TMPro.TextMeshProUGUI errorCountText;
  private ErrorCounter errorCounter;

  void Start() {
    errorCounter = ErrorCounter.Instance;
  }

  void Update() {
    errorCountText.text = "Errors: " + errorCounter.GetErrorCount().ToString();
  }
}
