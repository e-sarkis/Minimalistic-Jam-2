using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour 
{
	public GameObject shooter;	// The Player who fired this projectile
	public GameObject target;	// The Target of this projectile
	virtual public void Launch() {  }
}
