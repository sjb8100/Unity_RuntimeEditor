using System.Collections.Generic;
using ProtoBuf;
using Battlehub.RTSaveLoad2;
using UnityEngine;
using UnityEngine.Battlehub.SL2;

using UnityObject = UnityEngine.Object;
namespace UnityEngine.Battlehub.SL2
{
    [ProtoContract(AsReferenceDefault = true)]
    public partial class PersistentBounds : PersistentSurrogate
    {
        [ProtoMember(256)]
        public Vector3 center;

        [ProtoMember(258)]
        public Vector3 extents;

        protected override void ReadFromImpl(object obj)
        {
            base.ReadFromImpl(obj);
            Bounds uo = (Bounds)obj;
            center = uo.center;
            extents = uo.extents;
        }

        protected override object WriteToImpl(object obj)
        {
            obj = base.WriteToImpl(obj);
            Bounds uo = (Bounds)obj;
            uo.center = center;
            uo.extents = extents;
            return uo;
        }

        public static implicit operator Bounds(PersistentBounds surrogate)
        {
            return (Bounds)surrogate.WriteTo(new Bounds());
        }
        
        public static implicit operator PersistentBounds(Bounds obj)
        {
            PersistentBounds surrogate = new PersistentBounds();
            surrogate.ReadFrom(obj);
            return surrogate;
        }
    }
}

