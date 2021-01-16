using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sde5.Models.Sde
{
  [Table("ListExtract", Schema = "Extract")]
  public partial class ListExtract
  {
    [Key]
    public int ListId
    {
      get;
      set;
    }
    public int ExtractId
    {
      get;
      set;
    }
  }
}
