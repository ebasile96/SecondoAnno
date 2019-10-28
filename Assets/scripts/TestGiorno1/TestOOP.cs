using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGame
{
    ISaveService saveService;

    public void StartGame()
    {
        saveService.Load();
    }

    public void EndGame()
    {
        saveService.Save();
    }
}

public class SaveServicePC : ISaveService
{
    int Dato = 0;

    public void Load()
    {
        Dato = PlayerPrefs.GetInt("dato", 0);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("dato", 1);
    }
}

public class SaveServicePS4 : ISaveService
{
    int Dato = 0;

    public void Load()
    {
        Dato = PlayerPrefs.GetInt("dato", 0);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("dato", 1);
    }
}

interface ISaveService
{
    void Load();
    void Save();
}

public class TestOOP : MonoBehaviour
{
    
}
