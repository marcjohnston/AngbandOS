// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MidasTchActiveMutation : Mutation
{
    private MidasTchActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (SaveGame.CheckIfRacialPowerWorks(10, 5, Ability.Intelligence, 12))
        {
            SaveGame.Alchemy();
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 10 ? "midas touch      (unusable until level 10)" : "midas touch      (cost 5, INT based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You gain the Midas touch.";
    public override string HaveMessage => "You can turn ordinary items to gold.";
    public override string LoseMessage => "You lose the Midas touch.";
}