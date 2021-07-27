using UnityEditor;
using UnityEngine;

public class ResetPlayerPrefs
{
    [MenuItem("Tools/Reset PlayerPrefs", false)]
    public static void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("*** PlayerPrefs was reset! ***");
    }
}
