using UnityEngine;
using System;
namespace Controllers{
	[Serializable]
	public class Audio{
		public string Name;
		public AudioClip Clip;
		public bool Flat=false;

		public Audio(string n, AudioClip c){
			Name=n;
			Clip=c;
			Flat=false;
		}

		public Audio(string n, AudioClip c,bool flat){
			Name=n;
			Clip=c;
			Flat=flat;
		}
	}
}