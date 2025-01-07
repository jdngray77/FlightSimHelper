using System.Xml.Serialization;

namespace MSFSHelper.Core.SimBrief.Models;

[XmlRoot(ElementName="fms_downloads")]
public class FmsDownloads { 

    [XmlElement(ElementName="directory")] 
    public string Directory { get; set; } 

    [XmlElement(ElementName="pdf")] 
    public Pdf Pdf { get; set; } 

    [XmlElement(ElementName="abx")] 
    public Abx Abx { get; set; } 

    [XmlElement(ElementName="a3e")] 
    public A3e A3e { get; set; } 

    [XmlElement(ElementName="crx")] 
    public Crx Crx { get; set; } 

    [XmlElement(ElementName="cra")] 
    public Cra Cra { get; set; } 

    [XmlElement(ElementName="psx")] 
    public Psx Psx { get; set; } 

    [XmlElement(ElementName="efb")] 
    public Efb Efb { get; set; } 

    [XmlElement(ElementName="ef2")] 
    public Ef2 Ef2 { get; set; } 

    [XmlElement(ElementName="bbs")] 
    public Bbs Bbs { get; set; } 

    [XmlElement(ElementName="csf")] 
    public Csf Csf { get; set; } 

    [XmlElement(ElementName="ftr")] 
    public Ftr Ftr { get; set; } 

    [XmlElement(ElementName="gtn")] 
    public Gtn Gtn { get; set; } 

    [XmlElement(ElementName="vm5")] 
    public Vm5 Vm5 { get; set; } 

    [XmlElement(ElementName="vmx")] 
    public Vmx Vmx { get; set; } 

    [XmlElement(ElementName="ffa")] 
    public Ffa Ffa { get; set; } 

    [XmlElement(ElementName="fsc")] 
    public Fsc Fsc { get; set; } 

    [XmlElement(ElementName="fs9")] 
    public Fs9 Fs9 { get; set; } 

    [XmlElement(ElementName="mfs")] 
    public Mfs Mfs { get; set; } 

    [XmlElement(ElementName="mfn")] 
    public Mfn Mfn { get; set; } 

    [XmlElement(ElementName="m24")] 
    public M24 M24 { get; set; } 

    [XmlElement(ElementName="fsl")] 
    public Fsl Fsl { get; set; } 

    [XmlElement(ElementName="fsx")] 
    public Fsx Fsx { get; set; } 

    [XmlElement(ElementName="fsn")] 
    public Fsn Fsn { get; set; } 

    [XmlElement(ElementName="gfs")] 
    public Gfs Gfs { get; set; } 

    [XmlElement(ElementName="kml")] 
    public Kml Kml { get; set; } 

    [XmlElement(ElementName="ify")] 
    public Ify Ify { get; set; } 

    [XmlElement(ElementName="i74")] 
    public I74 I74 { get; set; } 

    [XmlElement(ElementName="ifa")] 
    public Ifa Ifa { get; set; } 

    [XmlElement(ElementName="ifw")] 
    public Ifw Ifw { get; set; } 

    [XmlElement(ElementName="inb")] 
    public Inb Inb { get; set; } 

    [XmlElement(ElementName="ivo")] 
    public Ivo Ivo { get; set; } 

    [XmlElement(ElementName="xvd")] 
    public Xvd Xvd { get; set; } 

    [XmlElement(ElementName="xvp")] 
    public Xvp Xvp { get; set; } 

    [XmlElement(ElementName="ixg")] 
    public Ixg Ixg { get; set; } 

    [XmlElement(ElementName="jar")] 
    public Jar Jar { get; set; } 

    [XmlElement(ElementName="jhe")] 
    public Jhe Jhe { get; set; } 

    [XmlElement(ElementName="jfb")] 
    public Jfb Jfb { get; set; } 

    [XmlElement(ElementName="mdr")] 
    public Mdr Mdr { get; set; } 

    [XmlElement(ElementName="mda")] 
    public Mda Mda { get; set; } 

    [XmlElement(ElementName="lvd")] 
    public Lvd Lvd { get; set; } 

    [XmlElement(ElementName="mjc")] 
    public Mjc Mjc { get; set; } 

    [XmlElement(ElementName="mjq")] 
    public Mjq Mjq { get; set; } 

    [XmlElement(ElementName="atm")] 
    public Atm Atm { get; set; } 

    [XmlElement(ElementName="mvz")] 
    public Mvz Mvz { get; set; } 

    [XmlElement(ElementName="vms")] 
    public Vms Vms { get; set; } 

    [XmlElement(ElementName="pmo")] 
    public Pmo Pmo { get; set; } 

    [XmlElement(ElementName="pmr")] 
    public Pmr Pmr { get; set; } 

    [XmlElement(ElementName="pmw")] 
    public Pmw Pmw { get; set; } 

    [XmlElement(ElementName="pgt")] 
    public Pgt Pgt { get; set; } 

    [XmlElement(ElementName="mga")] 
    public Mga Mga { get; set; } 

    [XmlElement(ElementName="psm")] 
    public Psm Psm { get; set; } 

    [XmlElement(ElementName="qty")] 
    public Qty Qty { get; set; } 

    [XmlElement(ElementName="rmd")] 
    public Rmd Rmd { get; set; } 

    [XmlElement(ElementName="sbr")] 
    public Sbr Sbr { get; set; } 

    [XmlElement(ElementName="sfp")] 
    public Sfp Sfp { get; set; } 

    [XmlElement(ElementName="tdg")] 
    public Tdg Tdg { get; set; } 

    [XmlElement(ElementName="tfd")] 
    public Tfd Tfd { get; set; } 

    [XmlElement(ElementName="ufc")] 
    public Ufc Ufc { get; set; } 

    [XmlElement(ElementName="vas")] 
    public Vas Vas { get; set; } 

    [XmlElement(ElementName="vfp")] 
    public Vfp Vfp { get; set; } 

    [XmlElement(ElementName="wae")] 
    public Wae Wae { get; set; } 

    [XmlElement(ElementName="xfm")] 
    public Xfm Xfm { get; set; } 

    [XmlElement(ElementName="xpe")] 
    public Xpe Xpe { get; set; } 

    [XmlElement(ElementName="xpn")] 
    public Xpn Xpn { get; set; } 

    [XmlElement(ElementName="xp9")] 
    public Xp9 Xp9 { get; set; } 

    [XmlElement(ElementName="zbo")] 
    public Zbo Zbo { get; set; } 
}