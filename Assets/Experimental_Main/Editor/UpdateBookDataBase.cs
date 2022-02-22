using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UpdateBookDataBase : MonoBehaviour
{
    [MenuItem("CustomTools/Update BookDB")]
    public static void Refresh() {
        LobbyController lobbyController = GameObject.Find("LobbyController").GetComponent<LobbyController>();

        if (lobbyController == null) { return; }

        var bookAssetPath = Directory.GetFiles(Path.Combine(Application.dataPath, "Experimental_Main/Lobby/DataObject/BookObject"), "*asset", SearchOption.TopDirectoryOnly);

        AssetDatabase.StartAssetEditing();

        List<BookItem> bookObjList = new List<BookItem>();
        foreach (string path in bookAssetPath) {
            var assets = AssetDatabase.LoadAllAssetsAtPath(path.Substring(path.IndexOf("Asset", StringComparison.Ordinal)));
            foreach (var asset in assets) {
                try {
                    BookItem bookItem = (BookItem)asset;
                    bookObjList.Add(bookItem);
                } catch (InvalidCastException) { }
            }
        }

        lobbyController.bookDB.books = bookObjList; 
        AssetDatabase.StopAssetEditing();
        EditorUtility.SetDirty(lobbyController.bookDB);
        AssetDatabase.SaveAssets();
        Debug.Log("Book Database updated");
    }
}
