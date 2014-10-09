using UnityEngine;
using System.Collections;

public class RoseCurve : MonoBehaviour {

	private float xPos;
	private float yPos;
	
	public float sR = 1;
	public float cR = 1;

	public float sA = 10;
	public float cA = 14;

	public float sTest;
	public float cTest;

	public float[] timer = new float[4];

	// Use this for initialization
	void Start(){
		for(int i = 0;i < timer.Length;i++){
			timer[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update(){
		timer[0] += Time.deltaTime/4;
		timer[1] += Time.deltaTime/4 + 0.002f;

		sTest = Mathf.Sin(2*timer[0]);
		cTest = Mathf.Sin(5*timer[1]);

		xPos = sA * sTest * Mathf.Sin(sR*timer[1]);
		yPos = cA * cTest * Mathf.Cos(cR*timer[0]);

		transform.localPosition = new Vector2(xPos,yPos);

	}
}
