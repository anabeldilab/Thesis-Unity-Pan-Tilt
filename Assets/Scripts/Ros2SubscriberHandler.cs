using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ros2SubscriberHandler : MonoBehaviour
{
  public static Ros2SubscriberHandler Instance { get; private set; }

  private Ros2Start ros2Subscriber;
  public bool CameraEnabled { get; set; }
  public string CameraIP { get; set; }
  public bool ESP32Enabled { get; set; }

  private void Awake() {
    if (Instance != null) {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  void Start() {
    CameraEnabled = false;
    CameraIP = "No camera IP";
    ESP32Enabled = false;
  }

  // Manage the event of receiving a message
  void OnEnable() {
    if (ros2Subscriber == null) {
      ros2Subscriber = GetComponent<Ros2Start>();
      if (ros2Subscriber != null) {
        ros2Subscriber.OnMessageReceived += ProcessReceivedMessage;
      }
    } else {
      ros2Subscriber.OnMessageReceived += ProcessReceivedMessage;
    }
  }

  void ProcessReceivedMessage(std_msgs.msg.Header msg) {
    string[] parts = msg.Frame_id.Split(' ');

    if (parts.Length >= 6 && parts[0] == "Ip" && parts[1] == "assigned" && parts[2] == "to" && parts[3] == "a" && parts[4] == "non-target" && parts[5] == "station") {
      CameraEnabled = true;
      CameraIP= parts[6];
      Debug.Log("IP camera: " + CameraIP);
    }

    if (parts.Length >= 3 && parts[0] == "Camera" && parts[1] == "ip:") {
      CameraEnabled = true;
      CameraIP = parts[2];
      Debug.Log("IP camera: " + CameraIP);
    }

    if (parts.Length >= 2 && parts[0] == "Station" && parts[1] == "disconnected") {
      CameraEnabled = false;
      CameraIP = "No camera IP";
      Debug.Log("Camera disabled");
    }

    if (parts.Length >= 4 && parts[0] == "Wifi" && parts[1] == "init" &&  parts[2] == "softap" && parts[3] == "finished") {
      ESP32Enabled = true;
      Debug.Log("ESP32 enabled");
    }

    //Unity listener heard: [Stopping WiFi in base station]
    if (parts.Length >= 4 && parts[0] == "Stopping" && parts[1] == "WiFi" &&  parts[2] == "in" && parts[3] == "base" && parts[4] == "station") {
      ESP32Enabled = false;
      Debug.Log("ESP32 disabled");
      CameraIP = "No camera IP";
      CameraEnabled = false;
    }


  }
}
