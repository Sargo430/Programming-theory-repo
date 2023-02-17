using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUi : MonoBehaviour
{
    public TMP_Dropdown classSelection;
    private MainManager mainManager;
    // Start is called before the first frame update
    void Start()
    {
        mainManager=GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        mainManager.classSelected = classSelection.value;
        SceneManager.LoadScene(1);
    } 
    public void ExitGame() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
