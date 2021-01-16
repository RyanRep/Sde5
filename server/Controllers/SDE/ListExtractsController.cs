using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace Sde5.Controllers.Sde
{
  using Models;
  using Data;
  using Models.Sde;

  [ODataRoutePrefix("odata/SDE/ListExtracts")]
  [Route("mvc/odata/SDE/ListExtracts")]
  public partial class ListExtractsController : ODataController
  {
    private Data.SdeContext context;

    public ListExtractsController(Data.SdeContext context)
    {
      this.context = context;
    }
    // GET /odata/Sde/ListExtracts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Sde.ListExtract> GetListExtracts()
    {
      var items = this.context.ListExtracts.AsNoTracking().AsQueryable<Models.Sde.ListExtract>();
      this.OnListExtractsRead(ref items);

      return items;
    }

    partial void OnListExtractsRead(ref IQueryable<Models.Sde.ListExtract> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ListId}")]
    public SingleResult<ListExtract> GetListExtract(int key)
    {
        var items = this.context.ListExtracts.AsNoTracking().Where(i=>i.ListId == key);
        return SingleResult.Create(items);
    }
  }
}
