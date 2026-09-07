using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Projectile/Create ProjectileId", fileName = "ProjectileId", order = 0)]
    public class ProjectileId : ScriptableObject
    {
        [SerializeField] private string value;

        public string Value => value;

        // Se ejecuta CUANDO SE CREA el ScriptableObject (asset)
        private void OnEnable()
        {
            // Solo genera ID si no existe
            if (string.IsNullOrEmpty(value))
            {
                GenerateNewID();
            }
        }

        // Método para generar nuevo ID
        public void GenerateNewID()
        {
            value = System.Guid.NewGuid().ToString();
#if UNITY_EDITOR
            // Marca el asset como modificado para guardar el cambio
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }
}