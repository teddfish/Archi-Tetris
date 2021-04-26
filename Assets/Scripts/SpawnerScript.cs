using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public static SpawnerScript instance;

    [SerializeField]
    GameObject A, B, C, D, E, F;

    GameObject obj;
    Vector3 pos;

    //setting instance to this script
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = Blocks.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBlock()
    {
        

        int objectID = Random.Range(0, 6);
        if (objectID == 0)
        {
            obj = A;
        }
        else if (objectID == 1)
        {
            obj = B;
        }
        else if (objectID == 2)
        {
            obj = C;
        }
        else if (objectID == 3)
        {
            obj = D;
        }
        else if (objectID == 4)
        {
            obj = E;
        }
        else
        {
            obj = F;
        }

        Instantiate(obj, pos, Quaternion.identity);
    }
}
