using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Attack")]
public class AttackData : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private string animationName;
    [SerializeField] private AnimationClip animation;
    [SerializeField] private float _frameWindow;
    

    public int Damage => damage;
    public float FrameWindow => _frameWindow;
    public string AnimationName => animationName;
    
}
