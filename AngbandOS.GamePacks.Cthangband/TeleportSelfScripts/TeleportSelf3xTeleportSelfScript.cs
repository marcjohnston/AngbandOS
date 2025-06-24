namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportSelf3xTeleportSelfScript : TeleportSelfScriptGameConfiguration
{
    public override string DistanceExpression => "3*x";
}
