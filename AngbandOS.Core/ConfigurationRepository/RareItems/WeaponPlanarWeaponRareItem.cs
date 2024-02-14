// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponPlanarWeaponRareItem : RareItem
{
    private WeaponPlanarWeaponRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override void ApplyMagic(Item item)
    {
        if (SaveGame.DieRoll(7) == 1)
        {
            item.BonusPowerType = SaveGame.SingletonRepository.Powers.Get(nameof(SpecialAbilityPower));
        }
    }
    public override bool DoActivate(Item item)
    {
        SaveGame.RunScriptInt(nameof(TeleportSelfScript), 100);
        item.RechargeTimeLeft = 50 + SaveGame.DieRoll(50);
        return true;
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override string? DescribeActivationEffect => "teleport every 50+d50 turns";
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Weapon (Planar Weapon)";
    public override bool Activate => true;
    public override int Cost => 7000;
    public override bool FreeAct => true;
    public override string FriendlyName => "(Planar Weapon)";
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 4;
    public override int MaxToH => 4;
    public override int Rarity => 0;
    public override int Rating => 22;
    public override bool Regen => true;
    public override bool ResNexus => true;
    public override bool Search => true;
    public override bool SlayEvil => true;
    public override int Slot => 24;
    public override bool SlowDigest => true;
    public override bool Teleport => true;
}
