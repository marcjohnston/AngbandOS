// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Core.MonsterSelectors;
using System;

namespace AngbandOS.Mutations.RandomMutations
{
    [Serializable]
    internal class MutationAttDragon : Mutation
    {
        public override void Initialise()
        {
            Frequency = 1;
            GainMessage = "You start attracting dragons.";
            HaveMessage = "You attract dragons.";
            LoseMessage = "You stop attracting dragons.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (saveGame.Player.HasAntiMagic || Program.Rng.DieRoll(3000) != 13)
            {
                return;
            }
            bool dSummon;
            if (Program.Rng.DieRoll(5) == 1)
            {
                dSummon = saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new DragonMonsterSelector(), true);
            }
            else
            {
                dSummon = saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new DragonMonsterSelector());
            }
            if (!dSummon)
            {
                return;
            }
            saveGame.MsgPrint("You have attracted a dragon!");
            saveGame.Disturb(false);
        }
    }
}