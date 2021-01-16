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

  [ODataRoutePrefix("odata/SDE/DeliveryExtracts")]
  [Route("mvc/odata/SDE/DeliveryExtracts")]
  public partial class DeliveryExtractsController : ODataController
  {
    private Data.SdeContext context;

    public DeliveryExtractsController(Data.SdeContext context)
    {
      this.context = context;
    }
    // GET /odata/Sde/DeliveryExtracts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Sde.DeliveryExtract> GetDeliveryExtracts()
    {
      var items = this.context.DeliveryExtracts.AsQueryable<Models.Sde.DeliveryExtract>();
      this.OnDeliveryExtractsRead(ref items);

      return items;
    }

    partial void OnDeliveryExtractsRead(ref IQueryable<Models.Sde.DeliveryExtract> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{DeliveryExtractId}")]
    public SingleResult<DeliveryExtract> GetDeliveryExtract(int key)
    {
        var items = this.context.DeliveryExtracts.Where(i=>i.DeliveryExtractId == key);
        return SingleResult.Create(items);
    }
    partial void OnDeliveryExtractDeleted(Models.Sde.DeliveryExtract item);
    partial void OnAfterDeliveryExtractDeleted(Models.Sde.DeliveryExtract item);

    [HttpDelete("{DeliveryExtractId}")]
    public IActionResult DeleteDeliveryExtract(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.DeliveryExtracts
                .Where(i => i.DeliveryExtractId == key)
                .Include(i => i.DeliveryParameters)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDeliveryExtractDeleted(item);
            this.context.DeliveryExtracts.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDeliveryExtractDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeliveryExtractUpdated(Models.Sde.DeliveryExtract item);
    partial void OnAfterDeliveryExtractUpdated(Models.Sde.DeliveryExtract item);

    [HttpPut("{DeliveryExtractId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDeliveryExtract(int key, [FromBody]Models.Sde.DeliveryExtract newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DeliveryExtractId != key))
            {
                return BadRequest();
            }

            this.OnDeliveryExtractUpdated(newItem);
            this.context.DeliveryExtracts.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeliveryExtracts.Where(i => i.DeliveryExtractId == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Extract");
            this.OnAfterDeliveryExtractUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{DeliveryExtractId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDeliveryExtract(int key, [FromBody]Delta<Models.Sde.DeliveryExtract> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.DeliveryExtracts.Where(i => i.DeliveryExtractId == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDeliveryExtractUpdated(item);
            this.context.DeliveryExtracts.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeliveryExtracts.Where(i => i.DeliveryExtractId == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Extract");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeliveryExtractCreated(Models.Sde.DeliveryExtract item);
    partial void OnAfterDeliveryExtractCreated(Models.Sde.DeliveryExtract item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Sde.DeliveryExtract item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDeliveryExtractCreated(item);
            this.context.DeliveryExtracts.Add(item);
            this.context.SaveChanges();

            var key = item.DeliveryExtractId;

            var itemToReturn = this.context.DeliveryExtracts.Where(i => i.DeliveryExtractId == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Extract");

            this.OnAfterDeliveryExtractCreated(item);

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
