using UnityEngine;
using System.Collections;

public class CubePlacer : MonoBehaviour {

	public GameObject Cube;
	public GameObject RoseSphere;

	public float dist;

	public int width = 12;
	public int height = 38;
	
	// Use this for initialization
	void Start(){
		dist = (Cube.transform.localScale.x * width/2)/Mathf.Tan(Mathf.Deg2Rad * 27.5f);
		for(int i = 1;i < 9;i++){
			localInstantiate(i);
		}
	}
	
	// Update is called once per frame
	void Update(){

	}
	void localInstantiate(int i){
		GameObject localGameObject;
		GameObject emptyGameObject;
		emptyGameObject = new GameObject("CubesParent");
		emptyGameObject.transform.position = new Vector3(0,0,0);
		localGameObject = Instantiate(RoseSphere) as GameObject;
		localGameObject.transform.position = new Vector3(0,0,dist);
		localGameObject.transform.parent = emptyGameObject.transform;
		localGameObject.name = "RoseSphere";
		for(float h = -((height/2)-Cube.transform.localScale.y/2)*Cube.transform.localScale.y;h < ((height/2)-Cube.transform.localScale.y/2)*Cube.transform.localScale.y + Cube.transform.localScale.y;h += Cube.transform.localScale.y){
			for(float w = -((width/2)-Cube.transform.localScale.x/2)*Cube.transform.localScale.x;w < ((width/2)-Cube.transform.localScale.x/2)*Cube.transform.localScale.x + Cube.transform.localScale.x;w += Cube.transform.localScale.x){
				localGameObject = Instantiate(Cube) as GameObject;
				localGameObject.transform.position = new Vector3(w,h,dist+Cube.transform.localScale.z*3);
				localGameObject.transform.parent = emptyGameObject.transform;
				Debug.Log(w);
			}
		}
		emptyGameObject.transform.rotation = Quaternion.Euler(0,45.0f*i,0);
	}
}
