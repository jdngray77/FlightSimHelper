using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="api_params")]
public class ApiParams { 

    [XmlElement(ElementName="airline")] 
    public object Airline { get; set; } 

    [XmlElement(ElementName="fltnum")] 
    public object Fltnum { get; set; } 

    [XmlElement(ElementName="type")] 
    public string Type { get; set; } 

    [XmlElement(ElementName="orig")] 
    public string Orig { get; set; } 

    [XmlElement(ElementName="dest")] 
    public string Dest { get; set; } 

    [XmlElement(ElementName="date")] 
    public int Date { get; set; } 

    [XmlElement(ElementName="dephour")] 
    public int Dephour { get; set; } 

    [XmlElement(ElementName="depmin")] 
    public int Depmin { get; set; } 

    [XmlElement(ElementName="route")] 
    public string Route { get; set; } 

    [XmlElement(ElementName="stehour")] 
    public int Stehour { get; set; } 

    [XmlElement(ElementName="stemin")] 
    public int Stemin { get; set; } 

    [XmlElement(ElementName="reg")] 
    public string Reg { get; set; } 

    [XmlElement(ElementName="fin")] 
    public object Fin { get; set; } 

    [XmlElement(ElementName="selcal")] 
    public string Selcal { get; set; } 

    [XmlElement(ElementName="pax")] 
    public string Pax { get; set; } 

    [XmlElement(ElementName="altn")] 
    public string Altn { get; set; } 

    [XmlElement(ElementName="fl")] 
    public object Fl { get; set; } 

    [XmlElement(ElementName="cpt")] 
    public string Cpt { get; set; } 

    [XmlElement(ElementName="pid")] 
    public int Pid { get; set; } 

    [XmlElement(ElementName="fuelfactor")] 
    public int Fuelfactor { get; set; } 

    [XmlElement(ElementName="manualpayload")] 
    public string Manualpayload { get; set; } 

    [XmlElement(ElementName="manualzfw")] 
    public string Manualzfw { get; set; } 

    [XmlElement(ElementName="taxifuel")] 
    public int Taxifuel { get; set; } 

    [XmlElement(ElementName="minfob")] 
    public int Minfob { get; set; } 

    [XmlElement(ElementName="minfob_units")] 
    public string MinfobUnits { get; set; } 

    [XmlElement(ElementName="minfod")] 
    public int Minfod { get; set; } 

    [XmlElement(ElementName="minfod_units")] 
    public string MinfodUnits { get; set; } 

    [XmlElement(ElementName="melfuel")] 
    public int Melfuel { get; set; } 

    [XmlElement(ElementName="melfuel_units")] 
    public string MelfuelUnits { get; set; } 

    [XmlElement(ElementName="atcfuel")] 
    public int Atcfuel { get; set; } 

    [XmlElement(ElementName="atcfuel_units")] 
    public string AtcfuelUnits { get; set; } 

    [XmlElement(ElementName="wxxfuel")] 
    public int Wxxfuel { get; set; } 

    [XmlElement(ElementName="wxxfuel_units")] 
    public string WxxfuelUnits { get; set; } 

    [XmlElement(ElementName="addedfuel")] 
    public int Addedfuel { get; set; } 

    [XmlElement(ElementName="addedfuel_units")] 
    public string AddedfuelUnits { get; set; } 

    [XmlElement(ElementName="addedfuel_label")] 
    public string AddedfuelLabel { get; set; } 

    [XmlElement(ElementName="tankering")] 
    public int Tankering { get; set; } 

    [XmlElement(ElementName="tankering_units")] 
    public string TankeringUnits { get; set; } 

    [XmlElement(ElementName="flightrules")] 
    public string Flightrules { get; set; } 

    [XmlElement(ElementName="flighttype")] 
    public string Flighttype { get; set; } 

    [XmlElement(ElementName="contpct")] 
    public string Contpct { get; set; } 

    [XmlElement(ElementName="resvrule")] 
    public string Resvrule { get; set; } 

    [XmlElement(ElementName="taxiout")] 
    public int Taxiout { get; set; } 

    [XmlElement(ElementName="taxiin")] 
    public int Taxiin { get; set; } 

    [XmlElement(ElementName="cargo")] 
    public int Cargo { get; set; } 

    [XmlElement(ElementName="origrwy")] 
    public string Origrwy { get; set; } 

    [XmlElement(ElementName="destrwy")] 
    public string Destrwy { get; set; } 

    [XmlElement(ElementName="climb")] 
    public string Climb { get; set; } 

    [XmlElement(ElementName="descent")] 
    public string Descent { get; set; } 

    [XmlElement(ElementName="cruisemode")] 
    public string Cruisemode { get; set; } 

    [XmlElement(ElementName="cruisesub")] 
    public int Cruisesub { get; set; } 

    [XmlElement(ElementName="planformat")] 
    public string Planformat { get; set; } 

    [XmlElement(ElementName="pounds")] 
    public int Pounds { get; set; } 

    [XmlElement(ElementName="navlog")] 
    public int Navlog { get; set; } 

    [XmlElement(ElementName="etops")] 
    public int Etops { get; set; } 

    [XmlElement(ElementName="stepclimbs")] 
    public int Stepclimbs { get; set; } 

    [XmlElement(ElementName="tlr")] 
    public int Tlr { get; set; } 

    [XmlElement(ElementName="notams_opt")] 
    public int NotamsOpt { get; set; } 

    [XmlElement(ElementName="firnot")] 
    public int Firnot { get; set; } 

    [XmlElement(ElementName="maps")] 
    public int Maps { get; set; } 

    [XmlElement(ElementName="turntoflt")] 
    public object Turntoflt { get; set; } 

    [XmlElement(ElementName="turntoapt")] 
    public object Turntoapt { get; set; } 

    [XmlElement(ElementName="turntotime")] 
    public object Turntotime { get; set; } 

    [XmlElement(ElementName="turnfrflt")] 
    public object Turnfrflt { get; set; } 

    [XmlElement(ElementName="turnfrapt")] 
    public object Turnfrapt { get; set; } 

    [XmlElement(ElementName="turnfrtime")] 
    public object Turnfrtime { get; set; } 

    [XmlElement(ElementName="fuelstats")] 
    public object Fuelstats { get; set; } 

    [XmlElement(ElementName="contlabel")] 
    public object Contlabel { get; set; } 

    [XmlElement(ElementName="static_id")] 
    public object StaticId { get; set; } 

    [XmlElement(ElementName="acdata")] 
    public object Acdata { get; set; } 

    [XmlElement(ElementName="acdata_parsed")] 
    public string AcdataParsed { get; set; } 
}