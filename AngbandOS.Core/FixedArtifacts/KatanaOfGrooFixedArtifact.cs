// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class KatanaOfGrooFixedArtifact : FixedArtifact
{
    private KatanaOfGrooFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(KatanaWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Katana of Groo";
    public override int Ac => 0;
    public override bool Blows => true;
    public override int Cost => 75000;
    public override int TreasureRating => 20;
    public override int Dd => 8;
    public override bool Dex => true;
    public override int Ds => 4;
    public override string FriendlyName => "of Groo";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int InitialBonusExtraBlows => 3;
    public override int InitialBonusDexterity => 3;
    public override int InitialBonusSpeed => 3;
    public override int Rarity => 25;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override bool SustDex => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override bool Vorpal => true;
    public override int Weight => 50;
}
