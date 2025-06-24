namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportSelf4xTeleportSelfScript : TeleportSelfScriptGameConfiguration
{
    public override string DistanceExpression => "4*x";
}
