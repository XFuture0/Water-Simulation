using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] private Transform TrackObject;
    [SerializeField] private Vector3 Offset;
    private void Update()
    {
        transform.position = TrackObject.position + Offset;
        transform.rotation = TrackObject.rotation;
    }
}
