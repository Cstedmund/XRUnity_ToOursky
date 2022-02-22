using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UpdateAssetReferences : MonoBehaviour {
    [MenuItem("CustomTools/UpdateEthnicDB")]
    public static void Refresh() {
        EthnicDatabase ethnicDatabase = GameObject.Find("EthnicDatabase").GetComponent<EthnicDatabase>();

        if (ethnicDatabase == null) { return; }

        var csvAssetPaths = Directory.GetFiles(Path.Combine(Application.dataPath, "Experimental_Main/AR/BodyTrack/Scripts"), "*.csv", SearchOption.TopDirectoryOnly);
        //var mapAssetPaths = Directory.GetFiles(Path.Combine(Application.dataPath, "UI/EthnicGroups"), "*.png", SearchOption.TopDirectoryOnly);
        //var previewAssetPaths = Directory.GetFiles(Path.Combine(Application.dataPath, "UI/PreviewClothes"), "*.png", SearchOption.TopDirectoryOnly);
        var modelAssetPaths = Directory.GetFiles(Path.Combine(Application.dataPath, "Experimental_Main/AR/BodyTrack/Clothes/Models"), "*.prefab", SearchOption.TopDirectoryOnly);
        var textureAssetPaths = Directory.GetFiles(Path.Combine(Application.dataPath, "Experimental_Main/AR/BodyTrack/Clothes/Textures"), "*.png", SearchOption.AllDirectories);

        AssetDatabase.StartAssetEditing();

        //Dictionary<string, Sprite> mapImages = new Dictionary<string, Sprite>();
        //foreach (string path in mapAssetPaths) {
        //    var assets = AssetDatabase.LoadAllAssetsAtPath(path.Substring(path.IndexOf("Asset", StringComparison.Ordinal)));
        //    foreach (var asset in assets) {
        //        try {
        //            Sprite sprite = (Sprite)asset;
        //            mapImages.Add(sprite.name, sprite);
        //        }
        //        catch (InvalidCastException) { }
        //    }
        //}

        //Dictionary<string, Sprite> previewImages = new Dictionary<string, Sprite>();
        //foreach (string path in previewAssetPaths) {
        //    var assets = AssetDatabase.LoadAllAssetsAtPath(path.Substring(path.IndexOf("Asset", StringComparison.Ordinal)));
        //    foreach (var asset in assets) {
        //        try {
        //            Sprite sprite = (Sprite)asset;
        //            previewImages.Add(sprite.name, sprite);
        //        } catch (InvalidCastException) { }
        //    }
        //}

        Dictionary<string, GameObject> modelPrefabs = new Dictionary<string, GameObject>();
        foreach (string path in modelAssetPaths) {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path.Substring(path.IndexOf("Asset", StringComparison.Ordinal)));
            modelPrefabs.Add(prefab.name, prefab);
        }

        Dictionary<string, Texture> modelTextures = new Dictionary<string, Texture>();
        foreach (string path in textureAssetPaths) {
            var texture = AssetDatabase.LoadAssetAtPath<Texture>(path.Substring(path.IndexOf("Asset", StringComparison.Ordinal)));
            modelTextures.Add(texture.name, texture);
        }

        List<EthnicModel> ethnics = new List<EthnicModel>();
        foreach (string path in csvAssetPaths) {
            TextAsset ethnicCSV = AssetDatabase.LoadAssetAtPath<TextAsset>(path.Substring(path.IndexOf("Asset", StringComparison.Ordinal)));
            string[] line = ethnicCSV.text.Split(new char[] { '\n' });
            for (int i = 0; i < line.Length - 1; i++) {
                string[] part = line[i].Split(new char[] { ',' });
                EthnicModel ethnic = new EthnicModel(part[0], part[1], part[2]);
                //ethnic.MapImage = mapImages.ContainsKey(part[2]) ? mapImages[part[2]] : null;
                //ethnic.PreviewImage = previewImages.ContainsKey(part[2]) ? previewImages[part[2]] : null;

                //set prefab and the texture here
                ethnic.ModelPrefab = modelPrefabs.ContainsKey(part[3]) ? modelPrefabs[part[3]] : null;
                ethnic.ClothTexture = modelTextures.ContainsKey(part[2]) ? modelTextures[part[2]] : null;
                ethnics.Add(ethnic);
            }
        }

        ethnicDatabase.ethnicGroups.list = ethnics;

        AssetDatabase.StopAssetEditing();
        EditorUtility.SetDirty(ethnicDatabase.ethnicGroups);
        AssetDatabase.SaveAssets();
        Debug.Log("Ethnic Group references updated");
    }
}
