// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfHardLeatherBootsOfIthaquaFixedArtifact : FixedArtifact
{
    private PairOfHardLeatherBootsOfIthaquaFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(HardLeatherBootsArmorItemFactory);

    // Boots haste you
    protected override string? ActivationName => nameof(Speed20p1d20Every200Activation);

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Pair of Hard Leather Boots of Ithaqua";
    public override int Ac => 3;
    public override bool Activate => true;
    public override int Cost => 300000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of Ithaqua";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 15;
    public override int Rarity => 120;
    public override bool ResNexus => true;
    public override bool Speed => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 40;
}
