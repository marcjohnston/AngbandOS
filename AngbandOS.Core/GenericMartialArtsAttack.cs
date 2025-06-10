// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class GenericMartialArtsAttack : MartialArtsAttack
{
    public GenericMartialArtsAttack(Game game, MartialArtsAttackGameConfiguration martialArtsAttackGameConfiguration) : base(game)
    {
        Key = martialArtsAttackGameConfiguration.Key ?? martialArtsAttackGameConfiguration.GetType().Name;
        Chance = martialArtsAttackGameConfiguration.Chance;
        Dd = martialArtsAttackGameConfiguration.Dd;
        Desc = martialArtsAttackGameConfiguration.Desc;
        Ds = martialArtsAttackGameConfiguration.Ds;
        Effect = martialArtsAttackGameConfiguration.Effect;
        MinLevel = martialArtsAttackGameConfiguration.MinLevel;
        IsDefault = martialArtsAttackGameConfiguration.IsDefault;
    }

    public override string Key { get; }
    public override int Chance { get; }
    public override int Dd { get; }
    public override string Desc { get; }
    public override int Ds { get; }
    public override int Effect { get; }
    public override int MinLevel { get; }
    public override bool IsDefault { get; }
}