using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Controllers{
	[Serializable]
	public class PoolManager : MonoBehaviour {

		private static GameObject _instance;
		public List<Pool> Pools;
		private bool InitPools=false;
		
		public void Update(){
			if(!InitPools){
				for(int i=0; i<Pools.Count; i++){
					if(!Pools[i].Inited){
						Pools[i].Init();
						Pools[i].Inited=true;
					}
				}
				InitPools=true;
			}
		}
		
		public void Create(string name){
			Pool pool = new Pool();
			pool.Name=name;
			Pools.Add(pool);
		}
		
		public void Activate(string name){
			//Pool pool = Get(name);
			
		}
		
		public void Delete(string name){
			Pool pool = Pools.FirstOrDefault(st => st.Name == name);
			Pools.Remove(pool);
		}
		
		public Pool Get(string name){
			Pool pool = Pools.FirstOrDefault(st => st.Name == name);
			return pool;
		}
		
		public GameObject Instantiate(string name, Vector3 pos, Quaternion rot){
			Pool pool = Get(name);
			return pool.Instantiate(pos,rot);	
		}
		
		public GameObject Instantiate(string name){
			Pool pool = Get(name);
			return pool.Instantiate(Vector3.zero,Quaternion.Euler(Vector3.zero));	
		}
		
		public void Destroy(string name,GameObject go){
			Pool pool = Get(name);
			pool.Destroy(go);
		}
		
		public void Destroy(string name, GameObject go, float time){
			Pool pool = Get(name);
			StartCoroutine(Dest(pool,go,time));
		}
		
		private IEnumerator Dest(Pool pool,GameObject go,float time){		
			if(time>0){
				yield return new WaitForSeconds(time);
				time=0f;
			}
			pool.Destroy(go);
			
			yield return true;
		}

		public static PoolManager Instance{
			get{
				if(_instance){
					return _instance.GetComponent<PoolManager>();
				}else{
					GameObject temp = GameObject.Find("Pool Manager");
					if(temp){
						_instance=temp;
						return _instance.GetComponent<PoolManager>();
					}else{
						_instance=new GameObject();
						_instance.name="Pool Manager";
						_instance.AddComponent<PoolManager>();
						return _instance.GetComponent<PoolManager>();
					}
				}
			}
		}
	}
}