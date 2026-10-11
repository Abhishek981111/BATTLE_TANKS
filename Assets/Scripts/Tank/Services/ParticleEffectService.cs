using UnityEngine;
using System.Collections;

namespace BATTLE_TANKS
{
    public class ParticleEffectService : GenericSingleton<ParticleEffectService>
    {
        [SerializeField] private ParticleSystem tankExplosionEffect;
        [SerializeField] private float tankExplosionEffectDuration;


        public void ShowTankExplosionEffect(Vector3 spawnPosition)
        {
            ParticleSystem effect = Instantiate(tankExplosionEffect, spawnPosition, Quaternion.identity);
            effect.Play();
            StartCoroutine(DestroyEffect(effect, tankExplosionEffectDuration));
        }

        IEnumerator DestroyEffect(ParticleSystem effect, float duration)
        {
            yield return new WaitForSeconds(duration);
            Destroy(effect.gameObject);
        }
    }
}
