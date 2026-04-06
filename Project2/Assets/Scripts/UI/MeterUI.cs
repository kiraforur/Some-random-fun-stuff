using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI
{
    public class MeterUI : MonoBehaviour
    {

        public Image superBar;
        [SerializeField] private SuperMoveController super;

        private void OnEnable()
        {
            var superMeter = super.GetMeter();
            superMeter.OnMeterChanged += UpdateSuper;
            UpdateSuper((float) superMeter.CurrMeter/superMeter.Max);
        }

        private void OnDisable()
        {
            var superMeter = super.GetMeter();
            superMeter.OnMeterChanged -= UpdateSuper;
        }

        public void UpdateSuper(float fillAmount)
        {
            superBar.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }
}
