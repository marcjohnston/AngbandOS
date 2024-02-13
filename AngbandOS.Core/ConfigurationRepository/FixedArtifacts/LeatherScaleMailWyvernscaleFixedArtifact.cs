// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LeatherScaleMailWyvernscaleFixedArtifact : FixedArtifact
{
    private LeatherScaleMailWyvernscaleFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(LeatherScaleMailSoftArmorItemFactory);

    public override void ApplyResistances(Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.DieRoll(22) + 16);
    }

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Leather Scale Mail 'Wyvernscale'";
    public override int Ac => 11;
    public override int Cost => 25000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override string FriendlyName => "'Wyvernscale'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 3;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResShards => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => -1;
    public override int Weight => 60;
}
