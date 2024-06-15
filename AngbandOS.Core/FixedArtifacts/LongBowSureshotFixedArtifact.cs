// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongBowSureshotFixedArtifact : FixedArtifact
{
    private LongBowSureshotFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LongBowWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Long Bow 'Sureshot'";
    public override int Ac => 0;
    public override int Cost => 35000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override string FriendlyName => "'Sureshot'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int InitialBonusDexterity => 3;
    public override int InitialBonusStealth => 3;
    public override int Rarity => 20;
    public override bool ResDisen => true;
    public override bool ShowMods => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 22;
    public override int ToH => 20;
    public override int Weight => 40;
    public override bool XtraShots => true;
}
