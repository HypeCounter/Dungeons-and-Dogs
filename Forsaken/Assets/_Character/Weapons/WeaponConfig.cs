using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Personagem
{

    [CreateAssetMenu(menuName = ("RPG/Weapon"))]


    public class WeaponConfig : ScriptableObject
    {


        public Transform gripTransform;

        [SerializeField] GameObject weaponPrefab;
        [SerializeField] AnimationClip attackAnimation;
        [SerializeField] AnimationClip idleWeapon;
        [SerializeField] AnimationClip deathAnimation;
        [SerializeField] float timeBetweenCycles = .5f;
        [SerializeField] float maxAttackRange = 1f;
        [SerializeField] float weaponDamage = 10f;
        [SerializeField] float damageDelay = 0.5f;
        
        public float GetTimeBetweenAnimationCycles()
        {
            return timeBetweenCycles;
        }
        public float GetMaxAttackRange() {
            return maxAttackRange;
        }

        public float GetDamageDelay()
        {
            return damageDelay;
        }


        public GameObject GetWeaponPrefab()
        {
            return weaponPrefab;
        }
        public AnimationClip GetAttackAnimClip()
        {
            RemoveAnimationEvent(); //evita bugs no asset de animacao
            return attackAnimation;
        }
        public AnimationClip GetDeathAnimClip()
        {
            return deathAnimation;
        }

        private void RemoveAnimationEvent()
        {
            attackAnimation.events = new AnimationEvent[0];
        }

        public AnimationClip GetIdleWeaponClip()
        {
            return idleWeapon;
        }
        public float GetWeaponDamage()
        {
            return weaponDamage;
        }

    }

}
