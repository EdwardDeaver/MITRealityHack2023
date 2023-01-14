using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JSONResponseModel : MonoBehaviour
{
    public string name;
    public string status = "Nothing Has Been Sent";

    void Update()
    {
      //  Debug.Log(this.status);
        Debug.Log(this.status.GetType());
        Debug.Log("Output " +(this.status == "running"));
        Debug.Log("-------------------");
        Debug.Log("Output " + String.Compare(this.status, "running")); 
        
    }
    public void onMessage(string savedData)
    {
        Debug.Log("Got the Message!");
        try
        {
            JsonUtility.FromJsonOverwrite(savedData, this);
        }
        catch (Exception e)
        {
            print(e);
        }

    }

}
