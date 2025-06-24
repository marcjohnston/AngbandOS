namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportSelf10P4xTeleportSelfScript : TeleportSelfScriptGameConfiguration
{
    public override string DistanceExpression => "10+4*x";
}
