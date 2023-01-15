using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class ESPAVControl : MonoBehaviour
{
    public JSONResponseModel _jsonResponseModel;
    public List<GameObject> _audioObjects;
    public List<VisualEffect> _particleWaves;
    
    // Start is called before the first frame update
    void Start()
    {
        if(_audioObjects.Count > 0)
        {
            for (int i = 0; i < _audioObjects.Count; i++)
            {
                _audioObjects[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_jsonResponseModel.NOTE1)
        {
            _audioObjects[0].SetActive(true);
        }
        if(_jsonResponseModel.NOTE2)
        {
            _audioObjects[1].SetActive(true);
        }
        if(_jsonResponseModel.NOTE2)
        {
            _audioObjects[2].SetActive(true);
        }
        if(_jsonResponseModel.NOTE2)
        {
            _audioObjects[3].SetActive(true);
        }
    }
}
