using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFall : MonoBehaviour
{
    public GameObject[] bricks;
    public GameObject floor;
    public float spawnInterval = 1f;
    public float spawnRange = 2f;

    void Start()
    {
        StartCoroutine(SpawnBricks());
    }

    IEnumerator SpawnBricks()
    {
        while (true)
        {
            int randomBrickIndex = Random.Range(0, bricks.Length);
            GameObject newBrick = Instantiate(bricks[randomBrickIndex], transform.position, Quaternion.identity);
            newBrick.transform.localScale = new Vector3(0.3f, 0.3f, 2f);
            BoxCollider2D boxCollider = newBrick.AddComponent<BoxCollider2D>();
            Rigidbody2D rigidbody = newBrick.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0.05f;
            BrickBehavior brickBehavior = newBrick.GetComponent<BrickBehavior>();
            if (brickBehavior != null)
                brickBehavior.SetIsClone(true); // Set the flag to indicate it's a clone

            // Adjust the x-axis position randomly
            float randomX = Random.Range(-5f, 5f);
            newBrick.transform.position = new Vector3(randomX, transform.position.y, transform.position.z);

            yield return new WaitForSeconds(1f);
        }
    }

}
