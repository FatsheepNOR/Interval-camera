using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class WebCamPhotoCamera : MonoBehaviour 
{
	WebCamTexture webCamTexture;

	public static string ScreenShotName() {
		return string.Format ("{0}/IntervalPhotos/Photo_{1}.png", 
		                     Application.dataPath, 
		                     System.DateTime.Now.ToString ("yyyy-MM-dd_HH-mm-ss"));
	}
	public static string ScreenShotDir() {
		return string.Format ("{0}/IntervalPhotos/", Application.dataPath);
	}
	
	void Start() 
	{
		Directory.CreateDirectory (ScreenShotDir());
		webCamTexture = new WebCamTexture();
		Image.defaultGraphicMaterial.mainTexture = webCamTexture;
		webCamTexture.Play();
	}

	public void Snap()
	{
		StartCoroutine (TakePhoto ());
	}
	
	IEnumerator TakePhoto()
	{
		
		// NOTE - you almost certainly have to do this here:
		
		yield return new WaitForEndOfFrame(); 
		
		// it's a rare case where the Unity doco is pretty clear,
		// http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
		// be sure to scroll down to the SECOND long example on that doco page 
		
		Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
		photo.SetPixels(webCamTexture.GetPixels());
		photo.Apply();
		
		//Encode to a PNG
		byte[] bytes = photo.EncodeToPNG();

		//Write out the PNG. Of course you have to substitute your_path for something sensible
		File.WriteAllBytes(ScreenShotName(), bytes);
	}
}