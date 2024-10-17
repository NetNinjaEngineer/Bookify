using Newtonsoft.Json;

namespace Bookify.Helpers.PaymentModels;

public class CheckoutLineItemResponse
{
    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("has_more")]
    public bool HasMore { get; set; }

    [JsonProperty("data")]
    public List<LineItemData> Data { get; set; } = [];

    [JsonProperty("url")]
    public string Url { get; set; }
}