// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static AngbandOS.Core.CelephaisDungeon;

namespace AngbandOS.Core;

[Serializable]
internal class KothDungeon : Dungeon
{
    private KothDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 40;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 20;
    public override MonsterSelector? Bias => new CthuloidMonsterSelector();
    public override string FirstGuardian => "Father Dagon";
    public override string SecondGuardian => "Tulzscha";
    public override int FirstLevel => 1;
    public override int SecondLevel => 20;
    public override string Name => "the Tower of Koth";
    public override string Shortname => "Koth";
    public override string MapSymbol => "k";
}