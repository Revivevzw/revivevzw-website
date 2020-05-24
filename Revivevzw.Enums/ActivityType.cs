using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Revivevzw.Enums
{
  [DataContract]
  public enum ActivityType
  {
    Mission = 35,
    Scouting = 107,
    Concert = 36,
    Fundraising = 36
  }
}
