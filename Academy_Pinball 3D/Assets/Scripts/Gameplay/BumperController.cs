using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [Header("Impact")]
    public AudioController audioController;
    public VFXController vfxController;
    
    [Header("Bumper Setting")]
    public Collider ballCollider;
    public float multipiler = 3.0f;
    public Color color = Color.blue;

    private Rigidbody _ballRigidbody;
    private Renderer _renderer;
    private Animator _animator;
    
    private static readonly int _hitHash = Animator.StringToHash("Hit");

    private void Start()
    {
        _ballRigidbody = ballCollider.attachedRigidbody;
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<Renderer>();

        _renderer.material.color = color;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == ballCollider)
        {
            _ballRigidbody.velocity *= multipiler;
            _animator.SetTrigger(_hitHash);
            audioController.PlaySFX(other.transform.position, 0);
            vfxController.PlayVFX(other.transform.position);
        }
    }
}
