using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] protected int _capacity;

    private List<Coin> _pool = new();

    protected void Initialize(Coin prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Coin spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetCoin(out Coin result)
    {
        result = _pool.First(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
