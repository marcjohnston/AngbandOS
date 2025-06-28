// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class PlayerEffect : IGetKey
{
    protected readonly Game Game;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind() { }

    protected PlayerEffect(Game game)
    {
        Game = game;
    }

    public virtual int MaximumDamageAllowed => 1600;
    public virtual string? BlindPreMessage => null;

    public IdentifiedResultEnum ApplyEffect(int who, int r, int y, int x, int dam, int aRad)
    {
        if (dam > MaximumDamageAllowed)
        {
            dam = MaximumDamageAllowed;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        if (BlindPreMessage is not null && Game.BlindnessTimer.Value != 0)
        {
            Game.MsgPrint(BlindPreMessage);
        }
        return Apply(mPtr, dam);
    }

    protected abstract IdentifiedResultEnum Apply(Monster mPtr, int dam);
}
