// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationDazzle : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(7, 15, Ability.Charisma, 8))
        {
            return;
        }
        saveGame.StunMonsters(saveGame.Player.ExperienceLevel * 4);
        saveGame.ConfuseMonsters(saveGame.Player.ExperienceLevel * 4);
        saveGame.TurnMonsters(saveGame.Player.ExperienceLevel * 4);
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 7 ? "dazzle           (unusable until level 7)" : "dazzle           (cost 15, CHA based)";
    }

    public override void Initialize()
    {
        Frequency = 3;
        GainMessage = "You gain the ability to emit dazzling lights.";
        HaveMessage = "You can emit confusing, blinding radiation.";
        LoseMessage = "You lose the ability to emit dazzling lights.";
    }
}