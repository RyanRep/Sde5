using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sde5.Data;

namespace Sde5
{
    public partial class ExportSdeController : ExportController
    {
        private readonly SdeContext context;

        public ExportSdeController(SdeContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/Sde/deliveryextracts/csv")]
        [HttpGet("/export/Sde/deliveryextracts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDeliveryExtractsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DeliveryExtracts, Request.Query), fileName);
        }

        [HttpGet("/export/Sde/deliveryextracts/excel")]
        [HttpGet("/export/Sde/deliveryextracts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDeliveryExtractsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DeliveryExtracts, Request.Query), fileName);
        }
        [HttpGet("/export/Sde/deliveryparameters/csv")]
        [HttpGet("/export/Sde/deliveryparameters/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDeliveryParametersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DeliveryParameters, Request.Query), fileName);
        }

        [HttpGet("/export/Sde/deliveryparameters/excel")]
        [HttpGet("/export/Sde/deliveryparameters/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDeliveryParametersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DeliveryParameters, Request.Query), fileName);
        }
        [HttpGet("/export/Sde/extracts/csv")]
        [HttpGet("/export/Sde/extracts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportExtractsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Extracts, Request.Query), fileName);
        }

        [HttpGet("/export/Sde/extracts/excel")]
        [HttpGet("/export/Sde/extracts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportExtractsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Extracts, Request.Query), fileName);
        }
        [HttpGet("/export/Sde/lists/csv")]
        [HttpGet("/export/Sde/lists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Lists, Request.Query), fileName);
        }

        [HttpGet("/export/Sde/lists/excel")]
        [HttpGet("/export/Sde/lists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Lists, Request.Query), fileName);
        }
        [HttpGet("/export/Sde/listextracts/csv")]
        [HttpGet("/export/Sde/listextracts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportListExtractsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ListExtracts, Request.Query), fileName);
        }

        [HttpGet("/export/Sde/listextracts/excel")]
        [HttpGet("/export/Sde/listextracts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportListExtractsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ListExtracts, Request.Query), fileName);
        }
        [HttpGet("/export/Sde/parameters/csv")]
        [HttpGet("/export/Sde/parameters/csv(fileName='{fileName}')")]
        public FileStreamResult ExportParametersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Parameters, Request.Query), fileName);
        }

        [HttpGet("/export/Sde/parameters/excel")]
        [HttpGet("/export/Sde/parameters/excel(fileName='{fileName}')")]
        public FileStreamResult ExportParametersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Parameters, Request.Query), fileName);
        }
        [HttpGet("/export/Sde/parametervalues/csv")]
        [HttpGet("/export/Sde/parametervalues/csv(fileName='{fileName}')")]
        public FileStreamResult ExportParameterValuesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ParameterValues, Request.Query), fileName);
        }

        [HttpGet("/export/Sde/parametervalues/excel")]
        [HttpGet("/export/Sde/parametervalues/excel(fileName='{fileName}')")]
        public FileStreamResult ExportParameterValuesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ParameterValues, Request.Query), fileName);
        }
    }
}
