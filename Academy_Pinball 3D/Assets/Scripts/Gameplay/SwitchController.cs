using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public enum SwitchState
    {
        On,
        Off,
        Blink
    }
    [Header("Impact")]
    public AudioController audioController;
    public VFXController vfxController;

    [Header("Bumper Setting")]
    public Collider ballCollider;
    public Material offMaterial;
    public Material onMaterial;

    private SwitchState _switchState;
    private Renderer _renderer;
    private WaitForSeconds _blinkDelay;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _blinkDelay = new WaitForSeconds(0.5f);

        SetSwitch(false);
        StartCoroutine(BlinkAfter(5.0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ballCollider)
        {
            Toogle();
            vfxController.PlayVFX(other.transform.position);

            //sound nyalakan switch
            audioController.PlaySFX(transform.position, 0);
        }
    }

    private void SetSwitch(bool active)
    {
        if (active)
        {
            _switchState = SwitchState.On;
            _renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            StopAllCoroutines();
            _switchState = SwitchState.Off;
            _renderer.material = offMaterial;
            StartCoroutine(BlinkAfter(1.0f));
        }
    }

    private void Toogle()
    {
        SetSwitch(_switchState == SwitchState.On);
    }

    private IEnumerator Blink(int blinkCount)
    {
        _switchState = SwitchState.Blink;

        for (int i = 0; i < blinkCount; i++)
        {
            _renderer.material = onMaterial;
            yield return _blinkDelay;
            _renderer.material = offMaterial;
            yield return _blinkDelay;
        }

        _switchState = SwitchState.Off;

        //sound matikan switch
        audioController.PlaySFX(transform.position, 1);
    }

    private IEnumerator BlinkAfter(float timer)
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(Blink(2));
    }
}
