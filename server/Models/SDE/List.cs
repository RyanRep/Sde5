using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sde5.Models.Sde
{
  [Table("List", Schema = "Extract")]
  public partial class List
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ListId
    {
      get;
      set;
    }
    public string Name
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
