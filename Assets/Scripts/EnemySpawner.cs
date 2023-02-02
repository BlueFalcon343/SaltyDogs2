using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;

    public int hitPoints = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2f, 2), Random.Range(-2f, 2f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    public void hitCount()
    {
        hitPoints = hitPoints - 1;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    

}
