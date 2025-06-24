// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Xml.Linq;

namespace AngbandOS.Core;

[Serializable]
internal class MartialArtsAttack : IGetKey
{
    protected readonly Game Game;

    public MartialArtsAttack(Game game, MartialArtsAttackGameConfiguration martialArtsAttackGameConfiguration)
    {
        Game = game;
        Key = martialArtsAttackGameConfiguration.Key ?? martialArtsAttackGameConfiguration.GetType().Name;
        Chance = martialArtsAttackGameConfiguration.Chance;
        Dd = martialArtsAttackGameConfiguration.Dd;
        Desc = martialArtsAttackGameConfiguration.Desc;
        Ds = martialArtsAttackGameConfiguration.Ds;
        MartialArtsEffectBindingKey = martialArtsAttackGameConfiguration.MartialArtsEffectBindingKey;
        MinLevel = martialArtsAttackGameConfiguration.MinLevel;
        IsDefault = martialArtsAttackGameConfiguration.IsDefault;
    }


    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        MartialArtsAttackGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            Chance = Chance,
            Dd = Dd,
            Desc = Desc,
            Ds = Ds,
            MartialArtsEffectBindingKey = MartialArtsEffectBindingKey,
            MinLevel = MinLevel,
            IsDefault = IsDefault,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind()
    {
        MartialArtsAttackEffect = Game.SingletonRepository.Get<MartialArtsEffect>(MartialArtsEffectBindingKey);
    }

    public virtual int Chance { get; }
    public virtual int Dd { get; }
    public virtual string Desc { get; }
    public virtual int Ds { get; }
    public MartialArtsEffect MartialArtsAttackEffect { get; private set; }
    protected virtual string MartialArtsEffectBindingKey { get; }
    public virtual int MinLevel { get;  }
    public virtual bool IsDefault { get; } = false;
}