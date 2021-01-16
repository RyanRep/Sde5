using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sde5.Models.Sde
{
  [Table("DeliveryParameter", Schema = "Delivery")]
  public partial class DeliveryParameter
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeliveryParameterId
    {
      get;
      set;
    }
    public int DeliveryExtractId
    {
      get;
      set;
    }
    public DeliveryExtract DeliveryExtract { get; set; }
    public int ParameterId
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string Value
    {
      get;
      set;
    }
    public string ParameterValueCode
    {
      get;
      set;
    }
    public ParameterValue ParameterValue { get; set; }
  }
}
