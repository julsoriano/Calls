using System.Collections.Generic;
using System.Web.Mvc;

public class StatesDictionary
{
    public static SelectList StateSelectList
    {
        get { return new SelectList(StateDictionary, "Value", "Key"); }
    }

    public static readonly IDictionary<string, string>
        StateDictionary = new Dictionary<string, string> { 
      {"Choose the State...",""}
    , { "Alabama", "AL" }
    , { "Alaska", "AK" }
    , { "Arizona", "AZ" }
    , { "Arkansas", "AR" }
    , { "California", "CA" }
    , { "Colorado", "CO" }
    , { "Connecticut", "CT" }
    , { "Delaware", "DE" }
    , { "District of Columbia", "DC" }
    , { "Florida", "FL" }
    , { "Georgia", "GA" }
    , { "Hawaii", "HI" }
    , { "Idaho", "ID" }
    , { "Illinois", "IL" }
    , { "Indiana", "IN" }
    , { "Iowa", "IA" }
    , { "Kansas", "KS" }
    , { "Kentucky", "KY" }
    , { "Louisiana", "LA" }
    , { "Maine", "ME" }
    , { "Maryland", "MD" }
    , { "Massachusetts", "MA" }
    , { "Michigan", "MI" }
    , { "Minnesota", "MN" }
    , { "Mississippi", "MS" }
    , { "Missouri", "MO" }
    , { "Montana", "MT" }
    , { "Nebraska", "NE" }
    , { "Nevada", "NV" }
    , { "New Hampshire", "NH" }
    , { "New Jersey", "NJ" }
    , { "New Mexico", "NM" }
    , { "New York", "NY" }
    , { "North Carolina", "NC" }
    , { "North Dakota", "ND" }
    , { "Ohio", "OH" }
    , { "Oklahoma", "OK" }
    , { "Oregon", "OR" }
    , { "Pennsylvania", "PA" }
    , { "Rhode Island", "RI" }
    , { "South Carolina", "SC" }
    , { "South Dakota", "SD" }
    , { "Tennessee", "TN" }
    , { "Texas", "TX" }
    , { "Utah", "UT" }
    , { "Vermont", "VT" }
    , { "Virginia", "VA" }
    , { "Washington", "WA" }
    , { "West Virginia", "WV" }
    , { "Wisconsin", "WI" }
    , { "Wyoming", "WY" }    
    // more states 
    };
}