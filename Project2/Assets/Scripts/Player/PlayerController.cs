using Core;
using State;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IState _currState;

        public Animator Animator { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public PlayerCombat Combat { get; private set; }
        public SuperMoveController SuperMove { get; private set; }
        public InputHandler Input { get; private set; }
        public IState GetCurrentState() => _currState;
        public AttackState AttackState { get; private set; }
        public LocomotionState LocomotionState { get; private set; }
        public JumpState JumpState { get; private set; }
        public SuperState SuperState { get; private set; }

        private void Awake()
        {
            Movement = GetComponent<PlayerMovement>();
            Combat = GetComponent<PlayerCombat>();
            SuperMove = GetComponent<SuperMoveController>();
            Input = GetComponent<InputHandler>();
            Animator = GetComponent<Animator>();

            AttackState = new AttackState(this);
            JumpState = new JumpState(this);
            LocomotionState = new LocomotionState(this);
            SuperState = new SuperState(this);
        }

        private void Start()
        {
            ChangeState(this.LocomotionState);
        }

        private void Update()
        {
            _currState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            _currState?.PhysicsUpdate();
        }

        public void ChangeState(IState newState)
        {
            _currState?.Exit();
            _currState = newState;
            _currState?.Enter();
        }

        public void HandleCommand(ICommand command) => _currState?.HandleCommand(command);
    }
}