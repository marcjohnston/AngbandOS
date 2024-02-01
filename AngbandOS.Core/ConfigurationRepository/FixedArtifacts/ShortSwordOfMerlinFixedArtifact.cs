// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ShortSwordOfMerlinFixedArtifact : FixedArtifact
{
    private ShortSwordOfMerlinFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(ShortSwordWeaponItemFactory);


    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Short Sword of Merlin";
    public override int Ac => 0;
    public override bool Blows => true;
    public override int Cost => 35000;
    public override int Dd => 1;
    public override int Ds => 7;
    public override string FriendlyName => "of Merlin";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 2;
    public override int Rarity => 8;
    public override bool Regen => true;
    public override bool ResDisen => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlowDigest => true;
    public override int ToA => 0;
    public override int ToD => 7;
    public override int ToH => 3;
    public override int Weight => 80;
}
