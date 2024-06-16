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
        int aIdx = Game.CommandArgument;
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
        qPtr.BonusStrength = aPtr.InitialBonusStrength;
        qPtr.BonusIntelligence = aPtr.InitialBonusIntelligence;
        qPtr.BonusWisdom = aPtr.InitialBonusWisdom;
        qPtr.BonusDexterity = aPtr.InitialBonusDexterity;
        qPtr.BonusConstitution = aPtr.InitialBonusConstitution;
        qPtr.BonusCharisma = aPtr.InitialBonusCharisma;
        qPtr.BonusStealth = aPtr.InitialBonusStealth;
        qPtr.BonusSearch = aPtr.InitialBonusSearch;
        qPtr.BonusInfravision = aPtr.InitialBonusInfravision;
        qPtr.BonusTunnel = aPtr.InitialBonusTunnel;
        qPtr.BonusAttacks = aPtr.InitialBonusExtraBlows;
        qPtr.BonusSpeed = aPtr.InitialBonusSpeed;
        qPtr.ArmorClass = aPtr.Ac;
        qPtr.DamageDice = aPtr.Dd;
        qPtr.DamageSides = aPtr.Ds;
        qPtr.BonusArmorClass = aPtr.ToA;
        qPtr.BonusHit = aPtr.ToH;
        qPtr.BonusDamage = aPtr.ToD;
        qPtr.Weight = aPtr.Weight;
        if (aPtr.IsCursed)
        {
            qPtr.IsCursed = true;
        }
        qPtr.GetFixedArtifactResistances();
        Game.DropNear(qPtr, -1, Game.MapY.IntValue, Game.MapX.IntValue);
        Game.MsgPrint("Allocated.");
    }
}
