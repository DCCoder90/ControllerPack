using UnityEngine;
using System.Collections;
namespace Controllers{
	public class AudioController : MonoBehaviour
	{
		[SerializeField]
		private Audio[] Audio;
		private AudioSource source;

		//Adds new audio clip to array
		public void AddAudio(string name, AudioClip clip){
			int newlength = Audio.Length+1;
			System.Array.Resize(ref Audio,newlength);
			Audio[newlength-1]=new Controllers.Audio(name,clip);
		}
		
		public void AddAudio(string name, AudioClip clip, bool flat){
			int newlength = Audio.Length+1;
			System.Array.Resize(ref Audio,newlength);
			Audio[newlength-1]=new Controllers.Audio(name,clip,flat);
		}


		public void PlaySound(GameObject target, string name){
			source = target.GetComponent<AudioSource>();
			Audio audio = null;
			foreach(Audio audioclip in Audio){
				if(audioclip.Name==name){
					audio=audioclip;
					break;
				}
			}

			if(audio==null){
				Debug.LogWarning("No audio clip by the name of "+name+" has been defined in the audio controller!");
				return;
			}
			if(audio.Flat){
				source.panLevel=0f;
			}else{
				source.panLevel=1f;
			}
			source.clip=audio.Clip;
			source.Play();
		}

		public void PlaySound(GameObject target, string name, float pitch, float volume){
			source = target.GetComponent<AudioSource>();
			Audio audio = null;
			foreach(Audio audioclip in Audio){
				if(audioclip.Name==name){
					audio=audioclip;
					break;
				}
			}
			
			if(audio==null){
				Debug.LogWarning("No audio clip by the name of "+name+" has been defined in the audio controller!");
				return;
			}
			
			source.clip=audio.Clip;
			float p=source.pitch;
			float v=source.volume;
			source.pitch=pitch;
			source.volume=volume;
			source.Play();
			source.pitch=p;
			source.volume=v;
		}
	}
}