using UnityEngine;

public class FloatingCube : MonoBehaviour {

    const float SPEED_NORMALAIZER = 0.001f;

    public int minForce=10;
    public int maxForce=30;
    public float minScale = 3;
    public float maxScale = 10;
    public float highestFloatCenter = 5;


    private Vector3 initPos;
    private Renderer mesh;
    private float force;
    private Vector3 directionalForce;

	void Start () {
      

        float y=Random.Range(0, highestFloatCenter);
        initPos = transform.position+new Vector3(0f,y,0f);

        SetScale();

        force = Random.Range(minForce, maxForce);
        directionalForce = new Vector3();

    }

    private void SetScale() {
        float s = Random.Range(minScale,maxScale);
        transform.localScale = new Vector3(s,s,s);
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 dir = initPos - transform.position;
        directionalForce += force * dir* SPEED_NORMALAIZER;
        transform.Translate(directionalForce*Time.fixedDeltaTime);
	}
}
