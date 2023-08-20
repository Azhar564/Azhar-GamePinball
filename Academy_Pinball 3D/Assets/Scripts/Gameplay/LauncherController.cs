using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider ballCollider;
    public KeyCode inputKeycode = KeyCode.Space;

    public float maxTimeHold;
    public float maxForce;

    [Header("Effect")]
    public Material holdMaterial;
    public Material releaseMaterial;


    private MeshRenderer _renderer;
    private bool _isHold;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider == ballCollider)
        {
            ReadInput(ballCollider);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(inputKeycode) && !_isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        _isHold = true;
        _renderer.material = holdMaterial;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(inputKeycode) && timeHold < maxTimeHold)
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.attachedRigidbody.AddForce(Vector3.forward * force);
        _renderer.material = releaseMaterial;
        _isHold = false;
    }
}
