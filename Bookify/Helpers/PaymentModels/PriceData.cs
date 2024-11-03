using Newtonsoft.Json;

namespace Bookify.Helpers.PaymentModels;

public class PriceData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }

    [JsonProperty("billing_scheme")]
    public string BillingScheme { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("custom_unit_amount")]
    public object CustomUnitAmount { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("lookup_key")]
    public object LookupKey { get; set; }

    [JsonProperty("nickname")]
    public object Nickname { get; set; }

    [JsonProperty("product")]
    public string Product { get; set; }

    [JsonProperty("recurring")]
    public object Recurring { get; set; }

    [JsonProperty("tax_behavior")]
    public string TaxBehavior { get; set; }

    [JsonProperty("tiers_mode")]
    public object TiersMode { get; set; }

    [JsonProperty("transform_quantity")]
    public object TransformQuantity { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("unit_amount")]
    public int UnitAmount { get; set; }

    [JsonProperty("unit_amount_decimal")]
    public string UnitAmountDecimal { get; set; }
}