using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{

    public GameObject arrowPrefab;
    float span;
    public float min;
    public float max;
    float delta = 0;


    void Update()
    {
        this.span = Random.Range(min, max + 1);
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
