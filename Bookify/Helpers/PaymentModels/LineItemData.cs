using Newtonsoft.Json;

namespace Bookify.Helpers.PaymentModels;

public class LineItemData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("amount_discount")]
    public int AmountDiscount { get; set; }

    [JsonProperty("amount_subtotal")]
    public int AmountSubtotal { get; set; }

    [JsonProperty("amount_tax")]
    public int AmountTax { get; set; }

    [JsonProperty("amount_total")]
    public int AmountTotal { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("price")]
    public PriceData Price { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }
}