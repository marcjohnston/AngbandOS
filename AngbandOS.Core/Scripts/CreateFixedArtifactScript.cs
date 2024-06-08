// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CreateFixedArtifactScript : Script, IScript
{
    private CreateFixedArtifactScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Retrieve the command argument which is 1-based.  We need to convert it to 0-based.
        int aIdx = Game.CommandArgument - 1;
        if (aIdx < 0 || aIdx >= Game.SingletonRepository.Count<FixedArtifact>())
        {
            return;
        }
        FixedArtifact aPtr = Game.SingletonRepository.Get<FixedArtifact>(aIdx);
        if (aPtr.CurNum > 0)
        {
            return;
        }
        aPtr.CurNum = 1;
        Item qPtr = new Item(Game, aPtr.BaseItemFactory);
        qPtr.FixedArtifact = Game.SingletonRepository.Get<FixedArtifact>(aIdx);
        qPtr.TypeSpecificValue = aPtr.InitialTypeSpecificValue;
        qPtr.ArmorClass = aPtr.Ac;
        qPtr.DamageDice = aPtr.Dd;
        qPtr.DamageSides = aPtr.Ds;
        qPtr.BonusArmorClass = aPtr.ToA;
        qPtr.BonusHit = aPtr.ToH;
        qPtr.BonusDamage = aPtr.ToD;
        qPtr.Weight = aPtr.Weight;
        if (aPtr.Cursed)
        {
            qPtr.IsCursed = true;
        }
        qPtr.GetFixedArtifactResistances();
        Game.DropNear(qPtr, -1, Game.MapY.IntValue, Game.MapX.IntValue);
        Game.MsgPrint("Allocated.");
    }
}
