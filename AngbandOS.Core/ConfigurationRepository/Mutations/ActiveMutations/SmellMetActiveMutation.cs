// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SmellMetActiveMutation : Mutation
{
    private SmellMetActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (SaveGame.CheckIfRacialPowerWorks(3, 2, Ability.Intelligence, 12))
        {
            SaveGame.DetectTreasure();
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 3 ? "smell metal      (unusable until level 3)" : "smell metal      (cost 2, INT based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You smell a metallic odor.";
    public override string HaveMessage => "You can smell nearby precious metal.";
    public override string LoseMessage => "You no longer smell a metallic odor.";
}