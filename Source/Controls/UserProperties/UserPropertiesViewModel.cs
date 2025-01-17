﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MQTTnet.Packets;
using MQTTnetApp.Common;
using ReactiveUI;

namespace MQTTnetApp.Controls;

public sealed class UserPropertiesViewModel : BaseViewModel
{
    bool _isReadOnly;

    public bool IsReadOnly
    {
        get => _isReadOnly;
        set => this.RaiseAndSetIfChanged(ref _isReadOnly, value);
    }

    public ObservableCollection<UserPropertyViewModel> Items { get; } = new();

    public void AddItem()
    {
        Items.Add(new UserPropertyViewModel(this));
    }

    public void ClearItems()
    {
        Items.Clear();
    }

    public void Load(IReadOnlyCollection<MqttUserProperty>? userProperties)
    {
        Items.Clear();

        if (userProperties == null)
        {
            return;
        }

        foreach (var userProperty in userProperties)
        {
            Items.Add(new UserPropertyViewModel(this)
            {
                Name = userProperty.Name,
                Value = userProperty.Value
            });
        }
    }

    public void RemoveItem(UserPropertyViewModel item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        Items.Remove(item);
    }
}