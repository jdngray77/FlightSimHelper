using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="runway")]
public class Runway { 

    [XmlElement(ElementName="identifier")] 
    public string Identifier { get; set; } 

    [XmlElement(ElementName="length")] 
    public int Length { get; set; } 

    [XmlElement(ElementName="length_tora")] 
    public int LengthTora { get; set; } 

    [XmlElement(ElementName="length_toda")] 
    public int LengthToda { get; set; } 

    [XmlElement(ElementName="length_asda")] 
    public int LengthAsda { get; set; } 

    [XmlElement(ElementName="length_lda")] 
    public int LengthLda { get; set; } 

    [XmlElement(ElementName="elevation")] 
    public int Elevation { get; set; } 

    [XmlElement(ElementName="gradient")] 
    public double Gradient { get; set; } 

    [XmlElement(ElementName="true_course")] 
    public int TrueCourse { get; set; } 

    [XmlElement(ElementName="magnetic_course")] 
    public int MagneticCourse { get; set; } 

    [XmlElement(ElementName="headwind_component")] 
    public int HeadwindComponent { get; set; } 

    [XmlElement(ElementName="crosswind_component")] 
    public int CrosswindComponent { get; set; } 

    [XmlElement(ElementName="ils_frequency")] 
    public string IlsFrequency { get; set; } 

    [XmlElement(ElementName="flap_setting")] 
    public int FlapSetting { get; set; } 

    [XmlElement(ElementName="thrust_setting")] 
    public string ThrustSetting { get; set; } 

    [XmlElement(ElementName="bleed_setting")] 
    public string BleedSetting { get; set; } 

    [XmlElement(ElementName="anti_ice_setting")] 
    public string AntiIceSetting { get; set; } 

    [XmlElement(ElementName="flex_temperature")] 
    public int FlexTemperature { get; set; } 

    [XmlElement(ElementName="max_temperature")] 
    public int MaxTemperature { get; set; } 

    [XmlElement(ElementName="max_weight")] 
    public int MaxWeight { get; set; } 

    [XmlElement(ElementName="limit_code")] 
    public string LimitCode { get; set; } 

    [XmlElement(ElementName="limit_obstacle")] 
    public object LimitObstacle { get; set; } 

    [XmlElement(ElementName="speeds_v1")] 
    public int SpeedsV1 { get; set; } 

    [XmlElement(ElementName="speeds_vr")] 
    public int SpeedsVr { get; set; } 

    [XmlElement(ElementName="speeds_v2")] 
    public int SpeedsV2 { get; set; } 

    [XmlElement(ElementName="speeds_other")] 
    public int SpeedsOther { get; set; } 

    [XmlElement(ElementName="speeds_other_id")] 
    public string SpeedsOtherId { get; set; } 

    [XmlElement(ElementName="distance_decide")] 
    public int DistanceDecide { get; set; } 

    [XmlElement(ElementName="distance_reject")] 
    public int DistanceReject { get; set; } 

    [XmlElement(ElementName="distance_margin")] 
    public int DistanceMargin { get; set; } 

    [XmlElement(ElementName="distance_continue")] 
    public int DistanceContinue { get; set; } 

    [XmlElement(ElementName="max_weight_dry")] 
    public int MaxWeightDry { get; set; } 

    [XmlElement(ElementName="max_weight_wet")] 
    public int MaxWeightWet { get; set; } 
}