using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health health;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private TMP_Text healthBarText;

    [Header("Health Colour Gradient")]
    [SerializeField] private Gradient healthBarColour;

    private void OnEnable()
    {
        health.OnHealthChange += HandleHealthChange;
    }

    private void OnDisable()
    {
        health.OnHealthChange -= HandleHealthChange;
    }


    private void HandleHealthChange(Health health)
    {
        healthBarImage.fillAmount = (float)health.CurrentHealth / health.MaxHealth;
        healthBarImage.color = healthBarColour.Evaluate((float)health.CurrentHealth / health.MaxHealth);

    }
}
