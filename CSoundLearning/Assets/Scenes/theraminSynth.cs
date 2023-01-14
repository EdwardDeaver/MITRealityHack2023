

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



        [SerializeField] Vector2 _freqRange = new Vector2(700, 800);
        CsoundUnity _csound;



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
            if (!_csound.IsInitialized)
                return;

            _csound.SetChannel("Frequency", frequencyField);
            _csound.SetChannel("Amplitude", amplitudeField);
            _csound.SetChannel("Gain", gainField);
            _csound.SetChannel("Lfo", lfoField);
            _csound.SetChannel("Table", tableField);



        }


        // When pressed in JSON call this and play (button 0 pressed)
        // playNote(1.0)
        // Perfect fifth

        // amplitudeField should be 0 - 1f) 
        public void setAmplitude(float Amplitude){
            _csound.SetChannel("Amplitude", amplitudeField);
        }    
        // position - button position on  fret board 0 at top 

        public void playNote(float position){
            _csound.SetChannel("Frequency", frequencyField * (position * 1.5));
        }
        public void changeLFO(float lfoVariable){
            _csound.SetChannel("Frequency", lfoVariable);
            _csound.SetChannel("Amplitude", amplitudeField);
        }
    }
}
