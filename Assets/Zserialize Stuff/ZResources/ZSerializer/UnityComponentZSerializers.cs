
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
namespace ZSerializer {

[System.Serializable]
public sealed class LightZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.LightType type;
    public UnityEngine.LightShape shape;
    public System.Single spotAngle;
    public System.Single innerSpotAngle;
    public UnityEngine.Color color;
    public System.Single colorTemperature;
    public System.Boolean useColorTemperature;
    public System.Single intensity;
    public System.Single bounceIntensity;
    public System.Boolean useBoundingSphereOverride;
    public UnityEngine.Vector4 boundingSphereOverride;
    public System.Boolean useViewFrustumForShadowCasterCull;
    public System.Int32 shadowCustomResolution;
    public System.Single shadowBias;
    public System.Single shadowNormalBias;
    public System.Single shadowNearPlane;
    public System.Boolean useShadowMatrixOverride;
    public UnityEngine.Matrix4x4 shadowMatrixOverride;
    public System.Single range;
    public UnityEngine.Flare flare;
    public UnityEngine.LightBakingOutput bakingOutput;
    public System.Int32 cullingMask;
    public System.Int32 renderingLayerMask;
    public UnityEngine.LightShadowCasterMode lightShadowCasterMode;
    public System.Single shadowRadius;
    public System.Single shadowAngle;
    public UnityEngine.LightShadows shadows;
    public System.Single shadowStrength;
    public UnityEngine.Rendering.LightShadowResolution shadowResolution;
    public System.Single[] layerShadowCullDistances;
    public System.Single cookieSize;
    public UnityEngine.Texture cookie;
    public UnityEngine.LightRenderMode renderMode;
    public UnityEngine.Vector2 areaSize;
    public UnityEngine.LightmapBakeType lightmapBakeType;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public LightZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Light;
        type = instance.type;
        shape = instance.shape;
        spotAngle = instance.spotAngle;
        innerSpotAngle = instance.innerSpotAngle;
        color = instance.color;
        colorTemperature = instance.colorTemperature;
        useColorTemperature = instance.useColorTemperature;
        intensity = instance.intensity;
        bounceIntensity = instance.bounceIntensity;
        useBoundingSphereOverride = instance.useBoundingSphereOverride;
        boundingSphereOverride = instance.boundingSphereOverride;
        useViewFrustumForShadowCasterCull = instance.useViewFrustumForShadowCasterCull;
        shadowCustomResolution = instance.shadowCustomResolution;
        shadowBias = instance.shadowBias;
        shadowNormalBias = instance.shadowNormalBias;
        shadowNearPlane = instance.shadowNearPlane;
        useShadowMatrixOverride = instance.useShadowMatrixOverride;
        shadowMatrixOverride = instance.shadowMatrixOverride;
        range = instance.range;
        flare = instance.flare;
        bakingOutput = instance.bakingOutput;
        cullingMask = instance.cullingMask;
        renderingLayerMask = instance.renderingLayerMask;
        lightShadowCasterMode = instance.lightShadowCasterMode;
        shadowRadius = instance.shadowRadius;
        shadowAngle = instance.shadowAngle;
        shadows = instance.shadows;
        shadowStrength = instance.shadowStrength;
        shadowResolution = instance.shadowResolution;
        layerShadowCullDistances = instance.layerShadowCullDistances;
        cookieSize = instance.cookieSize;
        cookie = instance.cookie;
        renderMode = instance.renderMode;
        areaSize = instance.areaSize;
        lightmapBakeType = instance.lightmapBakeType;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Light))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Light)component;
        instance.type = type;
        instance.shape = shape;
        instance.spotAngle = spotAngle;
        instance.innerSpotAngle = innerSpotAngle;
        instance.color = color;
        instance.colorTemperature = colorTemperature;
        instance.useColorTemperature = useColorTemperature;
        instance.intensity = intensity;
        instance.bounceIntensity = bounceIntensity;
        instance.useBoundingSphereOverride = useBoundingSphereOverride;
        instance.boundingSphereOverride = boundingSphereOverride;
        instance.useViewFrustumForShadowCasterCull = useViewFrustumForShadowCasterCull;
        instance.shadowCustomResolution = shadowCustomResolution;
        instance.shadowBias = shadowBias;
        instance.shadowNormalBias = shadowNormalBias;
        instance.shadowNearPlane = shadowNearPlane;
        instance.useShadowMatrixOverride = useShadowMatrixOverride;
        instance.shadowMatrixOverride = shadowMatrixOverride;
        instance.range = range;
        instance.flare = flare;
        instance.bakingOutput = bakingOutput;
        instance.cullingMask = cullingMask;
        instance.renderingLayerMask = renderingLayerMask;
        instance.lightShadowCasterMode = lightShadowCasterMode;
        instance.shadowRadius = shadowRadius;
        instance.shadowAngle = shadowAngle;
        instance.shadows = shadows;
        instance.shadowStrength = shadowStrength;
        instance.shadowResolution = shadowResolution;
        instance.layerShadowCullDistances = layerShadowCullDistances;
        instance.cookieSize = cookieSize;
        instance.cookie = cookie;
        instance.renderMode = renderMode;
        instance.areaSize = areaSize;
        instance.lightmapBakeType = lightmapBakeType;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Light))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshFilterZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh sharedMesh;
    public UnityEngine.HideFlags hideFlags;
    public MeshFilterZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshFilter;
        sharedMesh = instance.sharedMesh;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshFilter)component;
        instance.sharedMesh = sharedMesh;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh additionalVertexStreams;
    public UnityEngine.Mesh enlightenVertexStream;
    public System.Single scaleInLightmap;
    public UnityEngine.ReceiveGI receiveGI;
    public System.Boolean stitchLightmapSeams;
    public UnityEngine.Bounds bounds;
    public UnityEngine.Bounds localBounds;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public System.Boolean staticShadowCaster;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public MeshRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshRenderer;
        additionalVertexStreams = instance.additionalVertexStreams;
        enlightenVertexStream = instance.enlightenVertexStream;
        scaleInLightmap = instance.scaleInLightmap;
        receiveGI = instance.receiveGI;
        stitchLightmapSeams = instance.stitchLightmapSeams;
        bounds = instance.bounds;
        localBounds = instance.localBounds;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        staticShadowCaster = instance.staticShadowCaster;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshRenderer)component;
        instance.additionalVertexStreams = additionalVertexStreams;
        instance.enlightenVertexStream = enlightenVertexStream;
        instance.scaleInLightmap = scaleInLightmap;
        instance.receiveGI = receiveGI;
        instance.stitchLightmapSeams = stitchLightmapSeams;
        instance.bounds = bounds;
        instance.localBounds = localBounds;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.staticShadowCaster = staticShadowCaster;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class TransformZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 position;
    public UnityEngine.Vector3 localPosition;
    public UnityEngine.Vector3 eulerAngles;
    public UnityEngine.Vector3 localEulerAngles;
    public UnityEngine.Vector3 right;
    public UnityEngine.Vector3 up;
    public UnityEngine.Vector3 forward;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.Quaternion localRotation;
    public UnityEngine.Vector3 localScale;
    public UnityEngine.Transform parent;
    public System.Boolean hasChanged;
    public System.Int32 hierarchyCapacity;
    public UnityEngine.HideFlags hideFlags;
    public TransformZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Transform;
        position = instance.position;
        localPosition = instance.localPosition;
        eulerAngles = instance.eulerAngles;
        localEulerAngles = instance.localEulerAngles;
        right = instance.right;
        up = instance.up;
        forward = instance.forward;
        rotation = instance.rotation;
        localRotation = instance.localRotation;
        localScale = instance.localScale;
        parent = instance.parent;
        hasChanged = instance.hasChanged;
        hierarchyCapacity = instance.hierarchyCapacity;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Transform)component;
        instance.position = position;
        instance.localPosition = localPosition;
        instance.eulerAngles = eulerAngles;
        instance.localEulerAngles = localEulerAngles;
        instance.right = right;
        instance.up = up;
        instance.forward = forward;
        instance.rotation = rotation;
        instance.localRotation = localRotation;
        instance.localScale = localScale;
        instance.parent = parent;
        instance.hasChanged = hasChanged;
        instance.hierarchyCapacity = hierarchyCapacity;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class RigidbodyZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 velocity;
    public UnityEngine.Vector3 angularVelocity;
    public System.Single drag;
    public System.Single angularDrag;
    public System.Single mass;
    public System.Boolean useGravity;
    public System.Single maxDepenetrationVelocity;
    public System.Boolean isKinematic;
    public System.Boolean freezeRotation;
    public UnityEngine.RigidbodyConstraints constraints;
    public UnityEngine.CollisionDetectionMode collisionDetectionMode;
    public UnityEngine.Vector3 centerOfMass;
    public UnityEngine.Quaternion inertiaTensorRotation;
    public UnityEngine.Vector3 inertiaTensor;
    public System.Boolean detectCollisions;
    public UnityEngine.Vector3 position;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.RigidbodyInterpolation interpolation;
    public System.Int32 solverIterations;
    public System.Single sleepThreshold;
    public System.Single maxAngularVelocity;
    public System.Int32 solverVelocityIterations;
    public UnityEngine.HideFlags hideFlags;
    public RigidbodyZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Rigidbody;
        velocity = instance.velocity;
        angularVelocity = instance.angularVelocity;
        drag = instance.drag;
        angularDrag = instance.angularDrag;
        mass = instance.mass;
        useGravity = instance.useGravity;
        maxDepenetrationVelocity = instance.maxDepenetrationVelocity;
        isKinematic = instance.isKinematic;
        freezeRotation = instance.freezeRotation;
        constraints = instance.constraints;
        collisionDetectionMode = instance.collisionDetectionMode;
        centerOfMass = instance.centerOfMass;
        inertiaTensorRotation = instance.inertiaTensorRotation;
        inertiaTensor = instance.inertiaTensor;
        detectCollisions = instance.detectCollisions;
        position = instance.position;
        rotation = instance.rotation;
        interpolation = instance.interpolation;
        solverIterations = instance.solverIterations;
        sleepThreshold = instance.sleepThreshold;
        maxAngularVelocity = instance.maxAngularVelocity;
        solverVelocityIterations = instance.solverVelocityIterations;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Rigidbody)component;
        instance.velocity = velocity;
        instance.angularVelocity = angularVelocity;
        instance.drag = drag;
        instance.angularDrag = angularDrag;
        instance.mass = mass;
        instance.useGravity = useGravity;
        instance.maxDepenetrationVelocity = maxDepenetrationVelocity;
        instance.isKinematic = isKinematic;
        instance.freezeRotation = freezeRotation;
        instance.constraints = constraints;
        instance.collisionDetectionMode = collisionDetectionMode;
        instance.centerOfMass = centerOfMass;
        instance.inertiaTensorRotation = inertiaTensorRotation;
        instance.inertiaTensor = inertiaTensor;
        instance.detectCollisions = detectCollisions;
        instance.position = position;
        instance.rotation = rotation;
        instance.interpolation = interpolation;
        instance.solverIterations = solverIterations;
        instance.sleepThreshold = sleepThreshold;
        instance.maxAngularVelocity = maxAngularVelocity;
        instance.solverVelocityIterations = solverVelocityIterations;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class SphereColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 center;
    public System.Single radius;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public System.Boolean hasModifiableContacts;
    public UnityEngine.HideFlags hideFlags;
    public SphereColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.SphereCollider;
        center = instance.center;
        radius = instance.radius;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hasModifiableContacts = instance.hasModifiableContacts;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.SphereCollider)component;
        instance.center = center;
        instance.radius = radius;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hasModifiableContacts = hasModifiableContacts;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class HingeJoint2DZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Boolean useMotor;
    public System.Boolean useLimits;
    public UnityEngine.JointMotor2D motor;
    public UnityEngine.JointAngleLimits2D limits;
    public UnityEngine.Vector2 anchor;
    public UnityEngine.Vector2 connectedAnchor;
    public System.Boolean autoConfigureConnectedAnchor;
    public UnityEngine.Rigidbody2D connectedBody;
    public System.Boolean enableCollision;
    public System.Single breakForce;
    public System.Single breakTorque;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public Vector2 serializableLimits;
    public Vector2 serializableMotor;
    public HingeJoint2DZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.HingeJoint2D;
        useMotor = instance.useMotor;
        useLimits = instance.useLimits;
        motor = instance.motor;
        limits = instance.limits;
        anchor = instance.anchor;
        connectedAnchor = instance.connectedAnchor;
        autoConfigureConnectedAnchor = instance.autoConfigureConnectedAnchor;
        connectedBody = instance.connectedBody;
        enableCollision = instance.enableCollision;
        breakForce = instance.breakForce;
        breakTorque = instance.breakTorque;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.HingeJoint2D)component;
        instance.useMotor = useMotor;
        instance.useLimits = useLimits;
        instance.motor = motor;
        instance.limits = limits;
        instance.anchor = anchor;
        instance.connectedAnchor = connectedAnchor;
        instance.autoConfigureConnectedAnchor = autoConfigureConnectedAnchor;
        instance.connectedBody = connectedBody;
        instance.enableCollision = enableCollision;
        instance.breakForce = breakForce;
        instance.breakTorque = breakTorque;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnDeserialize?.Invoke(this, instance);
    }
}
}