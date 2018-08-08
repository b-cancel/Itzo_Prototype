using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    //public float enemSoundRange;

    public List<GameObject> Enemies;

	// Use this for initialization
	void Awake () {
        Enemies = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
            Enemies.Add(gameObject.transform.GetChild(i).gameObject);

   //     enemSoundRange = 35f;
	}

    void Update()
    {
     //   foreach (var e in Enemies)
      //      e.GetComponentInChildren<EnemySounds>().soundRange = enemSoundRange;
    }
}
