using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace DCInputManager{
	public partial class InputManager : MonoBehaviour{

		[SerializeField]
		public List<InputKey> _InputKeys;
		private ForgottenOnes.GameController _GameController;
		public bool AllowDuplicates = false; //Allow duplicate input keys?
		[HideInInspector]
		public bool Scanning = false;  //Are we currently scanning for user input?
		
		void Start (){
			_GameController = GameObject.FindGameObjectWithTag("Input Manager").GetComponent<ForgottenOnes.GameController>();
			//LoadKeys();
			if(_InputKeys == null){
				SetDefaults();
			}
		}

		#region Check Inputs
		public bool GetButtonUp(string nam){
			InputKey key = (InputKey)_InputKeys.First(st => st.Name == nam);
			
			if(key.UseModifier){
				if(Input.GetKeyUp(key.PrimaryKey)&&Input.GetKeyUp(key.PrimaryModifier)){
					return true;
				}

				if(Input.GetKeyUp(key.SecondaryKey)&&Input.GetKeyUp(key.SecondaryModifier)){
					return true;
				}
			}else{
				if(Input.GetKeyUp(key.PrimaryKey)){
					return true;
				}
				
				if(Input.GetKeyUp(key.SecondaryKey)){
					return true;
				}
				
			}
			return false;
		}

		public bool GetButtonDown(string nam){
			InputKey key = (InputKey)_InputKeys.First(st => st.Name == nam);
			
			if(key.UseModifier){
				if(Input.GetKeyDown(key.PrimaryKey)&&Input.GetKeyDown(key.PrimaryModifier)){
					return true;
				}

				if(Input.GetKeyDown(key.SecondaryKey)&&Input.GetKeyDown(key.SecondaryModifier)){
					return true;
				}	
			}else{
				if(Input.GetKeyDown(key.PrimaryKey)){
					return true;
				}
				if(Input.GetKeyDown(key.SecondaryKey)){
					return true;
				}
			}
			return false;
		}

		public bool GetButton(string nam){
			//InputKey key =
			InputKey key = (InputKey)_InputKeys.FirstOrDefault(st => st.Name == nam);
			
			if(key.UseModifier){
				if(Input.GetKey(key.PrimaryKey)&&Input.GetKey(key.PrimaryModifier)){
					return true;
				}

				if(Input.GetKey(key.SecondaryKey)&&Input.GetKey(key.SecondaryModifier)){
					return true;
				}
				
			}else{
				if(Input.GetKey(key.PrimaryKey)){
					return true;
				}

				if(Input.GetKey(key.SecondaryKey)){
					return true;
				}
			}
			return false;
		}
		#endregion

		public List<InputKey> InputKeys{
			get{return _InputKeys;}
		}

		public int Length{
			get{return _InputKeys.Count;}
		}
	}
}