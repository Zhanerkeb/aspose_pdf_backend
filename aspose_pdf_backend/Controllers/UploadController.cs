using System;
using System.IO;
using Aspose.Pdf.Cloud.Sdk.Api;
using Aspose.Pdf.Cloud.Sdk.Client;
using Aspose.Pdf.Cloud.Sdk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspose_pdf_backend.Controllers {

  [Route("[controller]")]
  [ApiController]
  public class UploadController : ControllerBase {

    [HttpPost]
    public ContentResult Post([FromQuery] string path, [FromQuery] string storageName) {
      MemoryStream memStream = new MemoryStream();
      Request.Form.Files[0].CopyTo(memStream);
      memStream.Position = 0;
      Configuration conf = new Configuration("11a215a4bdfe6d6734cc2cd39083e144", "220de38b-0189-4286-b8ec-bcf00515502c");
      PdfApi api = new PdfApi(conf);
      try {
        FilesUploadResult res = api.UploadFile(path, memStream, storageName);
        if (res.Errors != null && res.Errors.Count > 0) {
          return ResponseHandler._MakeContentResult(res, StatusCodes.Status500InternalServerError);
        }
      }
      catch (Exception exc) {
        return ResponseHandler._MakeContentResult(exc, StatusCodes.Status500InternalServerError);
      }
      return ResponseHandler._MakeContentResult(new Upload { Url = path }, StatusCodes.Status200OK);
    }
  }
}
