using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public static Blocks instance;

    float previousTime;
    float fallTime = 1f;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - previousTime > fallTime)
        {
            transform.position += Vector3.down;

            if (!CheckValid())
            {
                transform.position += Vector3.up;
                SpawnerScript.instance.SpawnBlock();
                enabled = false;
            }

            else
            {
                //Update Grid
                //BottomGrid.inst.UpdateGrid(this);
            }


            previousTime = Time.time;
            print(CheckValid());

        }

        if (Input.GetKey(KeyCode.Space))
        {
            fallTime = 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Movez(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Movez(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Movez(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Movez(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Rotatationz(new Vector3(90, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Rotatationz(new Vector3(0, 90, 0));
        }

    }

    public void Movez(Vector3 direction)
    {
        transform.position += direction;
        if (!CheckValid())
        {
            transform.position -= direction;
        }
    }

    public void Rotatationz(Vector3 rotation)
    {
        transform.Rotate(rotation, Space.World);
        if (!CheckValid())
        {
            transform.Rotate(-rotation, Space.World);
        }
    }

    bool CheckValid()
    {
        foreach(Transform child in transform)
        {
            Vector3 pos = BottomGrid.inst.Round(child.position);
            if (!BottomGrid.inst.GridCheck(pos))
            {
                return false;
            }
        }


        return true;
    }


}
