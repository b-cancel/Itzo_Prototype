using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour {

    public AudioSource movement;

    public AudioSource death;

    public AudioSource goingIntoWander;
    public AudioSource wander;

    public AudioSource goingIntoSoundChase;
    public AudioSource soundChase;

    public AudioSource goingIntoSightChase;
    public AudioSource sightChase;

    public float soundRange;

    //-----PRIVATE FUNCTIONS-----

    void Awake()
    {
        toWander();

        soundRange = 35f;

        updateSoundRange();
    }

    void updateSoundRange()
    {
        movement.maxDistance = soundRange;
        death.maxDistance = soundRange;
        goingIntoWander.maxDistance = soundRange;
        wander.maxDistance = soundRange;
        goingIntoSoundChase.maxDistance = soundRange;
        soundChase.maxDistance = soundRange;
        goingIntoSightChase.maxDistance = soundRange;
        sightChase.maxDistance = soundRange;
    }

    void Update()
    {
        updateSoundRange();

        if (true) // true for testing
        {
            if (Input.GetKeyDown(KeyCode.Alpha7))
                toWander();
            else if (Input.GetKeyDown(KeyCode.Alpha8))
                toSoundChase();
            else if (Input.GetKeyDown(KeyCode.Alpha9))
                toSightChase();
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                toDeath();
        }
    }

    void stopAllStateSounds()
    {
        if(goingIntoWander.isPlaying)
            goingIntoWander.Stop();
        if(wander.isPlaying)
            wander.Stop();

        if(goingIntoSoundChase.isPlaying)
            goingIntoSoundChase.Stop();
        if (soundChase.isPlaying)
            soundChase.Stop();

        if(goingIntoSightChase.isPlaying)
            goingIntoSightChase.Stop();
        if(sightChase.isPlaying)
            sightChase.Stop();
    }

    IEnumerator wanderSounds()
    {
        goingIntoWander.Play();
        yield return new WaitForSeconds(goingIntoWander.clip.length);
        wander.Play();
    }

    IEnumerator soundChaseSounds()
    {
        goingIntoSoundChase.Play();
        yield return new WaitForSeconds(goingIntoSoundChase.clip.length);
        soundChase.Play();
    }

    IEnumerator sightChaseSounds()
    {

        goingIntoSightChase.Play();
        yield return new WaitForSeconds(goingIntoSightChase.clip.length);
        sightChase.Play();
    }

    //-----PUBLIC FUNCTIONS-----

    public void setMoveSpeedLevel(int speedLevel) //speed 1, 2, 3
    {
        movement.pitch = speedLevel;
    }
	
	public void toWander()
    {
        setMoveSpeedLevel(1);
        stopAllStateSounds();
        StartCoroutine(wanderSounds());
    }

    public void toSoundChase()
    {
        setMoveSpeedLevel(2);
        stopAllStateSounds();
        StartCoroutine(soundChaseSounds());
    }

    public void toSightChase()
    {
        setMoveSpeedLevel(3);
        stopAllStateSounds();
        StartCoroutine(sightChaseSounds());
    }

    public void toDeath()
    {
        movement.Stop();
        stopAllStateSounds();
        death.Play();
    }
}