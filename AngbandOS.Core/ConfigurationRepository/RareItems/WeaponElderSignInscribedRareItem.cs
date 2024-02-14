// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponElderSignInscribedRareItem : RareItem
{
    private WeaponElderSignInscribedRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override void ApplyMagic(Item item)
    {
        item.BonusPowerType = SaveGame.SingletonRepository.Powers.Get(nameof(SpecialSustainPower));
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(VerticalBarSymbol));
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Weapon (Elder Sign Inscribed)";
    public override bool Blessed => true;
    public override int Cost => 20000;
    public override string FriendlyName => "(Elder Sign Inscribed)";
    public override int Level => 0;
    public override int MaxPval => 4;
    public override int MaxToA => 4;
    public override int MaxToD => 6;
    public override int MaxToH => 6;
    public override int Rarity => 0;
    public override int Rating => 30;
    public override bool ResFear => true;
    public override bool SeeInvis => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override int Slot => 24;
    public override bool Wis => true;
}
