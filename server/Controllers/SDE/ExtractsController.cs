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

  [ODataRoutePrefix("odata/SDE/Extracts")]
  [Route("mvc/odata/SDE/Extracts")]
  public partial class ExtractsController : ODataController
  {
    private Data.SdeContext context;

    public ExtractsController(Data.SdeContext context)
    {
      this.context = context;
    }
    // GET /odata/Sde/Extracts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Sde.Extract> GetExtracts()
    {
      var items = this.context.Extracts.AsQueryable<Models.Sde.Extract>();
      this.OnExtractsRead(ref items);

      return items;
    }

    partial void OnExtractsRead(ref IQueryable<Models.Sde.Extract> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ExtractId}")]
    public SingleResult<Extract> GetExtract(int key)
    {
        var items = this.context.Extracts.Where(i=>i.ExtractId == key);
        return SingleResult.Create(items);
    }
    partial void OnExtractDeleted(Models.Sde.Extract item);
    partial void OnAfterExtractDeleted(Models.Sde.Extract item);

    [HttpDelete("{ExtractId}")]
    public IActionResult DeleteExtract(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Extracts
                .Where(i => i.ExtractId == key)
                .Include(i => i.Parameters)
                .Include(i => i.DeliveryExtracts)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnExtractDeleted(item);
            this.context.Extracts.Remove(item);
            this.context.SaveChanges();
            this.OnAfterExtractDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnExtractUpdated(Models.Sde.Extract item);
    partial void OnAfterExtractUpdated(Models.Sde.Extract item);

    [HttpPut("{ExtractId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutExtract(int key, [FromBody]Models.Sde.Extract newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ExtractId != key))
            {
                return BadRequest();
            }

            this.OnExtractUpdated(newItem);
            this.context.Extracts.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Extracts.Where(i => i.ExtractId == key);
            this.OnAfterExtractUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ExtractId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchExtract(int key, [FromBody]Delta<Models.Sde.Extract> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Extracts.Where(i => i.ExtractId == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnExtractUpdated(item);
            this.context.Extracts.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Extracts.Where(i => i.ExtractId == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnExtractCreated(Models.Sde.Extract item);
    partial void OnAfterExtractCreated(Models.Sde.Extract item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Sde.Extract item)
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

            this.OnExtractCreated(item);
            this.context.Extracts.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Sde/Extracts/{item.ExtractId}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
