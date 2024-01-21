// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection;

namespace AngbandOS.Core.Towns;

[Serializable]
internal class CelephaisTown : Town
{
    private CelephaisTown(SaveGame saveGame) : base(saveGame) { }
    protected override string[] StoreNames => new string[] {
        nameof(GeneralStore),
        nameof(ArmouryStore),
        nameof(WeaponStore),
        nameof(TempleStore),
        nameof(TempleStore),
        nameof(AlchemistStore),
        nameof(MagicStore),
        nameof(HomeStore),
        nameof(LibraryStore),
        nameof(InnStore),
        nameof(HallStore),
        nameof(PawnStore)
    };
    public override int HousePrice => 50000;
    public override string Name => "the beautiful city of Celephais";
    public override char Char => 'C';
}