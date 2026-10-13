using UnityEngine;
using System;

namespace Systems 
{
    public class SuperMeter 
    {
        public int CurrMeter { get; private set; }
        public int Max { get; private set; }
        public event Action<float> OnMeterChanged;

        public SuperMeter(int max)
        {
            Max = max;
            CurrMeter = 0;
            
        }

        public void Add(int amount)
        {
            CurrMeter = Mathf.Min(CurrMeter + amount, Max);
            OnMeterChanged?.Invoke((float)CurrMeter / Max);
        }

        public void Reset()
        {
            CurrMeter = 0;
            OnMeterChanged?.Invoke((float)CurrMeter);
        }
    }
}