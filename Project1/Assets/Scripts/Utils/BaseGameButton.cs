using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseGameButton : MonoBehaviour
    {
        [SerializeField] private ActionType actionType;
        public ActionType ActionType => actionType;

        protected Button button;

        public event Action<ActionType> OnButtonClicked;

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(HandleClick);
        }

        private void HandleClick()
        {
            ExecuteLogic();
            OnButtonClicked?.Invoke(ActionType);
        }

        protected abstract void ExecuteLogic();
    }
}
