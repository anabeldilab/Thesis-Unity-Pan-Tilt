using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorNumText : MonoBehaviour {
  public TMPro.TextMeshProUGUI errorNumText;
  private ErrorCounter errorCounter;

  void Start() {
    errorCounter = ErrorCounter.Instance;
  }

  void Update() {
    errorNumText.text = errorCounter.GetErrorCount().ToString();
  }
}
