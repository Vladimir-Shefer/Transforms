namespace Transforms
{
    public abstract class Data_Carrier_Base
    {
        public All_Params param;
    }

    public class Data_Carrier_Int : Data_Carrier_Base
    {
        public int value;
    }

    public class Data_Carrier_Int_List : Data_Carrier_Base
    {
        public List<int> values = new List<int>();
    }
    public class Data_Carrier_Bool : Data_Carrier_Base
    {
        public bool value;  
    }

    public enum All_Params
    {
        id,
        command,
        unknown,
        state,
        sCurrentAnalogData_avg_adc_value,
        bru_127,
        bru_220,
        time_logic,
        _FLASH_ID_VERSIYA_H,      // uint16_t id_versiya_h            // Версия ПО
        _FLASH_ID_VERSIYA_L,      // uint16_t id_versiya_l            // Версия ПО
        _FLASH_NUMBER_BLOK,        // uint16_t number_blok            // Номер блока
        _FLASH_DEV_TYPE,         //uint16_t device_config.device_type;      //тип блока //device_type_t device_type;   //тип блока
        _FLASH_PROT_PT100_0_ENABLE,
        _FLASH_PROT_PT100_1_ENABLE,
        _FLASH_PROT_PT100_2_ENABLE,
        _FLASH_WARN_PT100_0_ENABLE,
        _FLASH_WARN_PT100_1_ENABLE,
        _FLASH_WARN_PT100_2_ENABLE,
        _FLASH_PROT_V4_20_0_ENABLE,
        _FLASH_PROT_V4_20_1_ENABLE,
        _FLASH_WARN_V4_20_0_ENABLE,
        _FLASH_WARN_V4_20_1_ENABLE,
        _FLASH_PROT_WRONG_CON_ENABLE,
        _FLASH_MIN_CURRENT,
        _FLASH_PROT_PT100_0_SETPOINT,
        _FLASH_PROT_PT100_1_SETPOINT,
        _FLASH_PROT_PT100_2_SETPOINT,
        _FLASH_WARN_PT100_0_SETPOINT,
        _FLASH_WARN_PT100_1_SETPOINT,
        _FLASH_WARN_PT100_2_SETPOINT,
        _FLASH_PROT_V4_20_0_SETPOINT,
        _FLASH_PROT_V4_20_1_SETPOINT,
        _FLASH_WARN_V4_20_0_SETPOINT,
        _FLASH_WARN_V4_20_1_SETPOINT,
        _FLASH_RS485_ADDRESS,
        _FLASH_RS485_SPEED,
        _FLASH_RATIOS_MUL0,
        _FLASH_RATIOS_MUL1,
        _FLASH_RATIOS_MUL2,
        _FLASH_RATIOS_MUL3,
        _FLASH_RATIOS_MUL4,
        _FLASH_RATIOS_MUL5,
        _FLASH_RATIOS_MUL6,
        _FLASH_RATIOS_MUL7,
        _FLASH_RATIOS_MUL8,
        _FLASH_RATIOS_GND0,
        _FLASH_RATIOS_GND1,
        _FLASH_RATIOS_GND2,
        _FLASH_RATIOS_GND3,
        _FLASH_RATIOS_GND4,
        _FLASH_RATIOS_GND5,
        _FLASH_RATIOS_GND6,
        _FLASH_RATIOS_GND7,
        _FLASH_RATIOS_GND8,
        _FLASH_CURRENT_MUL,
        _FLASH_CT_MUL,
        _FLASH_WRONG_CON_MAX_CURRENT,
        _FLASH_WRONG_CON_SW_CURRENT,
        _FLASH_ASSYMETRY_ENABLE,
        _FLASH_ASSYMETRY_SETPOINT,
        _FLASH_ASSYMETRY_TIME,
        ADCdata_currentA,
        ADCdata_currentB,
        ADCdata_currentC,
        ADCdata_currentD,
        ADCdata_currentAVG,
        ADCdata_PT1,
        ADCdata_PT2,
        ADCdata_PT3,
        ADCdata_I4_20_1,
        ADCdata_I4_20_2,
        ADCdata_assymetry,
        ADCdata_IA_angle,
        ADCdata_IB_angle,
        ADCdata_IC_angle,
        ADCdata_ID_angle,
        _WARN_PT100_0,  
        _WARN_PT100_1,
        _WARN_PT100_2,
        _WARN_V4_20_0,
        _WARN_V4_20_1,
        _WARN_PT100_ERROR_0,
        _WARN_PT100_ERROR_1,
        _WARN_PT100_ERROR_2,
        _WARN_V4_20_ERROR_0,
        _WARN_V4_20_ERROR_1,
        _LOCK_PT100_0,
        _LOCK_PT100_1,
        _LOCK_PT100_2,
        V4_20_0,
        V4_20_1,
        _PT100_0,
        _PT100_1,
        _PT100_2,
        _FLASH_RATIOS_SHIFT_PT1,
        _FLASH_RATIOS_SHIFT_PT2,
        _FLASH_RATIOS_SHIFT_PT3,
    }

    public enum Reseiver
    {
        mediator,
        UI,
        model,
        connection
    }
    public class Data_Carrier_Modbus : Data_Carrier_Base
    {
        public int start_value;
    }

    public class Data_Carrier_Modbus_Analog : Data_Carrier_Modbus
    {
        public List<int> values = new List<int>();
    }
    public class Data_Carrier_Modbus_Discret : Data_Carrier_Modbus
    {
        public List<bool> values = new List<bool>();
    }
}