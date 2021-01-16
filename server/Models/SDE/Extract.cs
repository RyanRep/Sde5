using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sde5.Models.Sde
{
  [Table("Extract", Schema = "Extract")]
  public partial class Extract
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExtractId
    {
      get;
      set;
    }

    public IEnumerable<Parameter> Parameters { get; set; }
    public IEnumerable<DeliveryExtract> DeliveryExtracts { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public string ExternalCode
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
