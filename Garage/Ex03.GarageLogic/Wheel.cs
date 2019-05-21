﻿namespace n_Wheel
{
    using System.Text;
    using n_Strings;

    public class Wheel
    {
        private readonly float r_MaxPressure;
        private string m_Manufacturer;
        private float m_CurrentPressure;

        public Wheel(string i_ManufacturerName, float i_MaxPressure)
        {
            r_MaxPressure = i_MaxPressure;
            m_Manufacturer = i_ManufacturerName;
            m_CurrentPressure = i_MaxPressure;
        }

        public void FillTyre(float i_UnitToFill)
        {
            if(m_CurrentPressure + i_UnitToFill > r_MaxPressure)
            {
                //// throw exception
            }
            else
            {
                m_CurrentPressure += r_MaxPressure;
            }
        }

        public float CurrentPressure
        {
            get { return m_CurrentPressure; }
            set { m_CurrentPressure = value; }
        }

        public float MaxPressure
        {
            get { return r_MaxPressure; }
        }

        public string ManufacturerName
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendFormat(Strings.wheel_manufacturer, ManufacturerName);
            vehicleDetails.AppendFormat(Strings.wheel_current_pressure, CurrentPressure);
            return vehicleDetails.ToString();
        }
    }
}