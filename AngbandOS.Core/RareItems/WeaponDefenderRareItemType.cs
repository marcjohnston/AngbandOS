// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponDefenderRareItem : RareItem
{
    private WeaponDefenderRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "Weapon (Defender)";
    public override int Cost => 15000;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "(Defender)";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 4;
    public override int MaxToA => 8;
    public override int MaxToD => 4;
    public override int MaxToH => 4;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponDefender;
    public override int Rarity => 0;
    public override int Rating => 25;
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override int Slot => 24;
    public override bool Stealth => true;
}
