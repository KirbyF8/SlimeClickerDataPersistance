using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataPersitance : MonoBehaviour
{
    private const string SAVE_FILE_NAME = "/save-file.txt";

    private Clicker clicker;
    [SerializeField] TextMeshProUGUI saved;

    void Start()
    {
        saved.text = "";
        clicker = GetComponent<Clicker>();
    }

    public void SaveJSON()
    {
        int slimes = clicker.slimes;
        bool autoClickerBuyed = clicker.autoClickerBuyed;
        int clickValue = clicker.clickValue;
        int shopClickValue = clicker.shopClickValue;

        SaveObject saveObject = new SaveObject
        {
            slimes = slimes,
            autoClickerBuyed = autoClickerBuyed,
            clickValue = clickValue,
            shopClickValue = shopClickValue
        };

        string jsonContent = JsonUtility.ToJson(saveObject);
        saved.text = "saved";

        System.IO.File.WriteAllText(Application.dataPath + SAVE_FILE_NAME,
            jsonContent);


    }
    public void LoadJSON()
    {
        // Comprobar si el archivo existe
        if (System.IO.File.Exists(Application.dataPath + SAVE_FILE_NAME))
        {
            string jsonContent = System.IO.File.ReadAllText(Application.dataPath + SAVE_FILE_NAME);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(jsonContent);

            clicker.slimes = saveObject.slimes;
            clicker.autoClickerBuyed = saveObject.autoClickerBuyed;
            clicker.clickValue = saveObject.clickValue;
            clicker.shopClickValue = saveObject.shopClickValue;
        }
        else
        {
            Debug.LogError("No hay archivo de guardado");
        }
    }

}
