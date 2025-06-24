namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportSelf5xTeleportSelfScript : TeleportSelfScriptGameConfiguration
{
    public override string DistanceExpression => "5*x";
}
