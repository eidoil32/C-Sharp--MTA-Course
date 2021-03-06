﻿namespace Garage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using n_Strings;

    public abstract class ElectricVehicle : BaseVehicle
    {
        private float m_RemainingBatteryTime = 0;
        private float m_MaxBatteryTime;

        public ElectricVehicle(Dictionary<string, object> i_Arguments)
            : base(i_Arguments)
        {
            m_MaxBatteryTime = (float)i_Arguments[ArgumentsKeysets.sr_KeyMaxBatteryTime];
            m_RemainingBatteryTime = 0;
            ChargeBattery((float)i_Arguments[ArgumentsKeysets.sr_KeyCurrentEnergyLevel]);
        }

        private void calculatePercentOfRemainingEnergy()
        {
            m_PercentOfRemainingEnergy = (m_RemainingBatteryTime  / m_MaxBatteryTime) * 100;
        }

        public float RemainingBatteryTime
        {
            get { return m_MaxBatteryTime; }
            set { m_MaxBatteryTime = value; }
        }

        public float MaxBatteryTime
        {
            get { return m_RemainingBatteryTime; }
            set { m_RemainingBatteryTime = value; }
        }

        public void ChargeBattery(float i_AmmountofElectricToCharge)
        {
            float hourAmount = convertMinToHour(i_AmmountofElectricToCharge);
            if (m_RemainingBatteryTime + hourAmount > m_MaxBatteryTime || m_RemainingBatteryTime + hourAmount < 0)
            {
                throw new ValueOutOfRangeException(m_RemainingBatteryTime, 0, Strings.out_of_range);
            }

            m_RemainingBatteryTime += hourAmount;
            calculatePercentOfRemainingEnergy();
        }

        private float convertMinToHour(float i_AmmountofElectricToCharge)
        {
            return i_AmmountofElectricToCharge / 60;
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.Append(base.ToString());
            vehicleDetails.AppendLine(Strings.electric_vehicle_battery);
            vehicleDetails.AppendLine(string.Format(Strings.battery_level, m_RemainingBatteryTime));
            vehicleDetails.AppendLine(string.Format(Strings.maximum_battery_level, m_MaxBatteryTime));

            return vehicleDetails.ToString();
        }
    }
}