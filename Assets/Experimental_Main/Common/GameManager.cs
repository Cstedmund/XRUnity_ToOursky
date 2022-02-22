using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Start is called before the first frame update
    private static GameManager _instance;
    [SerializeField]
    public bool debugOn; 

    public static GameManager Instance {
        get { return _instance; }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    //[HideInInspector]
    [SerializeField]
    public Language currentLanguage;
    //[HideInInspector]
    [SerializeField]
    public BookItem currentBook;
    [HideInInspector]
    [SerializeField]
    public string currentURL,previousScene;

    public enum Book {
        B1,
        B2,
        B3,
        B4,
        B5,
        B6,
        B7,
        B8,
        B9,
        B10,
        B11,
    }
    public enum Language {
        en,
        zh,
    }

    private void Start() {
        Debug.Log(FunctionLibrary.GetCurrentDevice());
    }

}
