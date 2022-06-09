using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Idle
{
    public class ParticleManager : MonoBehaviour
    {
        [Header("Particle")]
        public ParticleSystem clickEffect;

        // Method of playing effect, accepts any effect from cached
        public void PlayEffect(ParticleSystem particleSystem)
        {
            GameObject particle = Instantiate(particleSystem.gameObject); //Create the effect on scene
            particle.transform.parent = Camera.main.transform; //Put it under the parent
            particleSystem.Play(); //Play
        }
    }
}