using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode inputKeycode = KeyCode.RightArrow;

    private float _targetPressed;
    private float _targetRelease;
    private HingeJoint _hinge;
    // Start is called before the first frame update
    void Start()
    {
        _hinge = GetComponent<HingeJoint>();
        _targetPressed = _hinge.limits.max;
        _targetRelease = _hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        SpringControl();
    }

    private void SpringControl()
    {
        JointSpring jointSpring = _hinge.spring;
        if (Input.GetKey(inputKeycode))
        {
            jointSpring.targetPosition = _targetPressed;
        }
        else
        {
            jointSpring.targetPosition = _targetRelease;
        }
        _hinge.spring = jointSpring;
    }
}
