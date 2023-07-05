using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageStreamUrlUI : MonoBehaviour {
  public CameraInfo cameraInfo;
  public TMPro.TextMeshProUGUI errorText;

  private ImageStreamUrl imageStreamUrl;

  void Start() {
    // get instance of ImageStreamUrl
    imageStreamUrl = ImageStreamUrl.Instance;
    
    imageStreamUrl.Initialize(cameraInfo, errorText);
  }

  public void StartStream() {
    imageStreamUrl.StartStream();
  }
}
