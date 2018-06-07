using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Personagem
{
    [CreateAssetMenu(menuName = ("RPG/Special Ability/Divine Punishment"))]
    public class DivineConfig : AbilityConfig

    {
        [Header("Divine Punishment Specifics")]
        [SerializeField]        float radius = 5f;
        [SerializeField]    float damageToEachTarget = 15f;



        public override AbilityBehavior GetBehaviourComponent(GameObject objectToAttachTo)
        {
            return objectToAttachTo.AddComponent<DivineBehaviour>();
        }
        public float DamageToEachTarget()
        {
            return damageToEachTarget;
        }
        public float GetRadius()
        {
            return radius;
        }
    }
}