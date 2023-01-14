using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sngty;

public class ExampleCommunicator : MonoBehaviour
{
    public SingularityManager mySingularityManager;
    private Material _cubeMat;
    
    // Start is called before the first frame update
    void Start()
    {
        _cubeMat = GetComponent<Material>();

        List<DeviceSignature> pairedDevices = mySingularityManager.GetPairedDevices();

        DeviceSignature myDevice = new DeviceSignature();

        //If you are looking for a device with a specific name (in this case exampleDeviceName):
        for (int i = 0; i < pairedDevices.Count; i++)
        {
            if (pairedDevices[i].name == "Jacobs-ESP32")
            {
                myDevice = pairedDevices[i];
                mySingularityManager.ConnectToDevice(myDevice);
                break;
            }
        }

        if (!myDevice.Equals(default(DeviceSignature)))
        {
            //Do stuff to connect to the device here
        }
    }

    public void onConnected()
    {
        Debug.Log("Connected to device!");
        _cubeMat.color=Color.green;
    }

    public void onMessageRecieved(string message)
    {
        Debug.Log("Message recieved from device: " + message);
        _cubeMat.color=Color.yellow;
    }

    public void onError(string errorMessage)
    {
        Debug.LogError("Error with Singularity: " + errorMessage);
        _cubeMat.color=Color.red;
    }
}
