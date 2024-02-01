// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BroadSwordLightningFixedArtifact : FixedArtifact
{
    private BroadSwordLightningFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(BroadSwordWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Broad Sword 'Lightning'";
    public override int Ac => 0;
    public override bool BrandElec => true;
    public override int Cost => 95000;
    public override int Dd => 2;
    public override int Ds => 5;

    /// <summary>
    /// Returns 3, because this sword of lighting has a 3x multipler when killing dragons.
    /// </summary>
    public override int KilLDragonMultiplier => 3;

    public override string FriendlyName => "'Lightning'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 90;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
    public override int ToA => 0;
    public override int ToD => 16;
    public override int ToH => 12;
    public override int Weight => 150;
}
