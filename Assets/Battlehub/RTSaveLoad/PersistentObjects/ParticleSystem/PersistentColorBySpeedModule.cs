#define RT_USE_PROTOBUF
#if RT_USE_PROTOBUF
using ProtoBuf;
#endif
/*This is auto-generated file. Tools->Runtime SaveLoad->Create Persistent Objects 
If you want prevent overwriting, drag this file to another folder.*/

namespace Battlehub.RTSaveLoad.PersistentObjects
{
	#if RT_USE_PROTOBUF
	[ProtoContract(AsReferenceDefault = true, ImplicitFields = ImplicitFields.AllFields)]
	#endif
	[System.Serializable]
	public class PersistentColorBySpeedModule : Battlehub.RTSaveLoad.PersistentData
	{
		public override object WriteTo(object obj, System.Collections.Generic.Dictionary<long, UnityEngine.Object> objects)
		{
			obj = base.WriteTo(obj, objects);
			if(obj == null)
			{
				return null;
			}
			UnityEngine.ParticleSystem.ColorBySpeedModule o = (UnityEngine.ParticleSystem.ColorBySpeedModule)obj;
			o.enabled = enabled;
			o.color = Write(o.color, color, objects);
			o.range = range;
			return o;
		}

		public override void ReadFrom(object obj)
		{
			base.ReadFrom(obj);
			if(obj == null)
			{
				return;
			}
			UnityEngine.ParticleSystem.ColorBySpeedModule o = (UnityEngine.ParticleSystem.ColorBySpeedModule)obj;
			enabled = o.enabled;
			color = Read(color, o.color);
			range = o.range;
		}

		public override void FindDependencies<T>(System.Collections.Generic.Dictionary<long, T> dependencies, System.Collections.Generic.Dictionary<long, T> objects, bool allowNulls)
		{
			base.FindDependencies(dependencies, objects, allowNulls);
			FindDependencies(color, dependencies, objects, allowNulls);
		}

		protected override void GetDependencies(System.Collections.Generic.Dictionary<long, UnityEngine.Object> dependencies, object obj)
		{
			base.GetDependencies(dependencies, obj);
			if(obj == null)
			{
				return;
			}
			UnityEngine.ParticleSystem.ColorBySpeedModule o = (UnityEngine.ParticleSystem.ColorBySpeedModule)obj;
			GetDependencies(color, o.color, dependencies);
		}

		public bool enabled;

		public Battlehub.RTSaveLoad.PersistentObjects.PersistentMinMaxGradient color;

		public UnityEngine.Vector2 range;

	}
}
