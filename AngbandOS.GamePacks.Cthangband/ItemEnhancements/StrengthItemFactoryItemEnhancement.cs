namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StrengthItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool HideType => true;
    public override bool Str => true; // TODO: The bonus value is controlled by a script
}