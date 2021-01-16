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

  [ODataRoutePrefix("odata/SDE/ParameterValues")]
  [Route("mvc/odata/SDE/ParameterValues")]
  public partial class ParameterValuesController : ODataController
  {
    private Data.SdeContext context;

    public ParameterValuesController(Data.SdeContext context)
    {
      this.context = context;
    }
    // GET /odata/Sde/ParameterValues
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Sde.ParameterValue> GetParameterValues()
    {
      var items = this.context.ParameterValues.AsQueryable<Models.Sde.ParameterValue>();
      this.OnParameterValuesRead(ref items);

      return items;
    }

    partial void OnParameterValuesRead(ref IQueryable<Models.Sde.ParameterValue> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ParameterValueCode}")]
    public SingleResult<ParameterValue> GetParameterValue(string key)
    {
        var items = this.context.ParameterValues.Where(i=>i.ParameterValueCode == key);
        return SingleResult.Create(items);
    }
    partial void OnParameterValueDeleted(Models.Sde.ParameterValue item);
    partial void OnAfterParameterValueDeleted(Models.Sde.ParameterValue item);

    [HttpDelete("{ParameterValueCode}")]
    public IActionResult DeleteParameterValue(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.ParameterValues
                .Where(i => i.ParameterValueCode == key)
                .Include(i => i.DeliveryParameters)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnParameterValueDeleted(item);
            this.context.ParameterValues.Remove(item);
            this.context.SaveChanges();
            this.OnAfterParameterValueDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnParameterValueUpdated(Models.Sde.ParameterValue item);
    partial void OnAfterParameterValueUpdated(Models.Sde.ParameterValue item);

    [HttpPut("{ParameterValueCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutParameterValue(string key, [FromBody]Models.Sde.ParameterValue newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ParameterValueCode != key))
            {
                return BadRequest();
            }

            this.OnParameterValueUpdated(newItem);
            this.context.ParameterValues.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.ParameterValues.Where(i => i.ParameterValueCode == key);
            this.OnAfterParameterValueUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ParameterValueCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchParameterValue(string key, [FromBody]Delta<Models.Sde.ParameterValue> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.ParameterValues.Where(i => i.ParameterValueCode == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnParameterValueUpdated(item);
            this.context.ParameterValues.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.ParameterValues.Where(i => i.ParameterValueCode == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnParameterValueCreated(Models.Sde.ParameterValue item);
    partial void OnAfterParameterValueCreated(Models.Sde.ParameterValue item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Sde.ParameterValue item)
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

            this.OnParameterValueCreated(item);
            this.context.ParameterValues.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Sde/ParameterValues/{item.ParameterValueCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
