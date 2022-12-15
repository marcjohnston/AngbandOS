using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class TeleportAwayMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;

        public override bool ProvidesEscape => true;

        public override string? VsPlayerBlindMessage => $"Someone teleports you away.";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} teleports you away.";
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} teleports {target.Name} away.";
        public override string? VsMonsterUnseenMessage => null;

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            saveGame.TeleportPlayer(100);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            bool resistsTele = false;
            string targetName = target.Name;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seeTarget = !blind && target.IsVisible;
            MonsterRace targetRace = target.Race;

            if (targetRace.ResistTeleport)
            {
                if (targetRace.Unique)
                {
                    if (seeTarget)
                    {
                        targetRace.Knowledge.Characteristics.ResistTeleport = true;
                        saveGame.MsgPrint($"{targetName} is unaffected!");
                    }
                    resistsTele = true;
                }
                else if (targetRace.Level > Program.Rng.DieRoll(100))
                {
                    if (seeTarget)
                    {
                        targetRace.Knowledge.Characteristics.ResistTeleport = true;
                        saveGame.MsgPrint($"{targetName} resists!");
                    }
                    resistsTele = true;
                }
            }
            if (!resistsTele)
            {
                target.TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
            }
        }
    }
}
