﻿using System.Collections.ObjectModel;
using ReactiveUI;

namespace MQTTnetApp.Common;

public sealed class PageItemsViewModel<TItem> : BaseViewModel
{
    TItem? _selectedItem;

    public ObservableCollection<TItem> Collection { get; } = new();

    public TItem? SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }

    public void MoveItemDown(TItem? item)
    {
        if (item == null)
        {
            return;
        }

        var index = Collection.IndexOf(item);

        if (index >= Collection.Count - 1)
        {
            return;
        }

        Collection.Move(index, ++index);
    }

    public void MoveItemUp(TItem? item)
    {
        if (item == null)
        {
            return;
        }

        var index = Collection.IndexOf(item);

        if (index <= 0)
        {
            return;
        }

        Collection.Move(index, --index);
    }
}