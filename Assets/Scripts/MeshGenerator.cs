using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    
    Vector3[] vertices;
    int[] triangels;
 
    public int xSize = 500;
    public int zSize = 500;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
        
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize+1)*(zSize+1)];

        int i=0;
        for(int z = 0; z<= zSize; z++)
        {
            for(int x=0; x<=xSize; x++)
            {
                float xCoord = x/xSize;
                float zCoord = z/zSize;
                float y = (float)Mathf.PerlinNoise(x*0.3f, z*0.3f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        int vert = 0;
        int tris = 0;
        triangels = new int[xSize*zSize*6];
        

        for(int z=0; z<zSize;z++)
        {

            for(int x= 0; x< xSize; x++)
            {
                triangels[tris + 0] = vert + 0;
                triangels[tris + 1] = vert + xSize+1;
                triangels[tris + 2] = vert + 1;
                triangels[tris + 3] = vert+ 1;
                triangels[tris + 4] = vert + xSize+1;
                triangels[tris + 5] = vert + xSize+2;
                
                vert++;
                tris += 6;

                //yield return new WaitForSeconds(0.03f);
            }
            //vert++;

        }

        
    }


    // Update is called once per frame
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangels;

        mesh.RecalculateNormals();
        
    }


}
