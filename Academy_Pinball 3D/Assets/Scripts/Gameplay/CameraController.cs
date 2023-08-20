using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public struct CameraPosition
    {
        [Header("Manual")]
        public Vector3 position;
        [Header("Reference")]
        public Transform transform;

        public Vector3 offset;
        public float lerpSpeed;

        public Vector3 GetPosition()
        {
            if (transform)
            {
                return transform.position + offset;
            }
            else
            {
                return position + offset;
            }
        }
    }
    public List<CameraPosition> targetPositions = new List<CameraPosition>();

    private Camera _mainCamera;
    private int _currentCameraPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    public void SetPosition(int indexPosition)
    {
        StopAllCoroutines();
        _currentCameraPosition = indexPosition;
        StartCoroutine(ToTargetPosition());
    }

    private IEnumerator ToTargetPosition()
    {
        CameraPosition targetPosition = targetPositions[_currentCameraPosition];

        if (targetPosition.lerpSpeed == 0.0f)
        {
            _mainCamera.transform.position = targetPosition.GetPosition();
            yield break;
        }

        while (_mainCamera.transform.position != targetPositions[_currentCameraPosition].GetPosition())
        {
            _mainCamera.transform.position = Vector3.Lerp(
                _mainCamera.transform.position, targetPosition.GetPosition(), targetPosition.lerpSpeed * Time.deltaTime);
            yield return null;
        }

    }

    private void OnDrawGizmos()
    {
        foreach (CameraPosition cameraPosition in targetPositions)
        {
            Gizmos.DrawWireCube(cameraPosition.GetPosition(), Vector3.one);
        }
    }
}
