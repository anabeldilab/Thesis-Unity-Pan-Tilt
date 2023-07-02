using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraStatusUI : MonoBehaviour { 
  public CameraInfo cameraInfo;
  public Image statusImage;

  // text (TMP) to show the IP address
  public TMPro.TextMeshProUGUI ipText;

  // Start is called before the first frame update
  void Start() {
    // Assume cameraInfo and Image are attached to the GameObject
    if (cameraInfo == null) {
      cameraInfo = GetComponent<CameraInfo>();
    }

    if (statusImage == null) {
      statusImage = GetComponent<Image>();
    }
  }

  // Update is called once per frame
  void Update() {
    if (cameraInfo.GetState()) {
      statusImage.color = Color.green;
    } else {
      statusImage.color = Color.red;
    }

    ipText.text = "Camera IP: " + cameraInfo.GetIP();
  }
}
