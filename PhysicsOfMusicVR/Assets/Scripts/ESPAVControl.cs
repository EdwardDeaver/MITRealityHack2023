using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Sngty;

public class ESPAVControl : MonoBehaviour
{
    public JSONResponseModel _jsonResponseModel;
    public List<Csound.TableMorph.Theremin.theraminSynth> _theraminSynths;
    public SingularityManager _singularityManager;
    public List<AudioSource> _audioObjects;
    public List<VisualEffect> _particleWaves;

    public BluetoothUIManager _bluetoothUIManager;

    public string _vfxStopEvent = "OnStop";
    public string _vfxPlayEvent = "OnPlay";
    
    // Start is called before the first frame update
    void Start()
    {
        if(_audioObjects.Count > 0)
        {
            for (int i = 0; i < _audioObjects.Count; i++)
            {
                _audioObjects[i].enabled = false;
            }
        }
        if(_particleWaves.Count > 0)
        {
            for (int i = 0; i < _particleWaves.Count; i++)
            {
                _particleWaves[i].SendEvent(_vfxStopEvent);
            }
        }
        StartCoroutine(ConnectToESP());
    }

    IEnumerator ConnectToESP()
    {
        yield return new WaitForSeconds(5f);
        _singularityManager.ConnectToDevice(_bluetoothUIManager.TheDevice);
    }
    
    // Update is called once per frame
    void Update()
    {
        LinkAudioSources();
        LinkVFX();
    }

    void LinkAudioSources()
    {
        _audioObjects[0].enabled = _jsonResponseModel.NOTE1;
        _audioObjects[1].enabled = _jsonResponseModel.NOTE2;
        _audioObjects[2].enabled = _jsonResponseModel.NOTE3;
        //_audioObjects[3].enabled = _jsonResponseModel.NOTE4;
    }

    void LinkVFX()
    {
        if(_theraminSynths.Count >0 && _particleWaves.Count >0)
        {
            for(int i = 0; i < _particleWaves.Count; i++)
            {
                _particleWaves[i].SetFloat("Frequency", _theraminSynths[i].frequencyField);
                _particleWaves[i].SetFloat("Amplitude", _theraminSynths[i].amplitudeField);
                _particleWaves[i].SetFloat("LFO", _theraminSynths[i].lfoField);
            }
        }
        if(_jsonResponseModel.NOTE1)
        {
            _particleWaves[0].SendEvent(_vfxPlayEvent);
        }
        if(!_jsonResponseModel.NOTE1)
        {
            _particleWaves[0].SendEvent(_vfxStopEvent);
        }
        if(_jsonResponseModel.NOTE2)
        {
            _particleWaves[1].SendEvent(_vfxPlayEvent);
        }
        if(!_jsonResponseModel.NOTE2)
        {
            _particleWaves[1].SendEvent(_vfxStopEvent);
        }
        if(_jsonResponseModel.NOTE3)
        {
            _particleWaves[2].SendEvent(_vfxPlayEvent);
        }
        if(!_jsonResponseModel.NOTE3)
        {
            _particleWaves[2].SendEvent(_vfxStopEvent);
        }
        // if(_jsonResponseModel.NOTE4)
        // {
        //     _particleWaves[3].SendEvent(_vfxPlayEvent);
        // }
        // if(!_jsonResponseModel.NOTE4)
        // {
        //     _particleWaves[3].SendEvent(_vfxStopEvent);
        // }
    }
}
