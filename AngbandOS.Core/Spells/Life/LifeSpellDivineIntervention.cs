// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life
{
    [Serializable]
    internal class LifeSpellDivineIntervention : Spell
    {
        private LifeSpellDivineIntervention(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            saveGame.Project(0, 1, saveGame.Player.MapY, saveGame.Player.MapX, 777, new HolyFireProjectile(saveGame),
                ProjectionFlag.ProjectKill);
            saveGame.DispelMonsters(saveGame.Player.Level * 4);
            saveGame.SlowMonsters();
            saveGame.StunMonsters(saveGame.Player.Level * 4);
            saveGame.ConfuseMonsters(saveGame.Player.Level * 4);
            saveGame.TurnMonsters(saveGame.Player.Level * 4);
            saveGame.StasisMonsters(saveGame.Player.Level * 4);
            saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, new CthuloidMonsterSelector(), true);
            saveGame.Player.TimedSuperheroism.AddTimer(Program.Rng.DieRoll(25) + 25);
            saveGame.Player.RestoreHealth(300);
            if (saveGame.Player.TimedHaste.TurnsRemaining == 0)
            {
                saveGame.Player.TimedHaste.SetTimer(Program.Rng.DieRoll(20 + saveGame.Player.Level) + saveGame.Player.Level);
            }
            else
            {
                saveGame.Player.TimedHaste.AddTimer(Program.Rng.DieRoll(5));
            }
            saveGame.Player.TimedFear.ResetTimer();
        }

        public override string Name => "Divine Intervention";
        
        protected override string Comment(Player player)
        {
            return $"h300/d{player.Level * 4}+777";
        }
    }
}