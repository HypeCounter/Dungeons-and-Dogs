using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Personagem
{
    [CreateAssetMenu(menuName = ("RPG/Special Ability/Lay of Hands"))]
    public class LayofHandsConfig : AbilityConfig

    {
        [Header("LayofHands Specifics")]
        [SerializeField] float extraHealth = 50f;

        public override AbilityBehavior GetBehaviourComponent(GameObject objectToAttachTo)
        {
            return objectToAttachTo.AddComponent<LayofHandsBehaivor>();
        }

        public float GetExtraHealth()
        {
            return extraHealth;
        }
    }
}