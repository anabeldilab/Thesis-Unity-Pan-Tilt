using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROS2;

public class Ros2Publish : MonoBehaviour {
  private Ros2Start ros2Publisher;
  private IPublisher<std_msgs.msg.Header> action_pub;


  void Update() {
    if (ros2Publisher == null) {
      ros2Publisher = Ros2Start.Instance;
    }
  }


  public void OnConnectSAPButtonPress() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "CON_/SAP";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnDisconnectSAPButtonPress() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "CON_/DIS";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnIPCameraPress() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "CON_/CAM";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnUpNeuroButtonPress() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Up";
      ros2Publisher.action_pub.Publish(msg);
    }
  }

  public void PublishReset() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Reset";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnDownNeuroButtonPress() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Down";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnLeftNeuroButtonPress() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Left";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnRightNeuroButtonPress() {
    if(ros2Publisher != null && ros2Publisher.action_pub != null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Right";
      ros2Publisher.action_pub.Publish(msg);
    }
  }
}
