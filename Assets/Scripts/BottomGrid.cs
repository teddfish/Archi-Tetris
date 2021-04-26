using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomGrid : MonoBehaviour
{
    public static BottomGrid inst;

    [SerializeField]
    GameObject bottomGrid;
    [SerializeField]
    GameObject N, S, W, E;
    [SerializeField]
    int gridSizeX, gridSizeY, gridSizeZ;

    public Transform[,,] theGrid;

    public void Awake()
    {
        inst = this;
    }

    void Start()
    {
        theGrid = new Transform[gridSizeX, gridSizeY, gridSizeZ];
    }

    public Vector3 Round(Vector3 vector) { return new Vector3(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z)); }

    public bool GridCheck(Vector3 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridSizeX &&
                (int)pos.z >= 0 && (int)pos.z < gridSizeZ &&
                (int)pos.y >= 0);
    }

    private void OnDrawGizmos()
    {
        if (bottomGrid != null)
        {
            //Resize
            Vector3 scaleAssist = new Vector3((float)gridSizeX / 10, 1, (float)gridSizeZ / 10);
            bottomGrid.transform.localScale = scaleAssist;

            //Change its position
            bottomGrid.transform.position = new Vector3(transform.position.x + (float)gridSizeX / 2,
                                                        transform.position.y,
                                                        transform.position.z + (float)gridSizeZ / 2);

            //Retile the texture
            bottomGrid.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeX, gridSizeZ);
        }

        if (N != null)
        {
            //Resize
            Vector3 scaleAssist = new Vector3((float)gridSizeX / 10, 1, (float)gridSizeY/10);
            N.transform.localScale = scaleAssist;

            //Change its position
            N.transform.position = new Vector3(transform.position.x + (float)gridSizeX / 2,
                                                        transform.position.y + (float)gridSizeY/2,
                                                        transform.position.z + (float)gridSizeZ);

            //Retile the texture
            N.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeX, gridSizeY);
        }

        if (S != null)
        {
            //Resize
            Vector3 scaleAssist = new Vector3((float)gridSizeX / 10, 1, (float)gridSizeY / 10);
            S.transform.localScale = scaleAssist;

            //Change its position
            S.transform.position = new Vector3(transform.position.x + (float)gridSizeX / 2,
                                                        transform.position.y + (float)gridSizeY / 2,
                                                        transform.position.z);

            //Retile the texture
            //S.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeX, gridSizeY);
        }

        if (W != null)
        {
            //Resize
            Vector3 scaleAssist = new Vector3((float)gridSizeZ / 10, 1, (float)gridSizeY / 10);
            W.transform.localScale = scaleAssist;

            //Change its position
            W.transform.position = new Vector3(transform.position.x + gridSizeX,
                                                        transform.position.y + (float)gridSizeY / 2,
                                                        transform.position.z + (float)gridSizeZ / 2);

            //Retile the texture
            //W.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeZ, gridSizeY);
        }

        if (E != null)
        {
            //Resize
            Vector3 scaleAssist = new Vector3((float)gridSizeZ / 10, 1, (float)gridSizeY / 10);
            E.transform.localScale = scaleAssist;

            //Change its position
            E.transform.position = new Vector3(transform.position.x,
                                                        transform.position.y + (float)gridSizeY / 2,
                                                        transform.position.z + (float)gridSizeZ / 2);

            //Retile the texture
            E.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeZ, gridSizeY);
        }
    }
}
