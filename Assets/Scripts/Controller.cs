using UnityEngine;
using UnityEngine.Events;
using NextMind.NeuroTags;

public class Controller : MonoBehaviour {
  // Este es el evento que dispararemos cuando el Neuromanager esté listo
  public UnityEvent onNeuromanagerReady;

  void Start() {
      onNeuromanagerReady.Invoke();
  }
}