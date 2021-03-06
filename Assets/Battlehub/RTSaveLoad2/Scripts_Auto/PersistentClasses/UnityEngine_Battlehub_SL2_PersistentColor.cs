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
    public partial class PersistentColor : PersistentSurrogate
    {
        [ProtoMember(256)]
        public float r;

        [ProtoMember(257)]
        public float g;

        [ProtoMember(258)]
        public float b;

        [ProtoMember(259)]
        public float a;

        protected override void ReadFromImpl(object obj)
        {
            base.ReadFromImpl(obj);
            Color uo = (Color)obj;
            r = uo.r;
            g = uo.g;
            b = uo.b;
            a = uo.a;
        }

        protected override object WriteToImpl(object obj)
        {
            obj = base.WriteToImpl(obj);
            Color uo = (Color)obj;
            uo.r = r;
            uo.g = g;
            uo.b = b;
            uo.a = a;
            return uo;
        }

        public static implicit operator Color(PersistentColor surrogate)
        {
            return (Color)surrogate.WriteTo(new Color());
        }
        
        public static implicit operator PersistentColor(Color obj)
        {
            PersistentColor surrogate = new PersistentColor();
            surrogate.ReadFrom(obj);
            return surrogate;
        }
    }
}

