using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: gasps are NOT interuptible

public class breathingManager : MonoBehaviour {

    public AudioSource gainSanity;
    public AudioSource lostSanity;

    public AudioSource almostGainedSanity;
    public AudioSource almostLostSanity;

    //multiplies the volume of ALL the audiosources that create breathing by this value... 
    //note that the max value of every track still stays the same
    //EX: if your volume is 1... and you multiply by 10... the result still needs to be within the same (0 to 1) range of volume
    [Range(0,10)]
    public float masterVolumeMultiplier;
    float prevMasterVolumeMultiplier;

    public AudioSource maleGasp;
    public AudioSource femaleGasp;
    public float delayUntilGasp;

    public AudioSource maleSigh;
    public AudioSource femaleSigh;
    public float delayUntilSigh;

    //FOR NOW... no sex specific (sigh is pretty sex neutral)
    public AudioSource unisexDeepBreath;
    public float delayBeforeDeepBreath;
    public float delayAfterDeepBreath;

    public GameObject male;
    public GameObject female;

    public float fadeTime;

    //there can only every be either a gasp or a sigh running...
    //new gasps override old gasps
    //new sighs override old sighs
    //gasps overide sighs
    Coroutine gaspRunning;
    Coroutine sighRunning;
    Coroutine deepBreathRunning;

    Dictionary<AudioSource, float> audioSource_2_originalVolumes;

    void Start()
    {
        prevMasterVolumeMultiplier = 1;
        masterVolumeMultiplier = 1;

        delayUntilSigh = .25f;

        delayUntilGasp = .25f;

        delayBeforeDeepBreath = 1.5f; //going from shock to attemtpting to become stable
        delayAfterDeepBreath = 1f; //still try to control breathing

        //NOTE: these should probably be really close to each other because when you gasp you stop breathing normally but you still dont do so crazy abruptly
        fadeTime = .5f;

        gaspRunning = null;
        sighRunning = null;
        deepBreathRunning = null;

        audioSource_2_originalVolumes = new Dictionary<AudioSource, float>();
        saveOriginalVolumes();
    }

    void saveOriginalVolumes()
    {
        //for male
        audioSource_2_originalVolumes.Add(male.GetComponent<breathingLinks>().b1, male.GetComponent<breathingLinks>().b1.volume);
        audioSource_2_originalVolumes.Add(male.GetComponent<breathingLinks>().b2, male.GetComponent<breathingLinks>().b2.volume);
        audioSource_2_originalVolumes.Add(male.GetComponent<breathingLinks>().b3, male.GetComponent<breathingLinks>().b3.volume);
        audioSource_2_originalVolumes.Add(male.GetComponent<breathingLinks>().b4, male.GetComponent<breathingLinks>().b4.volume);
        audioSource_2_originalVolumes.Add(male.GetComponent<breathingLinks>().b5, male.GetComponent<breathingLinks>().b5.volume);

        //for female
        audioSource_2_originalVolumes.Add(female.GetComponent<breathingLinks>().b1, female.GetComponent<breathingLinks>().b1.volume);
        audioSource_2_originalVolumes.Add(female.GetComponent<breathingLinks>().b2, female.GetComponent<breathingLinks>().b2.volume);
        audioSource_2_originalVolumes.Add(female.GetComponent<breathingLinks>().b3, female.GetComponent<breathingLinks>().b3.volume);
        audioSource_2_originalVolumes.Add(female.GetComponent<breathingLinks>().b4, female.GetComponent<breathingLinks>().b4.volume);
        audioSource_2_originalVolumes.Add(female.GetComponent<breathingLinks>().b5, female.GetComponent<breathingLinks>().b5.volume);

        //for our local sounds
        audioSource_2_originalVolumes.Add(maleGasp, maleGasp.volume);
        audioSource_2_originalVolumes.Add(femaleGasp, femaleGasp.volume);
        audioSource_2_originalVolumes.Add(maleSigh, maleSigh.volume);
        audioSource_2_originalVolumes.Add(femaleSigh, femaleSigh.volume);
        audioSource_2_originalVolumes.Add(unisexDeepBreath, unisexDeepBreath.volume);
    }

    void Update()
    {
        if(prevMasterVolumeMultiplier != masterVolumeMultiplier)
        {
            //update all of our sound volumes
            foreach (var key in audioSource_2_originalVolumes.Keys)
            {
                float newVol = audioSource_2_originalVolumes[key] * masterVolumeMultiplier;
                Mathf.Clamp01(newVol);
                key.volume = newVol;
            }
            prevMasterVolumeMultiplier = masterVolumeMultiplier;
        }
    }

    //-------------------------PUBLIC Functions (to call from health)

    public void deepBreath(bool isMale, int breathingLevel) //1 -> 5
    {
        if (deepBreathRunning != null)
        {
            StopCoroutine(deepBreathRunning);
            unisexDeepBreath.Stop(); //since it might be playing
            deepBreathRunning = null;
        }

        deepBreathRunning = StartCoroutine(deepBreathCoR(isMale, breathingLevel));
    }

    public void gasp(bool isMale, int breathingLevel)
    {
        if (deepBreathRunning != null)
        {
            StopCoroutine(deepBreathRunning);
            unisexDeepBreath.Stop(); //since it might be playing
            deepBreathRunning = null;
        }

        //we dont interupt our gasp because that would make no sense (you cant suck in air indefinately)
        if (gaspRunning == null)
            gaspRunning = StartCoroutine(gaspCoR(isMale, breathingLevel));
    }

    public void sigh(bool isMale, int breathingLevel)
    {
        if (deepBreathRunning != null)
        {
            StopCoroutine(deepBreathRunning);
            unisexDeepBreath.Stop(); //since it might be playing
            deepBreathRunning = null;
        }

        //we dont interupt our gasp because that would make no sense (you cant suck in air indefinately)
        if (sighRunning == null)
            sighRunning = StartCoroutine(sighCoR(isMale, breathingLevel));
    }

    public void stopAllBreathing()
    {
        //NOTE: gasps are unstopable and must finish running

        if (unisexDeepBreath.isPlaying)
            StartCoroutine(FadeOut(unisexDeepBreath, fadeTime));

        //stop male breathing
        if (male.GetComponent<breathingLinks>().b1.isPlaying)
            StartCoroutine(FadeOut(male.GetComponent<breathingLinks>().b1, fadeTime));
        if (male.GetComponent<breathingLinks>().b2.isPlaying)
            StartCoroutine(FadeOut(male.GetComponent<breathingLinks>().b2, fadeTime));
        if (male.GetComponent<breathingLinks>().b3.isPlaying)
            StartCoroutine(FadeOut(male.GetComponent<breathingLinks>().b3, fadeTime));
        if (male.GetComponent<breathingLinks>().b4.isPlaying)
            StartCoroutine(FadeOut(male.GetComponent<breathingLinks>().b4, fadeTime));
        if (male.GetComponent<breathingLinks>().b5.isPlaying)
            StartCoroutine(FadeOut(male.GetComponent<breathingLinks>().b5, fadeTime));

        //stop female breathing
        if (female.GetComponent<breathingLinks>().b1.isPlaying)
            StartCoroutine(FadeOut(female.GetComponent<breathingLinks>().b1, fadeTime));
        if (female.GetComponent<breathingLinks>().b2.isPlaying)
            StartCoroutine(FadeOut(female.GetComponent<breathingLinks>().b2, fadeTime));
        if (female.GetComponent<breathingLinks>().b3.isPlaying)
            StartCoroutine(FadeOut(female.GetComponent<breathingLinks>().b3, fadeTime));
        if (female.GetComponent<breathingLinks>().b4.isPlaying)
            StartCoroutine(FadeOut(female.GetComponent<breathingLinks>().b4, fadeTime));
        if (female.GetComponent<breathingLinks>().b5.isPlaying)
            StartCoroutine(FadeOut(female.GetComponent<breathingLinks>().b5, fadeTime));
    }

    public void startBreathing(bool isMale, int breathingLevel) //1 -> 5
    {
        //NOTE: you should never be gasping and sighing at the same time
        float timeBeforeWeBegin = Mathf.Max(gaspTimeLeft(), sighTimeLeft());

        if (isMale)
        {
            switch (breathingLevel)
            {
                case 5: StartCoroutine(FadeIn(male.GetComponent<breathingLinks>().b1, timeBeforeWeBegin)); break;
                case 4: StartCoroutine(FadeIn(male.GetComponent<breathingLinks>().b2, timeBeforeWeBegin)); break;
                case 3: StartCoroutine(FadeIn(male.GetComponent<breathingLinks>().b3, timeBeforeWeBegin)); break;
                case 2: StartCoroutine(FadeIn(male.GetComponent<breathingLinks>().b4, timeBeforeWeBegin)); break;
                case 1: StartCoroutine(FadeIn(male.GetComponent<breathingLinks>().b5, timeBeforeWeBegin)); break;
                default: break;
            }
        }
        else
        {
            switch (breathingLevel)
            {
                case 5: StartCoroutine(FadeIn(female.GetComponent<breathingLinks>().b1, timeBeforeWeBegin)); break;
                case 4: StartCoroutine(FadeIn(female.GetComponent<breathingLinks>().b2, timeBeforeWeBegin)); break;
                case 3: StartCoroutine(FadeIn(female.GetComponent<breathingLinks>().b3, timeBeforeWeBegin)); break;
                case 2: StartCoroutine(FadeIn(female.GetComponent<breathingLinks>().b4, timeBeforeWeBegin)); break;
                case 1: StartCoroutine(FadeIn(female.GetComponent<breathingLinks>().b5, timeBeforeWeBegin)); break;
                default: break;
            }
        }
    }

    //-------------------------Helper Functions

    IEnumerator deepBreathCoR(bool isMale, int breathingLevel) //1 -> 5
    {
        yield return new WaitForSeconds(delayBeforeDeepBreath);
        unisexDeepBreath.Play();
        while (unisexDeepBreath.isPlaying)
            yield return null;
        yield return new WaitForSeconds(delayAfterDeepBreath);
        startBreathing(isMale, breathingLevel);
        deepBreathRunning = null;
    }

    IEnumerator gaspCoR(bool isMale, int breathingLevel)
    {
        yield return new WaitForSeconds(delayUntilGasp);
        if (isMale)
        {
            maleGasp.Play();
            while (maleGasp.isPlaying)
                yield return null;
        }
        else
        {
            femaleGasp.Play();
            while (femaleGasp.isPlaying)
                yield return null;
        }
        gaspRunning = null;
    }

    IEnumerator sighCoR(bool isMale, int breathingLevel)
    {
        yield return new WaitForSeconds(delayUntilSigh);
        if (isMale)
        {
            maleSigh.Play();
            while (maleSigh.isPlaying)
                yield return null;
        }
        else
        {
            femaleSigh.Play();
            while (femaleSigh.isPlaying)
                yield return null;
        }
        sighRunning = null;
    }

    float gaspTimeLeft()
    {
        //Assumes that male and female gasp will never play at the same time
        if (maleGasp.isPlaying)
            return (maleGasp.clip.length - maleGasp.time);
        else if (femaleGasp.isPlaying)
            return (femaleGasp.clip.length - femaleGasp.time);
        else
            return 0;
    }

    float sighTimeLeft()
    {
        //Assumes that male and female gasp will never play at the same time
        if (maleSigh.isPlaying)
            return (maleSigh.clip.length - maleSigh.time);
        else if (femaleSigh.isPlaying)
            return (femaleSigh.clip.length - femaleSigh.time);
        else
            return 0;
    }

    IEnumerator FadeIn(AudioSource audioSource, float gaspTime)
    {
        //wait until uninteruptible sounds
        yield return new WaitForSeconds(gaspTime);

        audioSource.Play(); //all of our audio tracks should fade in already
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float originalVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= originalVolume * Time.deltaTime / FadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = originalVolume;
    }
}
