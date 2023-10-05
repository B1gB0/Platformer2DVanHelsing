using UnityEngine;

public class CoinGenerator : CoinPool
{
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Coin _coin;

    private void Start()
    {
        Initialize(_coin);
        SpawnCoin();
    }

    private void SetCoin(Coin coin, Vector3 spawnPoint)
    {
        coin.gameObject.SetActive(true);
        coin.transform.position = spawnPoint;
    }

    private void SpawnCoin()
    {
        for (int i = 0; i < _capacity; i++)
        {
            int numberSpawnPoint = Random.Range(0, _spawnPoint.Length);

            if (TryGetCoin(out Coin coinPrefab))
            {
                SetCoin(coinPrefab, _spawnPoint[numberSpawnPoint].transform.position);
                _coin = coinPrefab;
            }
        }
    }
}
