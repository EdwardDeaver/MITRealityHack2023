

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Csound.TableMorph.Theremin
{

 
    [RequireComponent(typeof(CsoundUnity))]
public class theraminSynth : MonoBehaviour    {
       public  float frequencyField = 60.0F;
       public  float amplitudeField = 1.0F;
        public  float gainField = 1.0F;
        public  float lfoField = 100F;
        public  float tableField = 3.99F;

        public JSONResponseModel _jsonResponseModel;

        [SerializeField] Vector2 _freqRange = new Vector2(700, 800);
        CsoundUnity _csound;

        public float _freqBase;

        IEnumerator Start()
        {
            _csound = GetComponent<CsoundUnity>();
            while (!_csound.IsInitialized)
                yield return null;

            _csound.SetChannel("Frequency", frequencyField);
            _csound.SetChannel("Amplitude", amplitudeField);
            _csound.SetChannel("Gain", gainField);
            _csound.SetChannel("Lfo", lfoField);
            _csound.SetChannel("Table", tableField);

        }

        void Update()
        {
            amplitudeField = _jsonResponseModel.AMP;
            lfoField = _jsonResponseModel.LFO;
            frequencyField = _freqBase + _jsonResponseModel.FREQ;
            
            if (!_csound.IsInitialized)
                return;

            _csound.SetChannel("Frequency", frequencyField);
            _csound.SetChannel("Amplitude", amplitudeField);
            _csound.SetChannel("Gain", gainField);
            _csound.SetChannel("Lfo", lfoField);
            _csound.SetChannel("Table", tableField);

            // _csound.SetChannel("Amplitude", _jsonResponseModel.AMP);
            // _csound.SetChannel("Gain", _jsonResponseModel.FREQ);
            // _csound.SetChannel("Lfo", _jsonResponseModel.LFO);

        }


        // When pressed in JSON call this and play (button 0 pressed)
        // playNote(1.0)
        // Perfect fifth

        // amplitudeField should be 0 - 1f) 
        public void setAmplitude(float Amplitude){
            amplitudeField = Amplitude;
            _csound.SetChannel("Amplitude", amplitudeField);
        }  
        public void setFrequency(float Frequency){
            frequencyField = Frequency;
            _csound.SetChannel("Frequency", Frequency);
        }     
        // position - button position on  fret board 0 at top 

        public void playNote(float position){
            _csound.SetChannel("Frequency", frequencyField * (position * 1.5f));
        }
        public void changeLFO(float lfoVariable){
            lfoField = lfoVariable;
            _csound.SetChannel("Lfo", lfoVariable);
        }

        
    }
}
