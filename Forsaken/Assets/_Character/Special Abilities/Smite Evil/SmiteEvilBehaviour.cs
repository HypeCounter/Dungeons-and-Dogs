using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Personagem
{
    public class SmiteEvilBehaviour : AbilityBehavior
    {

        AudioSource audioSouce = null;

        public override void Use(GameObject target)
        {
            transform.LookAt(target.transform);
            DealDamage(target);
            PlayParticleEffect();
            PlaySpecialAbilityAudio();
            PlayAnimationClip();
        }

        private void DealDamage(GameObject target)
        {
            float damageToDeal = (config as SmiteEvilConfig).GetExtraDamage();
            target.GetComponent<HealthSystem>().TakeDamage(damageToDeal);
        }
    }
}