using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class JSONResponseModel : MonoBehaviour
{
    public float FREQ;
    public float AMP;
    public float LFO;
    public bool NOTE1;
    public bool NOTE2;
    public bool NOTE3;
    public bool NOTE4;
    public bool STRUM;
    public bool Fret1P23;
    public bool Fret2P22;
    public bool Fret3P21;
    public bool Fret4P19;
    public bool Strum1P18;
    public float Pot1P33;
    public float Pot2P25;
    public float Pot3P26;
    public TMP_Text FREQTEXT;
    public TMP_Text AMPTEXT;
    public TMP_Text LFOTEXT;
    public TMP_Text BUTTON1TEXT;
    public TMP_Text BUTTON2TEXT;
    public TMP_Text BUTTON3TEXT;
    public TMP_Text BUTTON4TEXT;
    public TMP_Text STRUM_TEXT;

    void Update()
    {

        FREQTEXT.text = Pot1P33.ToString();
        Debug.Log(Pot1P33.ToString());

        AMPTEXT.text = Pot2P25.ToString();
        Debug.Log(Pot2P25.ToString());

        LFOTEXT.text = Pot3P26.ToString();
        Debug.Log(Pot3P26.ToString());

        BUTTON1TEXT.text = this.NOTE1.ToString();
        BUTTON2TEXT.text = this.NOTE2.ToString();
        BUTTON3TEXT.text = this.NOTE3.ToString();
        BUTTON4TEXT.text = this.NOTE4.ToString();

        STRUM_TEXT.text = this.STRUM.ToString(); 
    }

    public void onMessage(string savedData)
    {
        Debug.Log("Debug Got the Message!");
        Debug.Log(savedData);
        try
        {
            JsonUtility.FromJsonOverwrite(savedData, this);
            this.AMP = this.Pot1P33;
            this.AMP = Mathf.Lerp(0.0f, 1.0f, this.AMP);
            this.LFO = this.Pot2P25;
            this.LFO = Mathf.Lerp(0.0f, 16.0f, this.AMP);
            this.FREQ = this.Pot3P26;
            this.FREQ = Mathf.Lerp(0.0f, 2048.0f, this.FREQ);
            this.NOTE1 = this.Fret1P23;
            this.NOTE2 = this.Fret2P22;
            this.NOTE3 = this.Fret3P21;
            this.STRUM = this.Fret4P19; 
            if (this.Strum1P18 == false)
            {
                this.NOTE1 = false;
                this.NOTE2 = false;
                this.NOTE3 = false;
                this.NOTE4 = false;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

}
