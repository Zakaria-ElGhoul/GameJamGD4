using System.Reflection;
using UnityEngine;
using ZSerializer;

public partial class GaneManager : GlobalObject
{
    private static GaneManager _instance;
    public static GaneManager Instance => _instance ??= Get<GaneManager>();
    
    public static void Save() => ZSerialize.SaveGlobal(Instance);
    public static void Load() => ZSerialize.LoadGlobal(Instance);
}
