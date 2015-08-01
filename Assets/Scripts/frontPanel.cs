using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_STANDALONE_WIN
using System.Runtime.InteropServices;
#endif
public class frontPanel : MonoBehaviour {
#if UNITY_STANDALONE_WIN
	[DllImport("user32.dll")]
	private static extern void OpenFileDialog();
#endif
	public static int level;
	string path;
	string userName;
	InputField pathBox;
	InputField nameBox;
	Slider levelBar;
#if UNITY_ANDROID
	AndroidJavaClass browseClass;
#endif
	// Use this for initialization
	void Start () {
#if UNITY_ANDROID
		AndroidJNI.AttachCurrentThread();
		browseClass = new AndroidJavaClass("com.IITB_CDEEP.JigsawAndroid.Browse");
#endif
		level = 2;
		userName = "";
		path = "";
		levelBar = GameObject.Find ("Level").GetComponent<Slider> ();
		nameBox = GameObject.Find ("Name").GetComponent<InputField> ();
		pathBox = GameObject.Find ("Path").GetComponent<InputField>();
		string[] settings = new string[1];
		try{
			settings = System.IO.File.ReadAllLines(Application.persistentDataPath+"/Settings.txt");
			pathBox.text = path = settings[1];
			nameBox.text = userName = settings[0];
			levelBar.value = level = int.Parse(settings[2]);
		}catch{
			pathBox.text = Application.persistentDataPath;
			print ("File not found");
		}
	}
	public void onClickCancel(){
		if(userName!="" && path!=""){
			Application.LoadLevel("splash");
		}
	}
	public void proceed(){
		if (nameBox.text!="" && pathBox.text!="") {
			level = (int)levelBar.value;
			userName = nameBox.text;
			path = pathBox.text;
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.persistentDataPath+"/Settings.txt"))
			{
				file.WriteLine(userName);
				file.WriteLine(path);
				file.WriteLine(level.ToString());
				file.Close();
			}
			Application.LoadLevel("splash");
		}
	}
	public void browseImage(){

#if UNITY_EDITOR		
		path = EditorUtility.OpenFilePanel("Select Image", "", "jpg");
		pathBox.text = path;
#endif

#if UNITY_ANDROID
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
		currentActivity.Call("selectImage");
#endif

#if UNITY_STANDALONE_WIN
		System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
		ofd.InitialDirectory = Application.persistentDataPath;
		ofd.Filter =  "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
		if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK){
			path = ofd.FileName;
			pathBox.text = path;
		}
#endif
	}

	public void updatePathBox(string resultPath){
		path = resultPath;
		pathBox.text = resultPath;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
