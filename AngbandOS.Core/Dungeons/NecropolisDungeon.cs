// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static AngbandOS.Core.CelephaisDungeon;

namespace AngbandOS.Core;

[Serializable]
internal class NecropolisDungeon : Dungeon
{
    private NecropolisDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 30;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 40;
    public override MonsterSelector? Bias => new HiUndeadMonsterSelector();
    public override string FirstGuardian => "Fire Phantom";
    public override string SecondGuardian => "Vecna, the Emperor Lich";
    public override int FirstLevel => 1;
    public override int SecondLevel => 40;
    public override string Name => "the Necropolis";
    public override string Shortname => "Necropolis";
    public override string MapSymbol => "n";
}