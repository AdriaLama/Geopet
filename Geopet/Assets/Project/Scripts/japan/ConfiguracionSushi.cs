using System.Collections.Generic;
using UnityEngine;

public class ConfiguracionSushi : MonoBehaviour
{
    [CreateAssetMenu(fileName = "ConfiguracionSushi", menuName = "Configuraciones/ConfiguracionSushi")]
    public class ConfiguracionComida : ScriptableObject
    {
        public Sprite sprite;
        public float velocidad;
        public float gold;
        public Collider2D collider;
    }
}
