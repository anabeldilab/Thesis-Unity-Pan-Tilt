using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROS2;
public class Ros2Publish : MonoBehaviour {
  private Ros2Start ros2Publisher;
  private IPublisher<std_msgs.msg.Header> action_pub;
  int n;


  void Update() {
    if (ros2Publisher==null) {
      ros2Publisher=GetComponent<Ros2Start>();
    }
  }


  public void OnUpButtonPress() {
    n++;
    Debug.Log("Button clicked " + n + " times.");
    if(ros2Publisher!=null && ros2Publisher.action_pub!=null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Up";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnDownButtonPress() {
    n++;
    Debug.Log("Button clicked " + n + " times.");
    if(ros2Publisher!=null && ros2Publisher.action_pub!=null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Down";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnLeftButtonPress() {
    n++;
    Debug.Log("Button clicked " + n + " times.");
    if(ros2Publisher!=null && ros2Publisher.action_pub!=null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Left";
      ros2Publisher.action_pub.Publish(msg);
    }
  }


  public void OnRightButtonPress() {
    n++;
    Debug.Log("Button clicked " + n + " times.");
    if(ros2Publisher!=null && ros2Publisher.action_pub!=null) {
      std_msgs.msg.Header msg = new std_msgs.msg.Header();
        
      msg.Frame_id = "ACT_/Right";
      ros2Publisher.action_pub.Publish(msg);
    }
  }
}
