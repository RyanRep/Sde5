using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sde5.Models.Sde
{
  [Table("DeliveryExtract", Schema = "Delivery")]
  public partial class DeliveryExtract
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeliveryExtractId
    {
      get;
      set;
    }

    public IEnumerable<DeliveryParameter> DeliveryParameters { get; set; }
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
    public int ExtractId
    {
      get;
      set;
    }
    public Extract Extract { get; set; }
    public bool? DeliverAsSet
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
