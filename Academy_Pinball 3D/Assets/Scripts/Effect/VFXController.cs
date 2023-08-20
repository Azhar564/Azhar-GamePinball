using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public GameObject vfx;

    public void PlayVFX(Vector3 position)
    {
        Destroy(Instantiate(vfx, position, Quaternion.identity), 2.0f);
    }
}
