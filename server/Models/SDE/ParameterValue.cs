using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sde5.Models.Sde
{
  [Table("ParameterValue", Schema = "Extract")]
  public partial class ParameterValue
  {
    [Key]
    public string ParameterValueCode
    {
      get;
      set;
    }

    public IEnumerable<DeliveryParameter> DeliveryParameters { get; set; }
    public string name
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public bool IsActive
    {
      get;
      set;
    }
  }
}
