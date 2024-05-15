using UnityEngine;
using UnityEngine.Pool;

namespace Arkanoid
{
    public class BonusSpawner : MonoBehaviour
    {
        public static BonusSpawner Instance { get; private set; }
        public ObjectPool<BonusBehaviour> Pool { get; private set; }

        [SerializeField]
        private BonusBehaviour bonusPrefab;

        private void Awake()
        {
            Instance = this;
            Pool = new ObjectPool<BonusBehaviour>(CreateBonus, OnGetBonus, OnReleaseBonus, OnDestroyBonus, true, 5, 100);
        }

        private BonusBehaviour CreateBonus()
        {
            var bonus = Instantiate(bonusPrefab, gameObject.transform);
            bonus.SetPool(Pool);

            return bonus;
        }

        private void OnGetBonus(BonusBehaviour bonus)
        {
            bonus.gameObject.SetActive(true);
        }

        private void OnReleaseBonus(BonusBehaviour bonus)
        {
            bonus.gameObject.SetActive(false);
        }

        private void OnDestroyBonus(BonusBehaviour bonus)
        {
            Destroy(bonus.gameObject);
        }
    }
}