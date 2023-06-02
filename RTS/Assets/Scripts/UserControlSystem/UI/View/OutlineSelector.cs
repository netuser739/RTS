using System.Linq;
using UnityEngine;

namespace UserControlSystem.UI.View
{
    public class OutlineSelector : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderers;
        [SerializeField] private Material[] _outlineMaterial;

        private bool _isSelectedCache;

        public void SetSelected(bool isSelected)
        {
            if (isSelected == _isSelectedCache)
                return;

            for (int i = 0; i < _renderers.Length; i++)
            {
                var renderer = _renderers[i];
                var materialsList = renderer.materials.ToList();

                if (isSelected)
                {
                    for (int j = 0; j < _outlineMaterial.Length; j++)
                        materialsList.Add(_outlineMaterial[j]);
                }
                else
                    materialsList.RemoveAt(materialsList.Count - 1);

                renderer.materials = materialsList.ToArray();
            }

            _isSelectedCache = isSelected;
        }
    }
}