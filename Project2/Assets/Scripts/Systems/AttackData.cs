using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Attack")]
public class AttackData : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private string animationName;
    [SerializeField] private AttackContext attackType;

    public int Damage => damage;
    public string AnimationName => animationName;
    public AttackContext AttackType => attackType;
}
