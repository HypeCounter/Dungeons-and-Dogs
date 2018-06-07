using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Personagem;
using RPG.Core;
using System;

public class DivineBehaviour : AbilityBehavior {




    
    public override void Use(GameObject target)
    {
        DealingDamage();
        PlayParticleEffect();
        PlaySpecialAbilityAudio();
        PlayAnimationClip();
    }



    private void DealingDamage()
    {
       
        // static sphere para os alvos
        RaycastHit[] hits = Physics.SphereCastAll(
            transform.position, (config as DivineConfig).GetRadius()
            , Vector3.up, (config as DivineConfig).GetRadius());
        foreach (RaycastHit hit in hits)
        {
            var damageable = hit.collider.gameObject.GetComponent<HealthSystem>();
            bool hitPlayer = hit.collider.gameObject.GetComponent<PlayerMovement>();
            if (damageable != null && !hitPlayer)
            {
                float damageToDeal = (config as DivineConfig).DamageToEachTarget();
                damageable.TakeDamage(damageToDeal);

            }
        }
    }
}
