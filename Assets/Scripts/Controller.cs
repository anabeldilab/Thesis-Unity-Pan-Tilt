using UnityEngine;
using UnityEngine.Events;
using NextMind.NeuroTags;

public class Controller : MonoBehaviour {
  public UnityEvent onNeuromanagerReady;

  void Start() {
      onNeuromanagerReady.Invoke();
  }
}