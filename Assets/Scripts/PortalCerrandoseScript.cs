using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PortalCerrandoseScript : MonoBehaviour
{
    public ParticleSystem portal;
    public ParticleSystem portalCerrandose;
    public AudioSource portalSound;
    public AudioSource portalExplode;

    void Start()
    {
        StartCoroutine(VfxPortalCerrandose());
    }

    [ContextMenu("VfxPortalCerrandose")]
    private IEnumerator VfxPortalCerrandose()
    {
        portal.Play();
        portalSound.Play();
        yield return new WaitForSeconds(4.3f);
        portalCerrandose.Play();
        portal.Stop();
        yield return new WaitForSeconds(0.5f);
        portalExplode.Play();
        yield return new WaitForSeconds(0.5f);
        portalSound.Stop();
    }

  
}
