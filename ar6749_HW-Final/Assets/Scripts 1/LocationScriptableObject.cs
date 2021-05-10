using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Location",
    menuName = "Scriptable Objects / Location", order = 0)]


public class LocationScriptableObject : ScriptableObject
{
    public string locationName = "New Place";
    public GameObject backgroundImage;

    public LocationScriptableObject lpLoss;
    public LocationScriptableObject matchHistory;
    public LocationScriptableObject playAgain;
    public LocationScriptableObject defeatScreen;
}
