using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class ESPAVControl : MonoBehaviour
{
    public JSONResponseModel _jsonResponseModel;
    public List<AudioSource> _audioObjects;
    public List<VisualEffect> _particleWaves;

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
        _audioObjects[3].enabled = _jsonResponseModel.NOTE4;
    }

    void LinkVFX()
    {
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
        if(_jsonResponseModel.NOTE4)
        {
            _particleWaves[3].SendEvent(_vfxPlayEvent);
        }
        if(!_jsonResponseModel.NOTE4)
        {
            _particleWaves[3].SendEvent(_vfxStopEvent);
        }
    }
}
