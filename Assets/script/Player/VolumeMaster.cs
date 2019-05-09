using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMaster : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float masterVolume = 1.0f;

	void Start () {
        masterVolume = PlayerPrefs.GetFloat("Volume");

    }
	
	void Update () {
        AudioListener.volume = masterVolume;
	}
}
