using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Controllers{
	[Serializable]
	public class Pool{
		public string Name;
		public GameObject Object;
		public int Count;
		private Queue<GameObject> Active = new Queue<GameObject>();
		private Queue<GameObject> InActive = new Queue<GameObject>();
		[HideInInspector]
		public bool Inited=false;
		
		public void Init(){
			for(int i=0; i<Count; i++){
				GameObject temp;
				temp=MonoBehaviour.Instantiate(Object) as GameObject;
				temp.SetActive(false);
				InActive.Enqueue(temp);
			}
		}
		
		public GameObject Instantiate(Vector3 position, Quaternion rotation){
			GameObject go=null;
			try{
				go = InActive.Dequeue();
			}catch(InvalidOperationException){
				Debug.LogError("Not enough objects in pool "+Name+" to instantiate. \n Consider raising the pool count!");
				go = null;
				return null;
			}
			Active.Enqueue(go);
			go.SetActive(true);
			go.transform.position=position;
			go.transform.rotation=rotation;
			return go;
		}
		
		public void Destroy(GameObject go){
			go.SetActive(false);
			Active.Dequeue();
			InActive.Enqueue(go);
		}
		
		public void Empty(){
			for(int i=0; i<Active.Count;i++){
				Destroy(Active.Dequeue());
			}
			for(int x=0; x<InActive.Count;x++){
				Destroy(InActive.Dequeue());
			}
		}
		
		public int ActiveObjects{
			get{return Active.Count;}
		}
		
		public int InActiveObjects{
			get{return InActive.Count;}
		}
	}
}