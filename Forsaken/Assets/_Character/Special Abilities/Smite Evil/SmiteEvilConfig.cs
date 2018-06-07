using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Personagem
{
    [CreateAssetMenu(menuName = ("RPG/Special Ability/Power Attack"))]
    public class SmiteEvilConfig : AbilityConfig

    {
        [Header("Power Attack Specifics")]
        [SerializeField] float extraDamage = 10f;
        public override AbilityBehavior GetBehaviourComponent(GameObject objectToAttachTo)
        {
            return objectToAttachTo.AddComponent<SmiteEvilBehaviour>();
        }
        public float GetExtraDamage()
        {
            return extraDamage;
        }
    }
}