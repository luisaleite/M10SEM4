using System;
using System.Diagnostics.Metrics;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HatCoMetrics>();

public class HatCoMetrics
{
    private readonly Counter<int> _hatsSold;

    public HatCoMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("HatCo.Store");
        _hatsSold = meter.CreateCounter<int>("hatco.store.hats_sold");
    }

    public void HatsSold(int quantity)
    {
        _hatsSold.Add(quantity);
    }
}

app.MapPost("/complete-sale", ([FromBody] SaleModel model, HatCoMetrics metrics) =>
{
    // ... business logic such as saving the sale to a database ...

    metrics.HatsSold(model.QuantitySold);
});

