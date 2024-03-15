// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class DazzleActiveMutation : Mutation
{
    private DazzleActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (!SaveGame.CheckIfRacialPowerWorks(7, 15, Ability.Charisma, 8))
        {
            return;
        }
        SaveGame.StunMonsters(SaveGame.ExperienceLevel.Value * 4);
        SaveGame.ConfuseMonsters(SaveGame.ExperienceLevel.Value * 4);
        SaveGame.TurnMonsters(SaveGame.ExperienceLevel.Value * 4);
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 7 ? "dazzle           (unusable until level 7)" : "dazzle           (cost 15, CHA based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You gain the ability to emit dazzling lights.";
    public override string HaveMessage => "You can emit confusing, blinding radiation.";
    public override string LoseMessage => "You lose the ability to emit dazzling lights.";
}