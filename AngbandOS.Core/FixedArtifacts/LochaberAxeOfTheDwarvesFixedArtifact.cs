// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LochaberAxeOfTheDwarvesFixedArtifact : FixedArtifact
{
    private LochaberAxeOfTheDwarvesFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LochaberAxePolearmWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Lochaber Axe of the Dwarves";
    public override int Ac => 0;
    public override int Cost => 80000;
    public override int Dd => 3;
    public override int Ds => 8;
    public override string FriendlyName => "of the Dwarves";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 30;
    public override int InitialTypeSpecificValue => 10;
    public override int Rarity => 8;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool Search => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override int ToA => 0;
    public override int ToD => 17;
    public override int ToH => 12;
    public override bool Tunnel => true;
    public override int Weight => 250;
}
