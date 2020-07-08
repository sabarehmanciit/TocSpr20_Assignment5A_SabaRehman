using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets;

public class sceneManager : MonoBehaviour {

	public void loadScene(string str)
	{
		SceneManager.LoadScene (str); 
		 
	}
}
