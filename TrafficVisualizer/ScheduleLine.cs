using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrafficVisualizer
{
    public class ScheduleLine
    {
        public string? OperatorColor { get; set; }
        public string? AirlineCallsign { get; set; }
        public string? FlightNumber { get; set; }
        public string? AirplaneType { get; set; }
        public string? FromICAO { get; set; }
        public string? ToICAO { get; set; }
        public string? ApproachTime { get; set; }
        public string? DepartureTime { get; set; }
        public string? ApproachAltitude { get; set; }
        public string? Special { get; set; }
        public string? Registration { get; set; }

        public static ScheduleLine? Parse(string line)
        {
            var m = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)").Matches(line);
            if (m.Count > 9) 
                return new ScheduleLine
                {
                    OperatorColor = m[0].Groups[2].Value,
                    AirlineCallsign = m[1].Groups[2].Value,
                    FlightNumber = m[2].Groups[2].Value,
                    AirplaneType = m[3].Groups[2].Value,
                    FromICAO = m[4].Groups[2].Value,
                    ToICAO = m[5].Groups[2].Value,
                    ApproachTime = m[6].Groups[2].Value,
                    DepartureTime = m[7].Groups[2].Value,
                    ApproachAltitude = m[8].Groups[2].Value,
                    Special = m[9].Groups[2].Value
                };
            else return null;
        }
    }
}
