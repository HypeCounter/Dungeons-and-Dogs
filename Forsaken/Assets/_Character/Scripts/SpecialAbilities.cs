using UnityEngine;
using UnityEngine.UI;
using RPG.CameraUI;
using System;

namespace RPG.Personagem
{
    public class SpecialAbilities : MonoBehaviour
    {
        [SerializeField] Image energyOrb = null;
        [SerializeField] float maxEnergyPoints = 100f;
        [SerializeField] float regenPointsPerSecond = 1f;
        public float currentEnergyPoints;
        [SerializeField] AudioClip outOfEnergy;
        AudioSource audioSource;


        [SerializeField] AbilityConfig[] abilities;


        float energyAsPercent { get { return currentEnergyPoints / maxEnergyPoints; } }

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            AttachInitialAbilities();
            currentEnergyPoints = maxEnergyPoints;
            UpdateEnergyBar();

        }

        void Update()
        {
            if (currentEnergyPoints < maxEnergyPoints)
            {
                AddEnergyPoints();
                UpdateEnergyBar();
            }
        }

        public int GetNumbersOfAbilities()
        {
            return abilities.Length;
        }

        void AttachInitialAbilities()
        {
            for (int abilityIndex = 0; abilityIndex < abilities.Length; abilityIndex++)
            {
                abilities[abilityIndex].AttachAbilityTo(gameObject);
            }
        }
        private void AddEnergyPoints()
        {
            var pointsToAdd = regenPointsPerSecond * Time.deltaTime;
            currentEnergyPoints = Mathf.Clamp(currentEnergyPoints + pointsToAdd, 0, maxEnergyPoints);
        }

        public void ConsumeEnergy(float amount)
        {
            float newEnergyPoints = currentEnergyPoints - amount;
            currentEnergyPoints = Mathf.Clamp(newEnergyPoints, 0, maxEnergyPoints);
            UpdateEnergyBar();
        }

     
        public void UpdateEnergyBar()
        {
            if (energyOrb)
            {
                energyOrb.fillAmount = energyAsPercent;
            }
        }

        public void AttemptSpecialAbility(int abilityIndex, GameObject target = null)
        {          
            var energyCost = abilities[abilityIndex].GetEnergyCost();
            var abilitySound = GetComponent<AbilityBehavior>();

            if (energyCost <= currentEnergyPoints)
            {
                ConsumeEnergy(energyCost);
                abilities[abilityIndex].Use(target);
            }
            else
            {                
                 audioSource.PlayOneShot(outOfEnergy);                
            }
        }
    }
}
