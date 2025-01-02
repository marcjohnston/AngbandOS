// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class InvocationIdentifableAndUsedScript : Script, IReadScrollOrUseStaffScript
{
    private InvocationIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        Patron? patron = Game.SingletonRepository.ToWeightedRandom<Patron>().ChooseOrDefault();
        if (patron == null)
        {
            throw new Exception("There are no Patrons configured to invoke.");
        }
        Game.MsgPrint($"You invoke the secret name of {patron.LongName}.");
        patron.GetReward();
        return new IdentifiedAndUsedResult(true, true);
    }
}

