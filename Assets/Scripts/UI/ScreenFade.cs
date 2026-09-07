using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScreenFade : MonoBehaviour
    {
        [SerializeField] private Image screenFadeImage;

        public void Show()
        {
            screenFadeImage.enabled = true;
        }

        public void Hide()
        {
            screenFadeImage.enabled = false;
        }
    }

}
