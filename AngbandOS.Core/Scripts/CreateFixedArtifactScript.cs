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
        if (aPtr.BonusStrength != null)
        {
            qPtr.BonusStrength = aPtr.BonusStrength.Get(Game.UseRandom);
        }
        if (aPtr.BonusIntelligence != null)
        {
            qPtr.BonusIntelligence = aPtr.BonusIntelligence.Get(Game.UseRandom);
        }
        if (aPtr.BonusWisdom != null)
        {
            qPtr.BonusWisdom = aPtr.BonusWisdom.Get(Game.UseRandom);
        }
        if (aPtr.BonusDexterity != null)
        {
            qPtr.BonusDexterity = aPtr.BonusDexterity.Get(Game.UseRandom);
        }
        if (aPtr.BonusConstitution != null)
        {
            qPtr.BonusConstitution = aPtr.BonusConstitution.Get(Game.UseRandom);
        }
        if (aPtr.BonusCharisma != null)
        {
            qPtr.BonusCharisma = aPtr.BonusCharisma.Get(Game.UseRandom);
        }
        if (aPtr.BonusStealth != null)
        {
            qPtr.BonusStealth = aPtr.BonusStealth.Get(Game.UseRandom);
        }
        if (aPtr.BonusSearch != null)
        {
            qPtr.BonusSearch = aPtr.BonusSearch.Get(Game.UseRandom);
        }
        if (aPtr.BonusInfravision != null)
        {
            qPtr.BonusInfravision = aPtr.BonusInfravision.Get(Game.UseRandom);
        }
        if (aPtr.BonusTunnel != null)
        {
            qPtr.BonusTunnel = aPtr.BonusTunnel.Get(Game.UseRandom);
        }
        if (aPtr.BonusAttacks != null)
        {
            qPtr.BonusAttacks = aPtr.BonusAttacks.Get(Game.UseRandom);
        }
        if (aPtr.BonusSpeed != null)
        {
            qPtr.BonusSpeed = aPtr.BonusSpeed.Get(Game.UseRandom);
        }
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
