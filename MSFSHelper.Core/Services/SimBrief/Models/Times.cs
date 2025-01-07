using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="times")]
public class Times { 

    [XmlElement(ElementName="est_time_enroute")] 
    public int EstTimeEnroute { get; set; } 

    [XmlElement(ElementName="sched_time_enroute")] 
    public int SchedTimeEnroute { get; set; } 

    [XmlElement(ElementName="sched_out")] 
    public int SchedOut { get; set; } 

    [XmlElement(ElementName="sched_off")] 
    public int SchedOff { get; set; } 

    [XmlElement(ElementName="sched_on")] 
    public int SchedOn { get; set; } 

    [XmlElement(ElementName="sched_in")] 
    public int SchedIn { get; set; } 

    [XmlElement(ElementName="sched_block")] 
    public int SchedBlock { get; set; } 

    [XmlElement(ElementName="est_out")] 
    public int EstOut { get; set; } 

    [XmlElement(ElementName="est_off")] 
    public int EstOff { get; set; } 

    [XmlElement(ElementName="est_on")] 
    public int EstOn { get; set; } 

    [XmlElement(ElementName="est_in")] 
    public int EstIn { get; set; } 

    [XmlElement(ElementName="est_block")] 
    public int EstBlock { get; set; } 

    [XmlElement(ElementName="orig_timezone")] 
    public int OrigTimezone { get; set; } 

    [XmlElement(ElementName="dest_timezone")] 
    public int DestTimezone { get; set; } 

    [XmlElement(ElementName="taxi_out")] 
    public int TaxiOut { get; set; } 

    [XmlElement(ElementName="taxi_in")] 
    public int TaxiIn { get; set; } 

    [XmlElement(ElementName="reserve_time")] 
    public int ReserveTime { get; set; } 

    [XmlElement(ElementName="endurance")] 
    public int Endurance { get; set; } 

    [XmlElement(ElementName="contfuel_time")] 
    public int ContfuelTime { get; set; } 

    [XmlElement(ElementName="etopsfuel_time")] 
    public int EtopsfuelTime { get; set; } 

    [XmlElement(ElementName="extrafuel_time")] 
    public int ExtrafuelTime { get; set; } 
}