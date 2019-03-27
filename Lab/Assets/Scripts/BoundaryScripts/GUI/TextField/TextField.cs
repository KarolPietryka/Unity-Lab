using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextField : MonoBehaviour {

    private InputField inputField;

    [SerializeField]
    private GameObject SaveSystem;
    private string defaultSaveFolderPath;

    private void Awake()
    {
        defaultSaveFolderPath = SaveSystem.GetComponent<SaveSystemBoundary>().defaultSaveFolderPath;

        inputField = gameObject.GetComponent<InputField>();      
        inputField.onValueChanged.AddListener(SetText);

        inputField.text = defaultSaveFolderPath;

    }

    public void SetText(string arg)
    {
        inputField.ActivateInputField();
        inputField.text = arg;
    }
}
