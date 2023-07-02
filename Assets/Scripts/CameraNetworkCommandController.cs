using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class CameraNetworkCommandController : MonoBehaviour {

  public CameraInfo cameraInfo;
  public TMPro.TextMeshProUGUI responseText;
  public TMPro.TMP_InputField setStateInputField;

  public void SendRestartCommand() {
    if (cameraInfo.GetState() == false) {
      return;
    }
    string command = "/app?app=0&value=0";
    StartCoroutine(SendCommand(command));
  }


  public void RequestCurrentState() {
    if (cameraInfo.GetState() == false) {
      return;
    }
    string command = "/app?app=1&value=0";
    StartCoroutine(SendCommand(command));
  }


  public void SetState() {
    
    if (cameraInfo.GetState() == false) {
      return;
    }
    int stateValue;
    if(int.TryParse(setStateInputField.text, out stateValue)) {
        Debug.Log(cameraInfo);
        string command = "/app?app=2&value=" + stateValue;
        StartCoroutine(SendCommand(command));
    } else {
        Debug.Log("Input value is not a valid integer");
    }
  }

// app=3 para parar el stream

// app=4 para reiniciar la camara

// app=5&value=0 para pillar el qr

  private IEnumerator SendCommand(string command) {
    // Construye la URL completa para la petición
    string fullUrl = cameraInfo.GetUrlApiRest() + command;
    Debug.Log(fullUrl);

    using (UnityWebRequest webRequest = UnityWebRequest.Get(fullUrl)) {
      webRequest.timeout = 60;

      // Request and wait for the desired page.
      yield return webRequest.SendWebRequest();

      string[] pages = fullUrl.Split('/');
      int page = pages.Length - 1;

      switch (webRequest.result) {
        case UnityWebRequest.Result.ConnectionError:
        case UnityWebRequest.Result.DataProcessingError:
          responseText.text = pages[page] + ": Error: " + webRequest.error;
          break;
        case UnityWebRequest.Result.ProtocolError:
          responseText.text = pages[page] + ": HTTP Error: " + webRequest.error;
          break;
        case UnityWebRequest.Result.Success:
          responseText.text = pages[page] + ":\nReceived: " + webRequest.downloadHandler.text;
          break;
      }
    }
  }
}
