// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ProbingDetectionAndFullIdScript : UsedResultUniversalScript, IGetKey
{
    private ProbingDetectionAndFullIdScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind()
    {
        RechargeItemScript = Game.SingletonRepository.Get<RechargeItemScript>(nameof(RechargeItem2xRechargeItemScript));
    }

    private RechargeItemScript RechargeItemScript;
    public override UsedResultEnum ExecuteUsedScript()
    {
        UsedResultEnum rechargeItemUsedResult = RechargeItemScript.ExecuteUsedScript();
        if (rechargeItemUsedResult == UsedResultEnum.False)
        {
            return rechargeItemUsedResult;
        }
        Game.RunScript(nameof(DetectionScript));
        Game.Probing();
        return UsedResultEnum.True;
    }
}
