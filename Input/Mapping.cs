using UnityEngine;
using System.Linq;
using System;

namespace DCInputManager{
	public partial class InputManager{

		//Returns whether or not a key is defined
		public bool KeyDefined(string name){
			if(!_InputKeys.All(st => st.Name == name)){
				return false;
			}
			return true;
		}
		
		//Removes a modifier from all key
		public void RemoveModifier(KeyCode input){
			InputKey key = (InputKey) _InputKeys.Where(st => st.PrimaryModifier == input || st.SecondaryModifier == input);
			if(key==null){
				return;
			}
			
			_InputKeys.Remove(key);
			_InputKeys.Add(new InputKey(key.Name,key.PrimaryKey,key.SecondaryKey));
			
		}

		#region InputUsed
		//Check if a specified input is being used for a key
		public bool InputUsed(KeyCode input){
			if(_InputKeys.All(st => st.PrimaryKey == input || st.SecondaryKey == input 
			                  || st.PrimaryModifier == input || st.SecondaryModifier == input)){
				return true;
			}
			return false;
		}
		
		//Check if a specified input is being used for a key
		public bool InputUsed(string input){
			KeyCode inputcode = (KeyCode)Enum.Parse(typeof(KeyCode),input);
			if(_InputKeys.All(st => st.PrimaryKey == inputcode || st.SecondaryKey == inputcode
			                  || st.PrimaryModifier == inputcode || st.SecondaryModifier == inputcode)){
				return true;
			}
			return false;
		}
		#endregion
		//Unmaps a key based on it's name
		public void UnMapKey(string name){
			InputKey key = (InputKey)_InputKeys.Where(st => st.Name == name);
			_InputKeys.Remove(key);
		}
		
		#region MapKey
		public void MapKey(string name, KeyCode primary, KeyCode secondary, bool usemodifier, KeyCode primarym, KeyCode secondarym){
			if(InputUsed(primary)||InputUsed(secondary)||InputUsed(primarym)||InputUsed(secondarym)){
				if(!AllowDuplicates){
					Debug.LogError("Trying to define already defined input!");
					return;
				}
			}
			InputKey key = new InputKey(name,primary,secondary,usemodifier,primarym,secondarym);
			_InputKeys.Add(key);
		}
		
		public void MapKey(string name, string primary, string secondary, bool usemodifier, string primarym, string secondarym){
			if(InputUsed(primary)||InputUsed(secondary)||InputUsed(primarym)||InputUsed(secondarym)){
				if(!AllowDuplicates){
					Debug.LogError("Trying to define already defined input!");
					return;
				}
			}
			InputKey key = new InputKey(name,primary,secondary,usemodifier,primarym,secondarym);
			_InputKeys.Add(key);
		}
		
		public void MapKey(string name, string primary, string secondary){
			if(InputUsed(primary)||InputUsed(secondary)){
				if(!AllowDuplicates){
					Debug.LogError("Trying to define already defined input!");
					return;
				}
			}
			InputKey key = new InputKey(name,primary,secondary);
			_InputKeys.Add(key);
		}
		
		public void MapKey(string name, KeyCode primary, KeyCode secondary){
			if(InputUsed(primary)||InputUsed(secondary)){
				if(!AllowDuplicates){
					Debug.LogError("Trying to define already defined input!");
					return;
				}
			}
			InputKey key = new InputKey(name,primary,secondary);
			_InputKeys.Add(key);
		}
		#endregion

		#region ChangeKey
		public void ChangeKey(string name, KeyCode primary, KeyCode secondary){
			InputKey oldkey = (InputKey)_InputKeys.Where(st => st.Name == name);
			if(oldkey==null){
				Debug.LogError("Key '"+name+"' not found!");
				return;
			}
			_InputKeys.Remove(oldkey);
			if(InputUsed(primary)||InputUsed(secondary)){
				if(!AllowDuplicates){
					Debug.LogError("Trying to define already defined input!");
					return;
				}
			}
			InputKey key = new InputKey(name,primary,secondary);
			_InputKeys.Add(key);
		}

		public void ChangeKey(string name, KeyCode primary, KeyCode secondary, bool usemodifier, KeyCode primarym, KeyCode secondarym){
			InputKey oldkey = (InputKey)_InputKeys.Where(st => st.Name == name);
			if(oldkey==null){
				Debug.LogError("Key '"+name+"' not found!");
				return;
			}
			_InputKeys.Remove(oldkey);
			if(InputUsed(primary)||InputUsed(secondary)||InputUsed(primarym)||InputUsed(secondarym)){
				if(!AllowDuplicates){
					Debug.LogError("Trying to define already defined input!");
					return;
				}
			}
			InputKey key = new InputKey(name,primary,secondary,usemodifier,primarym,secondarym);
			_InputKeys.Add(key);
		}
		#endregion
	}
}