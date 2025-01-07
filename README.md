## Simulation Flight Crew Information Terminal

> For simulation use only.
> 
> Only tested with Microsoft Flight Simulator, but should be compatable with FSUIPC7 in it's different flavours.
>
> Only comes with checklists for the FlyByWire A32NX, but checklists are fully data-driven - meaning you can create your own!

This nifty little thing talks to FlightSim using FSUIPC via the FSUIPC Web Socket Server to provide live checklists, which update as you complete the items inside of the simulator.

Work-in-progress, but works really f'n well and has lots of potential!!

From a bit of xml :
```xml
<StateMonitorChecklistItem Name="Battery 1" Action="SET AUTO" VariableName="A32NX_OVHD_ELEC_BAT_1_PB_IS_AUTO" RequiredValue="1"/>
<StateMonitorChecklistItem Name="Battery 2" Action="SET AUTO" VariableName="A32NX_OVHD_ELEC_BAT_2_PB_IS_AUTO" RequiredValue="1"/>
<StateMonitorChecklistItem Name="APU FIRE TEST" Action="PERFORM" VariableName="A32NX_FIRE_TEST_APU" Latching="true" RequiredValue="1"/>
<StateMonitorChecklistItem Name="APU" Action="START" VariableName="A32NX_OVHD_APU_START_PB_IS_AVAILABLE" RequiredValue="1"/>
<StateMonitorChecklistItem Name="PACK 1" Action="ON" VariableName="A32NX_OVHD_COND_PACK_1_PB_IS_ON" RequiredValue="1"/>
<StateMonitorChecklistItem Name="PACK 2" Action="ON" VariableName="A32NX_OVHD_COND_PACK_2_PB_IS_ON" RequiredValue="1"/>
<InformationalChecklistItem Name="INT LIGHTS" Action="AS RQRD" />
```

it creates usable checklists! :

![image](https://github.com/user-attachments/assets/bf34f4c7-7abe-44f7-b0fd-42e6a2b27553)

## What's next?

I'm currently working to create a more fulfilled application using Avalonia under the hood, providing a much more interactive experience.

Aside from that, i'm intergrating with SimBrief to provide crew with data from the flight plan using fully data driven & user editable views - so you'll be able to customise it to your hearts content!

Here's a preview of what the new version will look like!

![image](https://github.com/user-attachments/assets/7ccb319b-478e-40d8-b593-ec46fde61991)

![image](https://github.com/user-attachments/assets/4b64b971-b8c2-48ba-9d96-df5dc5c8cc02)

![image](https://github.com/user-attachments/assets/7a9311a1-5f08-477a-9c74-de7918da476c)
