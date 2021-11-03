using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBlender : MonoBehaviour
{
    public AudioSource grassMusic;
    public AudioSource sandMusic;
    public AudioSource snowMusic;

    public enum Area { Grass, Sand, Snow};
    public Area areaSelection;

    public const float maxVolume = .25f;
    [SerializeField] private float blendLength = 2f;

    private float timeStartedBlending;

    private void OnTriggerEnter(Collider other)
    {
        timeStartedBlending = Time.time;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            float timeSinceStarted = Time.time - timeStartedBlending;
            float percentage = timeSinceStarted / blendLength;

            if(areaSelection == Area.Grass)
            {
                grassMusic.volume = Mathf.Lerp(grassMusic.volume, maxVolume, percentage);
                sandMusic.volume = Mathf.Lerp(sandMusic.volume, 0f, percentage);
                snowMusic.volume = Mathf.Lerp(snowMusic.volume, 0f, percentage);
            }
            else if (areaSelection == Area.Sand)
            {
                grassMusic.volume = Mathf.Lerp(grassMusic.volume, 0f, percentage);
                sandMusic.volume = Mathf.Lerp(sandMusic.volume, maxVolume, percentage);
                snowMusic.volume = Mathf.Lerp(snowMusic.volume, 0f, percentage);
            }
            else if (areaSelection == Area.Snow)
            {
                grassMusic.volume = Mathf.Lerp(grassMusic.volume, 0f, percentage);
                sandMusic.volume = Mathf.Lerp(sandMusic.volume, 0f, percentage);
                snowMusic.volume = Mathf.Lerp(snowMusic.volume, maxVolume, percentage);
            }
        }
    }

}
