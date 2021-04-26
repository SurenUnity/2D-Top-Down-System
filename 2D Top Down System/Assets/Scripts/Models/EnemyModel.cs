using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "CharacterModels/Enemy", order = 0)]
    public class EnemyModel : ScriptableObject
    {
        public Vector2 maxRange;
        public Vector2 minRange;

        public float speed;
        public int damage;
    }
}
