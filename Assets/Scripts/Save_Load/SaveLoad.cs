using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
public class SaveLoad  {


	public static savedClass savedValue;
	public static List<saveLevel> list_level_save = new List<saveLevel>();
	public static saveLevel this_level_value = new saveLevel();
	public SaveLoad(){

	}
	public  void saveFile()
	{
		#if UNITY_IPHONE
		iPhone.SetNoBackupFlag (filePath);
		#endif
		if (File.Exists (Application.persistentDataPath + "/savedGames.txt")) 
		{
			File.Delete(Application.persistentDataPath + "/savedGames.txt");
		}
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/savedGames.txt");
			bf.Serialize (file, savedValue);
			file.Close ();

	}
	public void loadFile(){
		#if UNITY_IPHONE
		iPhone.SetNoBackupFlag (filePath);
		#endif


		if(File.Exists(Application.persistentDataPath + "/savedGames.txt")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.txt", FileMode.Open);
			savedValue = bf.Deserialize(file) as savedClass;
			file.Close();
		}

	}
	public  void setvalue(int lev, int total_s, int level_t, int level_m, int level_ta, int level_l, int level_ma,string level_b, string list_d)
	{
		savedValue = new savedClass ();
		savedValue.level = lev;
		savedValue.total_score = total_s;
		savedValue.level_TV = level_t;
		savedValue.level_manocan = level_m;
		savedValue.level_table = level_ta;
		savedValue.level_bep = level_b;
		savedValue.level_lo = level_l;
		savedValue.level_may = level_ma;
		savedValue.list_disk_open = list_d;
	
	}
	public void save_level()
	{
		#if UNITY_IPHONE
		iPhone.SetNoBackupFlag (filePath);
		#endif

		if (list_level_save.Count > 0) {
			if (menuButtons.maxLv < this_level_value.level) {

				list_level_save.Add (this_level_value);
			} else {
				int indexThis = list_level_save.FindIndex (s => s.level == this_level_value.level);
				if(list_level_save [indexThis].money<this_level_value.money)
				{
				list_level_save [indexThis] = this_level_value;
				}
			}
		}
		else {
			list_level_save.Add (this_level_value);
		}
		if (File.Exists (Application.persistentDataPath + "/savedLevel.txt")) 
		{
			File.Delete(Application.persistentDataPath + "/savedLevel.txt");
		}
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/savedLevel.txt");
		bf.Serialize (file, list_level_save);
		file.Close ();
	}
	public void loadFileLevel(){
		#if UNITY_IPHONE
		iPhone.SetNoBackupFlag (filePath);
		#endif
		
		
		if(File.Exists(Application.persistentDataPath + "/savedLevel.txt")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedLevel.txt", FileMode.Open);
			list_level_save = bf.Deserialize(file) as List<saveLevel>;
			file.Close();
		}
		
	}
}
