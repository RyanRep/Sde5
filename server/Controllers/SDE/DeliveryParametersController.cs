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

  [ODataRoutePrefix("odata/SDE/DeliveryParameters")]
  [Route("mvc/odata/SDE/DeliveryParameters")]
  public partial class DeliveryParametersController : ODataController
  {
    private Data.SdeContext context;

    public DeliveryParametersController(Data.SdeContext context)
    {
      this.context = context;
    }
    // GET /odata/Sde/DeliveryParameters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Sde.DeliveryParameter> GetDeliveryParameters()
    {
      var items = this.context.DeliveryParameters.AsQueryable<Models.Sde.DeliveryParameter>();
      this.OnDeliveryParametersRead(ref items);

      return items;
    }

    partial void OnDeliveryParametersRead(ref IQueryable<Models.Sde.DeliveryParameter> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{DeliveryParameterId}")]
    public SingleResult<DeliveryParameter> GetDeliveryParameter(int key)
    {
        var items = this.context.DeliveryParameters.Where(i=>i.DeliveryParameterId == key);
        return SingleResult.Create(items);
    }
    partial void OnDeliveryParameterDeleted(Models.Sde.DeliveryParameter item);
    partial void OnAfterDeliveryParameterDeleted(Models.Sde.DeliveryParameter item);

    [HttpDelete("{DeliveryParameterId}")]
    public IActionResult DeleteDeliveryParameter(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.DeliveryParameters
                .Where(i => i.DeliveryParameterId == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDeliveryParameterDeleted(item);
            this.context.DeliveryParameters.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDeliveryParameterDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeliveryParameterUpdated(Models.Sde.DeliveryParameter item);
    partial void OnAfterDeliveryParameterUpdated(Models.Sde.DeliveryParameter item);

    [HttpPut("{DeliveryParameterId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDeliveryParameter(int key, [FromBody]Models.Sde.DeliveryParameter newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DeliveryParameterId != key))
            {
                return BadRequest();
            }

            this.OnDeliveryParameterUpdated(newItem);
            this.context.DeliveryParameters.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeliveryParameters.Where(i => i.DeliveryParameterId == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DeliveryExtract,Parameter,ParameterValue");
            this.OnAfterDeliveryParameterUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{DeliveryParameterId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDeliveryParameter(int key, [FromBody]Delta<Models.Sde.DeliveryParameter> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.DeliveryParameters.Where(i => i.DeliveryParameterId == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDeliveryParameterUpdated(item);
            this.context.DeliveryParameters.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.DeliveryParameters.Where(i => i.DeliveryParameterId == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DeliveryExtract,Parameter,ParameterValue");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDeliveryParameterCreated(Models.Sde.DeliveryParameter item);
    partial void OnAfterDeliveryParameterCreated(Models.Sde.DeliveryParameter item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Sde.DeliveryParameter item)
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

            this.OnDeliveryParameterCreated(item);
            this.context.DeliveryParameters.Add(item);
            this.context.SaveChanges();

            var key = item.DeliveryParameterId;

            var itemToReturn = this.context.DeliveryParameters.Where(i => i.DeliveryParameterId == key);

            Request.QueryString = Request.QueryString.Add("$expand", "DeliveryExtract,Parameter,ParameterValue");

            this.OnAfterDeliveryParameterCreated(item);

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
