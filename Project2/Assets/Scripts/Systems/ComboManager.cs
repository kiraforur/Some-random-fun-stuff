using System;
using System.Collections.Generic;

namespace Systems
{
    public class ComboManager
    {
        private Dictionary<AttackContext, ComboString> combos;
        private AttackContext currentContext;
        public event Action<int> OnComboChanged;

        private int currCombo = 0;

        private readonly float comboTime = 2f;
        private float timer = 0;
        public float CurrTime => timer;

        private bool ComboActive => currCombo > 0;

        public ComboManager(Dictionary<AttackContext, ComboString> combos)
        {
            this.combos = combos;
        }

        public AttackData PerformAttack(AttackContext context)
        {
            if (!combos.TryGetValue(context, out ComboString combo))
                return null;

            
            if (currentContext != context)
            {
                if (combos.TryGetValue(currentContext, out ComboString oldCombo))
                {
                    oldCombo.Reset();
                }
            }


            currentContext = context;

            currCombo++;
            timer = comboTime;
            OnComboChanged?.Invoke(currCombo);

            return combo.GetNextAttack();
        }

        public void ResetCombo()
        {
            currCombo = 0;
            timer = 0;
            OnComboChanged?.Invoke(currCombo);
            if (combos.TryGetValue(currentContext, out ComboString combo))
            {
                combo.Reset();
            }
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

