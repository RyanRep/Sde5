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

  [ODataRoutePrefix("odata/SDE/Parameters")]
  [Route("mvc/odata/SDE/Parameters")]
  public partial class ParametersController : ODataController
  {
    private Data.SdeContext context;

    public ParametersController(Data.SdeContext context)
    {
      this.context = context;
    }
    // GET /odata/Sde/Parameters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Sde.Parameter> GetParameters()
    {
      var items = this.context.Parameters.AsQueryable<Models.Sde.Parameter>();
      this.OnParametersRead(ref items);

      return items;
    }

    partial void OnParametersRead(ref IQueryable<Models.Sde.Parameter> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ParameterId}")]
    public SingleResult<Parameter> GetParameter(int key)
    {
        var items = this.context.Parameters.Where(i=>i.ParameterId == key);
        return SingleResult.Create(items);
    }
    partial void OnParameterDeleted(Models.Sde.Parameter item);
    partial void OnAfterParameterDeleted(Models.Sde.Parameter item);

    [HttpDelete("{ParameterId}")]
    public IActionResult DeleteParameter(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Parameters
                .Where(i => i.ParameterId == key)
                .Include(i => i.DeliveryParameters)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnParameterDeleted(item);
            this.context.Parameters.Remove(item);
            this.context.SaveChanges();
            this.OnAfterParameterDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnParameterUpdated(Models.Sde.Parameter item);
    partial void OnAfterParameterUpdated(Models.Sde.Parameter item);

    [HttpPut("{ParameterId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutParameter(int key, [FromBody]Models.Sde.Parameter newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ParameterId != key))
            {
                return BadRequest();
            }

            this.OnParameterUpdated(newItem);
            this.context.Parameters.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Parameters.Where(i => i.ParameterId == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Extract");
            this.OnAfterParameterUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ParameterId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchParameter(int key, [FromBody]Delta<Models.Sde.Parameter> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Parameters.Where(i => i.ParameterId == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnParameterUpdated(item);
            this.context.Parameters.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Parameters.Where(i => i.ParameterId == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Extract");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnParameterCreated(Models.Sde.Parameter item);
    partial void OnAfterParameterCreated(Models.Sde.Parameter item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Sde.Parameter item)
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

            this.OnParameterCreated(item);
            this.context.Parameters.Add(item);
            this.context.SaveChanges();

            var key = item.ParameterId;

            var itemToReturn = this.context.Parameters.Where(i => i.ParameterId == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Extract");

            this.OnAfterParameterCreated(item);

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
