using TMPro;
using UnityEngine;

namespace Utilities
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private string levelNumText;
        [SerializeField] private string levelTitleText;

        [SerializeField] private TextMeshPro levelNum;
        [SerializeField] private TextMeshPro levelTitle;
        
        private void Awake()
        {
            levelNum.text = $"Level {levelNumText}";
            levelTitle.text = levelTitleText;
        }
    }
}
