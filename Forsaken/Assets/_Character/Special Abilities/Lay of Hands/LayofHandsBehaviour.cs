using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Personagem
{
    public class LayofHandsBehaivor : AbilityBehavior
    {

        PlayerMovement player = null;


        void Start()
        {
            player = GetComponent<PlayerMovement>();

        }


        public override void Use(GameObject target)
        {
            PlaySpecialAbilityAudio();
            var playerHealth = player.GetComponent<HealthSystem>();
            playerHealth.Heal((config as LayofHandsConfig).GetExtraHealth());
            PlayParticleEffect();
            PlayAnimationClip();

        }

    }
}