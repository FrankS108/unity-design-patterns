using UnityEngine;

namespace Patterns.Behaviour.Observer
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private SkillView _skillView;
        
        private void Awake()
        {
            var skill = new Skill();
            _skillView.Configure(skill);
        }
    }
}
