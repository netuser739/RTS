using Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem
{
    public class Selection : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectableValue;
        private Outline _outline;


        private void Start()
        {
            _outline = gameObject.AddComponent<Outline>();
            _outline.enabled = false;
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.yellow;
            _outline.OutlineWidth = 3f;
            _selectableValue.OnSelected += SelectObject;
            //SelectObject(_selectableValue.CurrentValue);
        }

        public void SelectObject(ISelectable selected) =>
            _outline.enabled = selected != null;
    }
}