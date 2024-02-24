using AutoFixture;
using AutoFixture.AutoMoq;

namespace SignalChat.Tests;

/// <summary>
/// Атрибут для автоматического мока данных.
/// </summary>
public class AutoMoqDataAttribute() : AutoDataAttribute(() => new Fixture().Customize(new AutoMoqCustomization()));