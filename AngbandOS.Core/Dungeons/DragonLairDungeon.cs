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
internal class DragonLairDungeon : Dungeon
{
    private DragonLairDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 15;
    public override int MaxLevel => 35;
    public override MonsterSelector? Bias => new DragonMonsterSelector();
    public override string FirstGuardian => "Glaurung, Father of the Dragons";
    public override string SecondGuardian => "Ancalagon the Black";
    public override int FirstLevel => 34;
    public override int SecondLevel => 35;
    public override string Name => "the Dragon's Lair";
    public override string Shortname => "Dragon Lair";
    public override string MapSymbol => "l";
}