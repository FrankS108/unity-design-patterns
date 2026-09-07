using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Behaviour.Observer
{
    public class SkillView : MonoBehaviour, Observer
    {
        [SerializeField] private TextMeshProUGUI chargesText;
        [SerializeField] private Button skillButton;

        public void Configure(Skill skill)
        {
            skillButton.onClick.AddListener(skill.Use);

            skill.Subscribe(this);
        }

        public void Updated(Subject subject)
        {
            if (subject is Skill skill)
            {
                skillButton.interactable = skill.IsReady;
                chargesText.SetText(skill.Charges.ToString());
            }
        }
    }
}
