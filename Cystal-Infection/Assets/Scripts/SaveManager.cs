using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    //Links and variable     
    VariablesToSave variablesToSave = new VariablesToSave();
    [SerializeField] private Button loadButton;
    private string json;
    
    private void Start()
    {
        loadButton.onClick.AddListener(Load);
    }
    //Save
    public void Save()
    {
        var file = File.Create(Application.dataPath + "/Save.json");
        var json = JsonUtility.ToJson(variablesToSave, true);
        StreamWriter streamWriter = new StreamWriter(file);
        streamWriter.Write(json);
        streamWriter.Close();
    }
    //Load
    private void Load()
    {
        StreamReader streamReader = new StreamReader(Application.dataPath +  "/Save.json");
        streamReader.ReadToEnd();
        variablesToSave = JsonUtility.FromJson<VariablesToSave>(json);
    }
}

[System.Serializable]
public class VariablesToSave
{
   public int playerHealth = 100;
}
