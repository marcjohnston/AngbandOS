﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class ItemAction : IGetKey
{
    protected readonly Game Game;
    protected ItemAction(Game game)
    {
        Game = game;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        ItemFilters = Game.SingletonRepository.Get<ItemFilter>(ItemFilterNames);
    }


    protected abstract string[] ItemFilterNames { get; }

    public ItemFilter[] ItemFilters { get; protected set; }

    public virtual void ItemDestroyed(Item item, int count) { }
}
