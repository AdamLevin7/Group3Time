using TMPro;
using UnityEngine;

namespace UtilComponents
{
    public class TextClone : MonoBehaviour
    {
        public GameObject reference;
        private TextMeshProUGUI _theirText;
        private TextMeshProUGUI _myText;

        private void Start()
        {
            _theirText = reference.GetComponent<TextMeshProUGUI>();
            _myText = GetComponent<TextMeshProUGUI>();
        }

        private void LateUpdate()
        {
            _myText.text = _theirText.text;
        }
    }
}