using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{

    public ParticleSystem particleSystem;
    
    public void Destroy()
    {
        if (particleSystem != null)
        {
            transform.Find("Wall").gameObject.SetActive(false);
        
            Instantiate(particleSystem, transform.position, transform.rotation).Play();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
