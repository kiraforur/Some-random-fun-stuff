using UnityEngine;
using UnityEngine.UI;
using Player;
 
namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        public Image healthBar;
        [SerializeField] private PlayerHealth playerHealth;

        private void Start()
        {
            var health = playerHealth.GetHealth();
            health.OnHealthChanged += UpdateHealth;
            UpdateHealth(health.CurrHealth/health.MaxHealth);
        }

        private void OnDisable()
        {
            var health = playerHealth.GetHealth();
            health.OnHealthChanged -= UpdateHealth;
        }
        public void UpdateHealth(float fillAmount)
        {
            healthBar.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }

}
