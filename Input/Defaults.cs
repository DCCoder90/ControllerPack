using UnityEngine;
using System.Collections.Generic;

namespace DCInputManager{
	public partial class InputManager : MonoBehaviour{
				
		public void LoadKeys(){
			_InputKeys=(List<InputKey>)_GameController.Load<object>("InputKeys",DGSave.LSTypes.Object);
			
		}
		
		public void SaveKeys(){
			_GameController.Save("InputKeys",_InputKeys,DGSave.LSTypes.Object);
		}
		
		public void SetDefaults(){
			
		}
	}
}