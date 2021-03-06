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
    public partial class PersistentRigidbody : PersistentComponent
    {
        [ProtoMember(256)]
        public Vector3 velocity;

        [ProtoMember(257)]
        public Vector3 angularVelocity;

        [ProtoMember(258)]
        public float drag;

        [ProtoMember(259)]
        public float angularDrag;

        [ProtoMember(260)]
        public float mass;

        [ProtoMember(261)]
        public bool useGravity;

        [ProtoMember(262)]
        public float maxDepenetrationVelocity;

        [ProtoMember(263)]
        public bool isKinematic;

        [ProtoMember(264)]
        public bool freezeRotation;

        [ProtoMember(265)]
        public RigidbodyConstraints constraints;

        [ProtoMember(266)]
        public CollisionDetectionMode collisionDetectionMode;

        [ProtoMember(267)]
        public Vector3 centerOfMass;

        [ProtoMember(268)]
        public Quaternion inertiaTensorRotation;

        [ProtoMember(269)]
        public Vector3 inertiaTensor;

        [ProtoMember(270)]
        public bool detectCollisions;

        [ProtoMember(271)]
        public Vector3 position;

        [ProtoMember(272)]
        public Quaternion rotation;

        [ProtoMember(273)]
        public RigidbodyInterpolation interpolation;

        [ProtoMember(274)]
        public int solverIterations;

        [ProtoMember(275)]
        public float sleepThreshold;

        [ProtoMember(276)]
        public float maxAngularVelocity;

        [ProtoMember(277)]
        public int solverVelocityIterations;

        protected override void ReadFromImpl(object obj)
        {
            base.ReadFromImpl(obj);
            Rigidbody uo = (Rigidbody)obj;
            velocity = uo.velocity;
            angularVelocity = uo.angularVelocity;
            drag = uo.drag;
            angularDrag = uo.angularDrag;
            mass = uo.mass;
            useGravity = uo.useGravity;
            maxDepenetrationVelocity = uo.maxDepenetrationVelocity;
            isKinematic = uo.isKinematic;
            freezeRotation = uo.freezeRotation;
            constraints = uo.constraints;
            collisionDetectionMode = uo.collisionDetectionMode;
            centerOfMass = uo.centerOfMass;
            inertiaTensorRotation = uo.inertiaTensorRotation;
            inertiaTensor = uo.inertiaTensor;
            detectCollisions = uo.detectCollisions;
            position = uo.position;
            rotation = uo.rotation;
            interpolation = uo.interpolation;
            solverIterations = uo.solverIterations;
            sleepThreshold = uo.sleepThreshold;
            maxAngularVelocity = uo.maxAngularVelocity;
            solverVelocityIterations = uo.solverVelocityIterations;
        }

        protected override object WriteToImpl(object obj)
        {
            obj = base.WriteToImpl(obj);
            Rigidbody uo = (Rigidbody)obj;
            uo.velocity = velocity;
            uo.angularVelocity = angularVelocity;
            uo.drag = drag;
            uo.angularDrag = angularDrag;
            uo.mass = mass;
            uo.useGravity = useGravity;
            uo.maxDepenetrationVelocity = maxDepenetrationVelocity;
            uo.isKinematic = isKinematic;
            uo.freezeRotation = freezeRotation;
            uo.constraints = constraints;
            uo.collisionDetectionMode = collisionDetectionMode;
            uo.centerOfMass = centerOfMass;
            uo.inertiaTensorRotation = inertiaTensorRotation;
            uo.inertiaTensor = inertiaTensor;
            uo.detectCollisions = detectCollisions;
            uo.position = position;
            uo.rotation = rotation;
            uo.interpolation = interpolation;
            uo.solverIterations = solverIterations;
            uo.sleepThreshold = sleepThreshold;
            uo.maxAngularVelocity = maxAngularVelocity;
            uo.solverVelocityIterations = solverVelocityIterations;
            return uo;
        }

        public static implicit operator Rigidbody(PersistentRigidbody surrogate)
        {
            return (Rigidbody)surrogate.WriteTo(new Rigidbody());
        }
        
        public static implicit operator PersistentRigidbody(Rigidbody obj)
        {
            PersistentRigidbody surrogate = new PersistentRigidbody();
            surrogate.ReadFrom(obj);
            return surrogate;
        }
    }
}

