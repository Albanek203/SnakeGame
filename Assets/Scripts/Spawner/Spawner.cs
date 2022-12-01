using UnityEngine;

public class Spawner : MonoBehaviour {
    [Header("General")]
    [SerializeField]
    private Transform _spawnContainer;
    [SerializeField]
    private int _repeatCount;
    [SerializeField]
    private int _distanceBetweenFullLine;
    [SerializeField]
    private int _distanceBetweenRandomLine;

    [Header("Block")]
    [SerializeField]
    private Block _blockTemplate;
    [SerializeField]
    private int _blockSpawnChance;

    [Header("Wall")]
    [SerializeField]
    private Wall _wallTemplate;
    [SerializeField]
    private int _wallSpawnChance;

    [Header("Finish")]
    [SerializeField]
    private Finish _finishTemplate;

    [Header("Bonus")]
    [SerializeField]
    private Bonus _bonusTemplate;
    [SerializeField]
    private int _bonusSpawnChance;

    private BlockSpawnPoint[] _blockSpawnPoints;
    private WallSpawnPoint[] _wallSpawnPoints;
    private BonusSpawnPoint[] _bonusSpawnPoints;

    private void Start() {
        _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        _bonusSpawnPoints = GetComponentsInChildren<BonusSpawnPoint>();
        for (var i = 0; i < _repeatCount; i++) {
            MoveSpawner(_distanceBetweenFullLine);
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChance);
            GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);
            MoveSpawner(_distanceBetweenRandomLine);
            
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChance);
            GenerateRandomLine(_blockSpawnPoints, _blockTemplate.gameObject, _blockSpawnChance);
            GenerateRandomLine(_bonusSpawnPoints, _bonusTemplate.gameObject, _bonusSpawnChance);
        }
        MoveSpawner(_distanceBetweenFullLine);
        GenerateElement(transform.position, _finishTemplate.gameObject);
    }

    private void MoveSpawner(int distanceY) {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }

    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject spawnObject) {
        foreach (var spawnPoint in spawnPoints) GenerateElement(spawnPoint.transform.position, spawnObject);
    }

    private void GenerateRandomLine(SpawnPoint[] spawnPoints, GameObject spawnObject, int spawnChance) {
        foreach (var spawnPoint in spawnPoints) {
            if (Random.Range(0, 100) < spawnChance) GenerateElement(spawnPoint.transform.position, spawnObject);
        }
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject spawnObject) {
        return Instantiate(spawnObject, spawnPoint, Quaternion.identity, _spawnContainer);
    }
}