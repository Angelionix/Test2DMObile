using UnityEngine;

public static class DataSaveLoad
{
    public static void SaveData(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public static float LoadData()
    { 
        return PlayerPrefs.GetFloat("Volume");
    }
}
