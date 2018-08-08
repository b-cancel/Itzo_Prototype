using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutputVolume : MonoBehaviour
{
    //CHANGES: 
    //(1) assume sourcetype cannot be custom
    //(2) assume we output to a prefabBar always
    //(3) all functions with no references get deleted
    //(4) we allways want our bar to scale
    //(5) we are not using color gradients
    //(6) we dont need to change the material

    [Tooltip("The AudioSource to take data from.")]
    public AudioSource audioSource;

    //-----PUBLIC VARIABLES

    public enum SourceType { AudioSource, AudioListener }

    [Tooltip("Enables or disables the processing and display of volume data.")]
    public bool isEnabled;

    [Tooltip("The type of source for volume data.")]
    public SourceType sourceType;

    [Tooltip("The number of samples to use when sampling. Must be a power of two.")]
    public int sampleAmount;

    //TODO... how many channels are there?
    [Tooltip("The audio channel to take data from when sampling.")]
    public int channel;

    [Range(0, 1)]
    [Tooltip("The amount of dampening used when the new scale is higher than the bar's existing scale. [slow -> fast]")]
    public float attackDamp;

    [Range(0, 1)]
    [Tooltip("The amount of dampening used when the new scale is lower than the bar's existing scale. [slow -> fast]")]
    public float decayDamp;

    [Tooltip("The prefab of bar to use. Use a prefab from SimpleSpectrum/Bar Prefabs or refer to the documentation to use a custom prefab.")]
    public GameObject prefab;

    public bool calcMinAndMax;
    [Header("VARIALBES ONLY FOR DISPLAY")]
    public float highDampVol;
    public float lowDampVol;
    public float highRawVol;
    public float lowRawVol;

    //---all values are first [RAW] {DAMP}
    //VALUES ABOVE FOR "lightFlicker"
    //[0,0.1539215] {0,0.124559}
    //VALUES ABOVE FOR "lightDeath"
    //[0,0.2440041] {0,0.2293126}

    //-----PRIVATE VARIABLES

    float newVolRaw;
    float newVolDamp;

    void Start () {
        //---inits
        isEnabled = false;
        sourceType = SourceType.AudioSource;
        sampleAmount = 256;
        channel = 0;
        attackDamp = .75f;
        decayDamp = .25f;

        //---min max
        calcMinAndMax = true;
        highRawVol = float.MinValue;
        highDampVol = float.MinValue;
        lowRawVol = float.MaxValue;
        lowDampVol = float.MaxValue;
    }

    void Update()
    {
        if (isEnabled)
            calcVolume();
    }
	
	public void calcVolume () {

        if (sourceType == SourceType.AudioListener)
            newVolRaw = GetAudioListenerVol(sampleAmount, channel);
        else
            newVolRaw = GetAudioSourceVol(audioSource, sampleAmount, channel);

        newVolDamp = newVolRaw > newVolDamp ? Mathf.Lerp(newVolDamp, newVolRaw, attackDamp) : Mathf.Lerp(newVolDamp, newVolRaw, decayDamp);

        if (calcMinAndMax)
        {
            calcMinMaxRaw();
            calcMinMaxDamp();
        }
    }

    public float getVolRaw()
    {
        return newVolRaw;
    }

    public float getVolDamp()
    {
        return newVolDamp;
    }

    void calcMinMaxRaw()
    {
        lowRawVol = Mathf.Min(lowRawVol, newVolRaw);
        highRawVol = Mathf.Max(highRawVol, newVolRaw);
    }

    void calcMinMaxDamp()
    {
        lowDampVol = Mathf.Min(lowDampVol, newVolDamp);
        highDampVol = Mathf.Max(highDampVol, newVolDamp);
    }

    // Returns the current output volume of the specified AudioSource, using the RMS method.
    public static float GetAudioSourceVol(AudioSource aSource, int sampleSize, int channelUsed = 0)
    {
        sampleSize = Mathf.ClosestPowerOfTwo(sampleSize);
        float[] outputSamples = new float[sampleSize];
        aSource.GetOutputData(outputSamples, channelUsed); //USING AUDIOSOURCE

        float rms = 0;
        foreach (float f in outputSamples)
            rms += f * f; //sum of squares
        return Mathf.Sqrt(rms / (outputSamples.Length)); //mean and root
    }

    // Returns the current output volume of the scene's AudioListener, using the RMS method.
    public static float GetAudioListenerVol(int sampleSize, int channelUsed = 0)
    {
        sampleSize = Mathf.ClosestPowerOfTwo(sampleSize);
        float[] outputSamples = new float[sampleSize];
        AudioListener.GetOutputData(outputSamples, channelUsed); //USING AUDIOLISTENER

        float rms = 0;
        foreach (float f in outputSamples)
            rms += f * f; //sum of squares
        return Mathf.Sqrt(rms / (outputSamples.Length)); //mean and root
    }
}
