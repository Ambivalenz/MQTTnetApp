﻿using System;
using System.Threading.Tasks;
using MQTTnetApp.Common;
using MQTTnetApp.Controls;
using ReactiveUI;

namespace MQTTnetApp.Pages.Publish;

public sealed class PublishItemViewModel : BaseViewModel
{
    string? _contentType;
    uint _messageExpiryInterval;
    string _name = string.Empty;
    string? _payload;
    string? _responseTopic;
    bool _retain;
    uint _subscriptionIdentifier;
    string? _topic;
    ushort _topicAlias;

    public PublishItemViewModel(PublishPageViewModel ownerPage)
    {
        OwnerPage = ownerPage ?? throw new ArgumentNullException(nameof(ownerPage));

        Payload = string.Empty;
        PayloadFormatIndicator.IsUnspecified = true;

        Response.UserProperties.IsReadOnly = true;
    }

    public string? ContentType
    {
        get => _contentType;
        set => this.RaiseAndSetIfChanged(ref _contentType, value);
    }

    public uint MessageExpiryInterval
    {
        get => _messageExpiryInterval;
        set => this.RaiseAndSetIfChanged(ref _messageExpiryInterval, value);
    }

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public PublishPageViewModel OwnerPage { get; }

    public string? Payload
    {
        get => _payload;
        set => this.RaiseAndSetIfChanged(ref _payload, value);
    }

    public PayloadFormatIndicatorSelectorViewModel PayloadFormatIndicator { get; } = new();

    public PayloadInputFormatSelectorViewModel PayloadInputFormat { get; } = new();

    public QualityOfServiceLevelSelectorViewModel QualityOfServiceLevel { get; } = new();

    public PublishResponseViewModel Response { get; } = new();

    public string? ResponseTopic
    {
        get => _responseTopic;
        set => this.RaiseAndSetIfChanged(ref _responseTopic, value);
    }

    public bool Retain
    {
        get => _retain;
        set => this.RaiseAndSetIfChanged(ref _retain, value);
    }

    public uint SubscriptionIdentifier
    {
        get => _subscriptionIdentifier;
        set => this.RaiseAndSetIfChanged(ref _subscriptionIdentifier, value);
    }

    public string? Topic
    {
        get => _topic;
        set => this.RaiseAndSetIfChanged(ref _topic, value);
    }

    public ushort TopicAlias
    {
        get => _topicAlias;
        set => this.RaiseAndSetIfChanged(ref _topicAlias, value);
    }

    public UserPropertiesViewModel UserProperties { get; } = new();

    public Task Publish()
    {
        return OwnerPage.PublishItem(this);
    }
}