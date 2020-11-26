using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace aspose_pdf_backend.Controllers {

  public class Upload {
    [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
    public string Url { get; set; }
  }
public class ResponseHandler {
    public static JsonSerializerSettings _jss = new JsonSerializerSettings {
      DefaultValueHandling = DefaultValueHandling.Ignore,
      Formatting = Formatting.Indented,
      NullValueHandling = NullValueHandling.Ignore
    };

    public static ContentResult _MakeContentResult(object content, int statusCode) {
      return new ContentResult {
        Content = JsonConvert.SerializeObject(content, _jss),
        ContentType = "application/json",
        StatusCode = statusCode
      };
    }

    public static JsonSerializerSettings getJsonSerialzerSettings() {
        return _jss;
    }
  }
}
