using UnityEngine;
using System.Collections;

public class SizeChangeWithRose : MonoBehaviour {

	GameObject RoseSphere;

	public float distal;
	public float scale;
	public float scaleResizer = 2;
	public float maxSizePlusAlpha = 0.2f;
	public bool limitter = true;

	// Use this for initialization
	void Start(){
		RoseSphere = (GameObject)transform.parent.FindChild("RoseSphere").gameObject;
	}
	
	// Update is called once per frame
	void Update(){
		distal =Mathf.Sqrt(Mathf.Pow((RoseSphere.transform.localPosition.x - transform.localPosition.x),2)+
		                   Mathf.Pow((RoseSphere.transform.localPosition.y - transform.localPosition.y),2));
		if(limitter){
			if(distal/scaleResizer < 1 + maxSizePlusAlpha){
				scale = distal/scaleResizer;
			}else scale = 1 + maxSizePlusAlpha;
		}else scale = distal/scaleResizer;
		transform.localScale = new Vector3(scale,scale,scale);
	}
}
