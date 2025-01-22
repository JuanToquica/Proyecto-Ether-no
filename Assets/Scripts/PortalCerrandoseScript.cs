using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PortalCerrandoseScript : MonoBehaviour
{
    public ParticleSystem portal;
    public ParticleSystem portalCerrandose;

    void Start()
    {
        StartCoroutine(VfxPortalCerrandose());
    }

    [ContextMenu("VfxPortalCerrandose")]
    private IEnumerator VfxPortalCerrandose()
    {
        portal.Play();
        yield return new WaitForSeconds(4.3f);
        portalCerrandose.Play();
        portal.Stop();  
    }

  
}
