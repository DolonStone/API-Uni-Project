using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    public int help;
    public DateTime what;
    // Start is called before the first frame update
    private void Awake()
    {
        Load();

    }

    private void Save()
    {
        int saveTest = help;
        string dateTime = DateTime.Now.ToString("o");



        SaveObject saveObject = new SaveObject { test = saveTest, lastLogin = dateTime };
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    private void Load()
    {
        string path = Application.dataPath + "/save.txt";
        if (File.Exists(path))
        {
            string saveString = File.ReadAllText(path);
            SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(saveString);
            help = loadedSaveObject.test;
            what = DateTime.ParseExact(loadedSaveObject.lastLogin, "o", null);

            DateTime dt = DateTime.Now;
            Debug.Log(dt);
            Debug.Log(what);
            Debug.Log(what.Subtract(dt));

        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            help++;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
    }
    [Serializable]
    private class SaveObject
    {
        public int test;
        public string lastLogin;
    }
}
