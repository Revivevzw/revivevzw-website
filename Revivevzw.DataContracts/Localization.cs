using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Revivevzw.DataContracts
{
  [DataContract]
  public class Localization
  {
    public string Nl { get; set; }
    public string Fr { get; set; }
    public string En { get; set; }
  }
}
