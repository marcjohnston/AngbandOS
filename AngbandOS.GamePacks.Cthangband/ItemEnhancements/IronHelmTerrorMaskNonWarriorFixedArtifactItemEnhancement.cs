namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmTerrorMaskNonWarriorFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HeavyCurse => true;
    public override bool Aggravate => true;
    public override bool DreadCurse => true;
    public override bool Valueless => true;
    public override int Value => -42500;
}
