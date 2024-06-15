// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class AmuletOfLobonFixedArtifact : FixedArtifact
{
    private AmuletOfLobonFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(CarlammasAmuletJeweleryItemFactory);

    // Amulet of Lobon protects us from evil
    protected override string? ActivationName => nameof(ProtectionFromEvilActivation);

    public override string Name => "The Amulet of Lobon";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 60000;
    public override int TreasureRating => 20;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of Lobon";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 50;
    public override int BonusConstitution => 2;
    public override int Rarity => 10;
    public override bool ResFire => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 3;
}
