// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TridentOfWrathFixedArtifact : FixedArtifact
{
    private TridentOfWrathFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(TridentPolearmWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Trident of Wrath";
    public override int Ac => 0;
    public override bool Blessed => true;
    public override bool Chaotic => true;
    public override int Cost => 90000;
    public override int Dd => 3;
    public override bool Dex => true;
    public override int Ds => 8;
    public override string FriendlyName => "of Wrath";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 15;
    public override int Pval => 2;
    public override int Rarity => 35;
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 18;
    public override int ToH => 16;
    public override int Weight => 300;
}
