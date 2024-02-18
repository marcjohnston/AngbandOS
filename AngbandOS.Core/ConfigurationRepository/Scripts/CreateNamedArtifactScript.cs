// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CreateNamedArtifactScript : Script, IScript
{
    private CreateNamedArtifactScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int aIdx = SaveGame.CommandArgument;
        if (aIdx < 0 || aIdx >= SaveGame.SingletonRepository.FixedArtifacts.Count)
        {
            return;
        }
        FixedArtifact aPtr = SaveGame.SingletonRepository.FixedArtifacts[aIdx];
        if (aPtr.CurNum > 0)
        {
            return;
        }
        aPtr.CurNum = 1;
        Item qPtr = aPtr.BaseItemFactory.CreateItem();
        qPtr.FixedArtifact = SaveGame.SingletonRepository.FixedArtifacts[aIdx];
        qPtr.TypeSpecificValue = aPtr.Pval;
        qPtr.BaseArmorClass = aPtr.Ac;
        qPtr.DamageDice = aPtr.Dd;
        qPtr.DamageDiceSides = aPtr.Ds;
        qPtr.BonusArmorClass = aPtr.ToA;
        qPtr.BonusToHit = aPtr.ToH;
        qPtr.BonusDamage = aPtr.ToD;
        qPtr.Weight = aPtr.Weight;
        if (aPtr.Cursed)
        {
            qPtr.IdentCursed = true;
        }
        qPtr.GetFixedArtifactResistances();
        SaveGame.DropNear(qPtr, -1, SaveGame.MapY, SaveGame.MapX);
        SaveGame.MsgPrint("Allocated.");
    }
}
