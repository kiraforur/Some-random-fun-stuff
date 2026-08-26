using System;
using System.Collections.Generic;

namespace Systems
{
    public class ComboManager
    {
        public event Action<int> OnComboChanged;

        private int currCombo = 0;

        private readonly float comboTime = 2f;
        private float timer = 0;
        public float CurrTime => timer;

        private bool ComboActive => currCombo > 0;

        public ComboManager()
        {
           
        }

        public void ResetCombo()
        {
            currCombo = 0;
            timer = 0;
            OnComboChanged?.Invoke(currCombo);
        }

        
        public void Tick(float deltaTime)
        {
            if (ComboActive)
            {
                timer -= deltaTime;
                if (timer <= 0)
                    ResetCombo();
            }
        }
    }
}

