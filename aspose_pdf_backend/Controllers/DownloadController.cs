using System;
using System.IO;
using System.Text;
using Aspose.Pdf.Cloud.Sdk.Api;
using Aspose.Pdf.Cloud.Sdk.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace aspose_pdf_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        public FileStreamResult Get([FromQuery] string path, [FromQuery] string storageName)
        {
            try
            {
                Configuration conf = new Configuration("11a215a4bdfe6d6734cc2cd39083e144", "220de38b-0189-4286-b8ec-bcf00515502c");
                PdfApi api = new PdfApi(conf);
                MemoryStream memStream = new MemoryStream();
                api.DownloadFile(path, storageName).CopyTo(memStream);
                memStream.Position = 0;
                return new FileStreamResult(memStream, "application/octet-stream");
            }
            catch (Exception exc)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                string jc = JsonConvert.SerializeObject(exc, ResponseHandler.getJsonSerialzerSettings());
                return new FileStreamResult(new MemoryStream(Encoding.UTF8.GetBytes(jc)), "application/json");
            }
        }
    }
}
