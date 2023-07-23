using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInfo : MonoBehaviour {
  public bool GetState() {
    return Ros2SubscriberHandler.Instance.CameraEnabled;
  }

  public string GetIP() {
    return Ros2SubscriberHandler.Instance.CameraIP;
  }

  public string GetUrl() {
    if (GetState() == false) {
      return "No camera URL";
    }
    return "http://" + GetIP() + ":81";
  }

  public string GetUrlApiRest() {
    if (GetState() == false) {
      return "No camera URL";
    }
    return "http://" + GetIP() + ":80";
  }
}
