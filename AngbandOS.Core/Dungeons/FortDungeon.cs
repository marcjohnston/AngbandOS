// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static AngbandOS.Core.CelephaisDungeon;

namespace AngbandOS.Core
{
[Serializable]
    internal class FortDungeon : Dungeon
    {
        private FortDungeon(SaveGame saveGame) : base(saveGame) { }
        public override int BaseOffset => 1;
        /// <summary>
        /// Returns true because this dungeon is a tower.
        /// </summary>
        public override bool Tower => true;
        public override int MaxLevel => 5;
        public override MonsterSelector? Bias => new KoboldMonsterSelector();
        public override string FirstGuardian => "Vort the Kobold Queen";
        public override int FirstLevel => 5;
        public override string Name => "the Kobold Fort";
        public override string Shortname => "Fort";
        public override string MapSymbol => "f";
    }
}