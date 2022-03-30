using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NativeEventReceiver : MonoBehaviour
{
    private static GameObject? instance = null;

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        if (instance == null) {
            instance = new GameObject("NativeEventReceiver");
            instance.AddComponent<NativeEventReceiver>();
        }
    }

    private class InitializeMessage {
        public string language;
        public string chapter;

        public static InitializeMessage CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<InitializeMessage>(jsonString);
        }
    }

    public void ExternalInitialize(string message) {
        InitializeMessage decodedMessage = InitializeMessage.CreateFromJSON(message);
        string language = decodedMessage.language;
        string chapter = decodedMessage.chapter;
        string langIndexStr = language == "en" ? "0" : "1";
        LobbyController lobbyController = GameObject.Find("LobbyController").GetComponent<LobbyController>();
        lobbyController.ExternalLoadBook(chapter);
        lobbyController.ExternalSetLandguage(langIndexStr);
    }
}
