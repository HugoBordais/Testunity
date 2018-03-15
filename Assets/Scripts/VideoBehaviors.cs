using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using Vuforia;

public class VideoBehaviors : MonoBehaviour, ITrackableEventHandler {

    // Use this for initialization
    public GameObject ImageTarget;
    private VideoPlayer _videoPlayer;
    private StateManager _sm;
    private TrackableBehaviour mTrackableBehaviour;
    private bool _find;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _sm = TrackerManager.Instance.GetStateManager();
        mTrackableBehaviour = ImageTarget.GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }


    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (!_videoPlayer.isPlaying)
                    _videoPlayer.Play();
            
            Debug.Log("_find = true");
        }
        else
        {
            _videoPlayer.Pause();
            _find = false;
            Debug.Log("_find = false");
        }
    }
}