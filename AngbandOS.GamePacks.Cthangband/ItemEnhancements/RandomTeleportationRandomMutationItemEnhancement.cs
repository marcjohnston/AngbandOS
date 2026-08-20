namespace AngbandOS.GamePacks.Cthangband;
    public class RandomTeleportationRandomMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string[] ScriptNames)[]? ScriptsAttributeAndScriptBindings => new (string AttributeName, string[] ScriptNames)[]
    {
        (nameof(ProcessWorldScriptsAttribute), new string[] { nameof(SystemScriptsEnum.RandomTeleportationRandomMutationScript) })
    };
}