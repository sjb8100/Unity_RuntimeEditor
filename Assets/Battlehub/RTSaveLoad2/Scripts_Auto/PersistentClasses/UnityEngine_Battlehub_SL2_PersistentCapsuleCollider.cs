using System.Collections.Generic;
using ProtoBuf;
using Battlehub.RTSaveLoad2;
using UnityEngine;
using UnityEngine.Battlehub.SL2;
using System;

using UnityObject = UnityEngine.Object;
namespace UnityEngine.Battlehub.SL2
{
    [ProtoContract(AsReferenceDefault = true)]
    public partial class PersistentCapsuleCollider : PersistentCollider
    {
        [ProtoMember(256)]
        public Vector3 center;

        [ProtoMember(257)]
        public float radius;

        [ProtoMember(258)]
        public float height;

        [ProtoMember(259)]
        public int direction;

        protected override void ReadFromImpl(object obj)
        {
            base.ReadFromImpl(obj);
            CapsuleCollider uo = (CapsuleCollider)obj;
            center = uo.center;
            radius = uo.radius;
            height = uo.height;
            direction = uo.direction;
        }

        protected override object WriteToImpl(object obj)
        {
            obj = base.WriteToImpl(obj);
            CapsuleCollider uo = (CapsuleCollider)obj;
            uo.center = center;
            uo.radius = radius;
            uo.height = height;
            uo.direction = direction;
            return uo;
        }

        public static implicit operator CapsuleCollider(PersistentCapsuleCollider surrogate)
        {
            return (CapsuleCollider)surrogate.WriteTo(new CapsuleCollider());
        }
        
        public static implicit operator PersistentCapsuleCollider(CapsuleCollider obj)
        {
            PersistentCapsuleCollider surrogate = new PersistentCapsuleCollider();
            surrogate.ReadFrom(obj);
            return surrogate;
        }
    }
}

