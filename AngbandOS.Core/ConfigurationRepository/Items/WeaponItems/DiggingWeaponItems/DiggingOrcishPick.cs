// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class DiggingOrcishPick : DiggingItemClass
{
    private DiggingOrcishPick(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(BackSlashSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Orcish Pick";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 300;
    public override int Dd => 1;
    public override int Ds => 3;
    public override string FriendlyName => "& Orcish Pick~";
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int Pval => 2;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 150;
    public override Item CreateItem() => new OrcishPickDiggingWeaponItem(SaveGame);
}
