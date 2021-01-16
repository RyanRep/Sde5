
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using Radzen;
using Sde5.Models.Sde;

namespace Sde5
{
    public partial class SdeService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public SdeService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/SDE/");
        }

        public async System.Threading.Tasks.Task ExportDeliveryExtractsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/deliveryextracts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/deliveryextracts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDeliveryExtractsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/deliveryextracts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/deliveryextracts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDeliveryExtracts(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Sde.DeliveryExtract>> GetDeliveryExtracts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"DeliveryExtracts");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeliveryExtracts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Sde.DeliveryExtract>>();
        }
        partial void OnCreateDeliveryExtract(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.DeliveryExtract> CreateDeliveryExtract(dynamic deliveryExtract = default(dynamic))
        {
            var uri = new Uri(baseUri, $"DeliveryExtracts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(deliveryExtract), Encoding.UTF8, "application/json");

            OnCreateDeliveryExtract(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.DeliveryExtract>();
        }

        public async System.Threading.Tasks.Task ExportDeliveryParametersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/deliveryparameters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/deliveryparameters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDeliveryParametersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/deliveryparameters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/deliveryparameters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDeliveryParameters(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Sde.DeliveryParameter>> GetDeliveryParameters(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"DeliveryParameters");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeliveryParameters(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Sde.DeliveryParameter>>();
        }
        partial void OnCreateDeliveryParameter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.DeliveryParameter> CreateDeliveryParameter(dynamic deliveryParameter = default(dynamic))
        {
            var uri = new Uri(baseUri, $"DeliveryParameters");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(deliveryParameter), Encoding.UTF8, "application/json");

            OnCreateDeliveryParameter(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.DeliveryParameter>();
        }

        public async System.Threading.Tasks.Task ExportExtractsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/extracts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/extracts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportExtractsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/extracts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/extracts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetExtracts(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Sde.Extract>> GetExtracts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Extracts");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetExtracts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Sde.Extract>>();
        }
        partial void OnCreateExtract(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.Extract> CreateExtract(dynamic extract = default(dynamic))
        {
            var uri = new Uri(baseUri, $"Extracts");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(extract), Encoding.UTF8, "application/json");

            OnCreateExtract(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.Extract>();
        }

        public async System.Threading.Tasks.Task ExportListsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/lists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/lists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportListsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/lists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/lists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Sde.List>> GetLists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Lists");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Sde.List>>();
        }
        partial void OnCreateList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.List> CreateList(dynamic list = default(dynamic))
        {
            var uri = new Uri(baseUri, $"Lists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(list), Encoding.UTF8, "application/json");

            OnCreateList(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.List>();
        }

        public async System.Threading.Tasks.Task ExportListExtractsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/listextracts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/listextracts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportListExtractsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/listextracts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/listextracts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetListExtracts(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Sde.ListExtract>> GetListExtracts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"ListExtracts");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetListExtracts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Sde.ListExtract>>();
        }

        public async System.Threading.Tasks.Task ExportParametersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/parameters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/parameters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportParametersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/parameters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/parameters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetParameters(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Sde.Parameter>> GetParameters(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Parameters");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetParameters(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Sde.Parameter>>();
        }
        partial void OnCreateParameter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.Parameter> CreateParameter(dynamic parameter = default(dynamic))
        {
            var uri = new Uri(baseUri, $"Parameters");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(parameter), Encoding.UTF8, "application/json");

            OnCreateParameter(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.Parameter>();
        }

        public async System.Threading.Tasks.Task ExportParameterValuesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/parametervalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/parametervalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportParameterValuesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sde/parametervalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sde/parametervalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetParameterValues(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Models.Sde.ParameterValue>> GetParameterValues(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"ParameterValues");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetParameterValues(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Models.Sde.ParameterValue>>();
        }
        partial void OnCreateParameterValue(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.ParameterValue> CreateParameterValue(dynamic parameterValue = default(dynamic))
        {
            var uri = new Uri(baseUri, $"ParameterValues");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(parameterValue), Encoding.UTF8, "application/json");

            OnCreateParameterValue(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.ParameterValue>();
        }
        partial void OnDeleteDeliveryExtract(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDeliveryExtract(int? deliveryExtractId = default(int?))
        {
            var uri = new Uri(baseUri, $"DeliveryExtracts({deliveryExtractId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDeliveryExtract(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDeliveryExtractByDeliveryExtractId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.DeliveryExtract> GetDeliveryExtractByDeliveryExtractId(int? deliveryExtractId = default(int?))
        {
            var uri = new Uri(baseUri, $"DeliveryExtracts({deliveryExtractId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeliveryExtractByDeliveryExtractId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.DeliveryExtract>();
        }
        partial void OnUpdateDeliveryExtract(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDeliveryExtract(int? deliveryExtractId = default(int?), dynamic deliveryExtract = default(dynamic))
        {
            var uri = new Uri(baseUri, $"DeliveryExtracts({deliveryExtractId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(deliveryExtract), Encoding.UTF8, "application/json");

            OnUpdateDeliveryExtract(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteDeliveryParameter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDeliveryParameter(int? deliveryParameterId = default(int?))
        {
            var uri = new Uri(baseUri, $"DeliveryParameters({deliveryParameterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDeliveryParameter(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDeliveryParameterByDeliveryParameterId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.DeliveryParameter> GetDeliveryParameterByDeliveryParameterId(int? deliveryParameterId = default(int?))
        {
            var uri = new Uri(baseUri, $"DeliveryParameters({deliveryParameterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeliveryParameterByDeliveryParameterId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.DeliveryParameter>();
        }
        partial void OnUpdateDeliveryParameter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDeliveryParameter(int? deliveryParameterId = default(int?), dynamic deliveryParameter = default(dynamic))
        {
            var uri = new Uri(baseUri, $"DeliveryParameters({deliveryParameterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(deliveryParameter), Encoding.UTF8, "application/json");

            OnUpdateDeliveryParameter(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteExtract(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteExtract(int? extractId = default(int?))
        {
            var uri = new Uri(baseUri, $"Extracts({extractId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteExtract(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetExtractByExtractId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.Extract> GetExtractByExtractId(int? extractId = default(int?))
        {
            var uri = new Uri(baseUri, $"Extracts({extractId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetExtractByExtractId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.Extract>();
        }
        partial void OnUpdateExtract(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateExtract(int? extractId = default(int?), dynamic extract = default(dynamic))
        {
            var uri = new Uri(baseUri, $"Extracts({extractId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(extract), Encoding.UTF8, "application/json");

            OnUpdateExtract(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteList(int? listId = default(int?))
        {
            var uri = new Uri(baseUri, $"Lists({listId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteList(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetListByListId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.List> GetListByListId(int? listId = default(int?))
        {
            var uri = new Uri(baseUri, $"Lists({listId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetListByListId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.List>();
        }
        partial void OnUpdateList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateList(int? listId = default(int?), dynamic list = default(dynamic))
        {
            var uri = new Uri(baseUri, $"Lists({listId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(list), Encoding.UTF8, "application/json");

            OnUpdateList(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteParameter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteParameter(int? parameterId = default(int?))
        {
            var uri = new Uri(baseUri, $"Parameters({parameterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteParameter(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetParameterByParameterId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.Parameter> GetParameterByParameterId(int? parameterId = default(int?))
        {
            var uri = new Uri(baseUri, $"Parameters({parameterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetParameterByParameterId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.Parameter>();
        }
        partial void OnUpdateParameter(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateParameter(int? parameterId = default(int?), dynamic parameter = default(dynamic))
        {
            var uri = new Uri(baseUri, $"Parameters({parameterId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(parameter), Encoding.UTF8, "application/json");

            OnUpdateParameter(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteParameterValue(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteParameterValue(string parameterValueCode = default(string))
        {
            var uri = new Uri(baseUri, $"ParameterValues('{HttpUtility.UrlEncode(parameterValueCode)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteParameterValue(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetParameterValueByParameterValueCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Models.Sde.ParameterValue> GetParameterValueByParameterValueCode(string parameterValueCode = default(string))
        {
            var uri = new Uri(baseUri, $"ParameterValues('{HttpUtility.UrlEncode(parameterValueCode)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetParameterValueByParameterValueCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Models.Sde.ParameterValue>();
        }
        partial void OnUpdateParameterValue(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateParameterValue(string parameterValueCode = default(string), dynamic parameterValue = default(dynamic))
        {
            var uri = new Uri(baseUri, $"ParameterValues('{HttpUtility.UrlEncode(parameterValueCode)}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(parameterValue), Encoding.UTF8, "application/json");

            OnUpdateParameterValue(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
