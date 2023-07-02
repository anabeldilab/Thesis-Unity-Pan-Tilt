using UnityEngine;
using UnityEngine.Events;
using NextMind.NeuroTags;

public class NeuroTagWrapper : MonoBehaviour
{
    // Referencia al NeuroTag real
    public NeuroTag neuroTag;

    // Referencia al controlador
    public Controller controller;

    void Start()
    {
        // Suscribirse al evento onNeuromanagerReady
        controller.onNeuromanagerReady.AddListener(OnNeuromanagerReady);
    }

    public void OnNeuromanagerReady()
    {
        neuroTag = GetComponent<NeuroTag>();
        // Aquí es donde obtendrías tu referencia al Neuromanager
    }
}
