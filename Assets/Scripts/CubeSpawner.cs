using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    public GameObject cube;
    public int numOfCubes = 100;
    public float scale = 20f;
    public Transform cubesParent;
    public GameObject prize;

    public float yBottom = 5;
    public float yTop = 100;

    private float xWidth;
    private float zWidth;
    
    // Use this for initialization
    void Start () {
        BoxCollider plane = GetComponent<BoxCollider>();

        transform.localScale=new Vector3(scale,1,scale);

        xWidth = plane.bounds.max.x;    //transform.localScale.x;
        zWidth = plane.bounds.max.z;    //transform.localScale.z;

        Transform max = transform;
        for (int i =0; i<numOfCubes; i++) {
            Transform cur = SpawnCube();
            if (cur.position.y > max.position.y)
                max = cur;
            Debug.Log(max.position);
        }

        Vector3 prizePos = max.position + Vector3.up * max.localScale.y;
        Instantiate(prize, prizePos, Quaternion.identity , max);
	}

    Transform SpawnCube() {
        float x = Random.Range(-xWidth, xWidth);
        float z = Random.Range(-zWidth, zWidth);
        float y = Random.Range(yBottom, yTop);
        Vector3 newPos = new Vector3(x, y, z);
        GameObject c= Instantiate(cube, newPos, Quaternion.identity,cubesParent);
        return c.transform;
    }
	
}
