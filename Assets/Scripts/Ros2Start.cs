using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROS2;

public class Ros2Start : MonoBehaviour {
  private ROS2UnityComponent ros2Unity;
  private ROS2Node ros2Node;
  public IPublisher<std_msgs.msg.Header> action_pub;
  private ISubscription<std_msgs.msg.Header> esp32_sub;


  // Start is called before the first frame update
  void Start() {

    ros2Unity=GetComponent<ROS2UnityComponent>();
    if (ros2Unity.Ok()) {
      ros2Node = ros2Unity.CreateNode("ROS2UnityPublisherSubscriberNode");
    } else {
      Debug.Log("Ros2Unity was not created OK");
    }
    if (ros2Unity.Ok()) {
      action_pub = ros2Node.CreatePublisher<std_msgs.msg.Header>("action"); 
      esp32_sub=ros2Node.CreateSubscription<std_msgs.msg.Header>("freertos_header_log", 
        msg => Debug.Log("Unity listener heard: [" + msg.Frame_id + "]"));

      std_msgs.msg.Header msg = new std_msgs.msg.Header();
      msg.Frame_id = "NULL/";
      action_pub.Publish(msg);
    }
  }
}
