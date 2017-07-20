using UnityEngine;
using System;

namespace DCInputManager{
	[Serializable]
	public class InputKey{
		public string Name;
		public KeyCode PrimaryKey;
		public KeyCode SecondaryKey;
		public bool UseModifier;
		public KeyCode PrimaryModifier;
		public KeyCode SecondaryModifier;
		
		public InputKey(string name, KeyCode primary, KeyCode secondary, bool usemodifier, KeyCode primarym, KeyCode secondarym){
			Name=name; 
			PrimaryKey=primary;
			SecondaryKey=secondary;
			UseModifier=usemodifier;
			PrimaryModifier=primarym;
			SecondaryModifier=secondarym;
		}

		public InputKey(string name, KeyCode primary, KeyCode secondary){
			Name=name;
			PrimaryKey=primary;
			SecondaryKey=secondary;
			UseModifier=false;
		}

		public InputKey(string name, string primary, string secondary, bool usemodifier, string primarym, string secondarym){
			Name=name;
			PrimaryKey=(KeyCode)Enum.Parse(typeof(KeyCode),primary);
			SecondaryKey=(KeyCode)Enum.Parse(typeof(KeyCode),secondary);
			UseModifier=usemodifier;
			PrimaryModifier=(KeyCode)Enum.Parse(typeof(KeyCode),primarym);
			SecondaryModifier=(KeyCode)Enum.Parse(typeof(KeyCode),secondarym);
		}
		
		public InputKey(string name, string primary, string secondary){
			Name=name;
			PrimaryKey=(KeyCode)Enum.Parse(typeof(KeyCode),primary);
			SecondaryKey=(KeyCode)Enum.Parse(typeof(KeyCode),secondary);
			UseModifier=false;
		}
	}
}