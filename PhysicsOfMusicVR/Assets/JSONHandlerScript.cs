using UnityEngine;

public class JSONHandlerScript
{
    public string name;
    public string status;

    public static JSONHandlerScript CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<JSONHandlerScript>(jsonString);
    }

}