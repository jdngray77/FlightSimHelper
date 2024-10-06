Talks to FlightSim using FSUIPC, via FSUIPC Web Socket Server, to provide live checklists.

Heavily work-in-progress but works really f'n well and has lots of potential!!

From a bit of xml :
```xml
<StateMonitorChecklistItem Name="Battery 1" Action="SET AUTO" VariableName="A32NX_OVHD_ELEC_BAT_1_PB_IS_AUTO" RequiredValue="1"/>
<StateMonitorChecklistItem Name="Battery 2" Action="SET AUTO" VariableName="A32NX_OVHD_ELEC_BAT_2_PB_IS_AUTO" RequiredValue="1"/>
<StateMonitorChecklistItem Name="APU FIRE TEST" Action="PERFORM" VariableName="A32NX_FIRE_TEST_APU" Latching="true" RequiredValue="1"/>
<StateMonitorChecklistItem Name="APU" Action="START" VariableName="A32NX_OVHD_APU_START_PB_IS_AVAILABLE" RequiredValue="1"/>
<StateMonitorChecklistItem Name="PACK 1" Action="ON" VariableName="A32NX_OVHD_COND_PACK_1_PB_IS_ON" RequiredValue="1"/>
<StateMonitorChecklistItem Name="PACK 2" Action="ON" VariableName="A32NX_OVHD_COND_PACK_2_PB_IS_ON" RequiredValue="1"/>
```

it creates usable checklists! :

![image](https://github.com/user-attachments/assets/bf34f4c7-7abe-44f7-b0fd-42e6a2b27553)
