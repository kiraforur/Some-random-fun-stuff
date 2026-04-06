using UnityEngine;
using UnityEngine.UI;
using TMPro;



namespace UI
{
    public class ComboUI : MonoBehaviour
    {
        public TextMeshProUGUI comboText;
        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        public void UpdateCounter(int count)
        {
            comboText.text = count > 0 ? $"Combo x {count}" : "";
        }
    }
}

