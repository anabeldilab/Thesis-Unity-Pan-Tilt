using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class CameraNetworkCommandController : MonoBehaviour {

  public CameraInfo cameraInfo;
  public TMPro.TextMeshProUGUI responseText;
  public TMPro.TMP_InputField setStateInputField;

  public void SendRestartCommand() {
    responseText.text = "";
    if (cameraInfo.GetState() == false) {
      Debug.Log("Camera is not enabled");
      responseText.text = "Command error: Camera is not enabled";
      return;
    }
    string command = "/app?app=0&value=0";
    Debug.Log("Sending command: " + command);
    StartCoroutine(SendCommand(command));
  }


  public void RequestCurrentState() {
    responseText.text = "";
    if (cameraInfo.GetState() == false) {
      Debug.Log("Camera is not enabled");
      responseText.text = "Command error: Camera is not enabled";
      return;
    }
    string command = "/app?app=1&value=0";
    Debug.Log("Sending command: " + command);
    StartCoroutine(SendCommand(command));
  }


  public void SetState() {
    responseText.text = "";
    if (cameraInfo.GetState() == false) {
      Debug.Log("Camera is not enabled");
      responseText.text = "Command error: Camera is not enabled";
      return;
    }
    int stateValue;
    if(int.TryParse(setStateInputField.text, out stateValue)) {
        Debug.Log(cameraInfo);
        string command = "/app?app=2&value=" + stateValue;
        Debug.Log("Sending command: " + command);
        StartCoroutine(SendCommand(command));
    } else {
        Debug.Log("Input value is not a valid integer");
        responseText.text = "Command error: Input value is not a valid integer";
    }
  }


  public void StopStream() {
    responseText.text = "";
    if (cameraInfo.GetState() == false) {
      Debug.Log("Camera is not enabled");
      responseText.text = "Command error: Camera is not enabled";
      return;
    }
    string command = "/app?app=3&value=0";
    Debug.Log("Sending command: " + command);
    StartCoroutine(SendCommand(command));
  }


  public void StopCamera() {  // TODO: This is not working
    responseText.text = "";
    if (cameraInfo.GetState() == false) {
      Debug.Log("Camera is not enabled");
      responseText.text = "Command error: Camera is not enabled";
      return;
    }
    string command = "/app?app=3&value=1";
    Debug.Log("Sending command: " + command);
    StartCoroutine(SendCommand(command));
  }


  public void RestartCamera() {
    responseText.text = "";
    if (cameraInfo.GetState() == false) {
      Debug.Log("Camera is not enabled");
      responseText.text = "Command error: Camera is not enabled";
      return;
    }
    string command = "/app?app=4&value=0";
    Debug.Log("Sending command: " + command);
    StartCoroutine(SendCommand(command));
  }


  public void GetQR() {
    responseText.text = "";
    if (cameraInfo.GetState() == false) {
      Debug.Log("Camera is not enabled");
      responseText.text = "Command error: Camera is not enabled";
      return;
    }
    string command = "/app?app=5&value=0";
    Debug.Log("Sending command: " + command);
    StartCoroutine(SendCommand(command));
  }


  private IEnumerator SendCommand(string command) {
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
