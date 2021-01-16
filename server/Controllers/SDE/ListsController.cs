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

  [ODataRoutePrefix("odata/SDE/Lists")]
  [Route("mvc/odata/SDE/Lists")]
  public partial class ListsController : ODataController
  {
    private Data.SdeContext context;

    public ListsController(Data.SdeContext context)
    {
      this.context = context;
    }
    // GET /odata/Sde/Lists
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Sde.List> GetLists()
    {
      var items = this.context.Lists.AsQueryable<Models.Sde.List>();
      this.OnListsRead(ref items);

      return items;
    }

    partial void OnListsRead(ref IQueryable<Models.Sde.List> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ListId}")]
    public SingleResult<List> GetList(int key)
    {
        var items = this.context.Lists.Where(i=>i.ListId == key);
        return SingleResult.Create(items);
    }
    partial void OnListDeleted(Models.Sde.List item);
    partial void OnAfterListDeleted(Models.Sde.List item);

    [HttpDelete("{ListId}")]
    public IActionResult DeleteList(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Lists
                .Where(i => i.ListId == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnListDeleted(item);
            this.context.Lists.Remove(item);
            this.context.SaveChanges();
            this.OnAfterListDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnListUpdated(Models.Sde.List item);
    partial void OnAfterListUpdated(Models.Sde.List item);

    [HttpPut("{ListId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutList(int key, [FromBody]Models.Sde.List newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ListId != key))
            {
                return BadRequest();
            }

            this.OnListUpdated(newItem);
            this.context.Lists.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Lists.Where(i => i.ListId == key);
            this.OnAfterListUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ListId}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchList(int key, [FromBody]Delta<Models.Sde.List> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Lists.Where(i => i.ListId == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnListUpdated(item);
            this.context.Lists.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Lists.Where(i => i.ListId == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnListCreated(Models.Sde.List item);
    partial void OnAfterListCreated(Models.Sde.List item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Sde.List item)
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

            this.OnListCreated(item);
            this.context.Lists.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Sde/Lists/{item.ListId}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
