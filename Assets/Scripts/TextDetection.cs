using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

// Class that controls detecting marker
public class TextDetection : MonoBehaviour, ITrackableEventHandler
{
    [SerializeField]
    private Text txt = null; // Text is displaying while the marker is not detected
    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>(); // Initialization TrackableBehaviour
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    
    //Function that track the state of a marker
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || 
            newStatus == TrackableBehaviour.Status.TRACKED || 
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) // If marker is detected 
        {
            txt.enabled = false;
        }
        else
        {
            txt.enabled = true;
        }
    }
}