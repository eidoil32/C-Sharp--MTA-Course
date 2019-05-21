﻿namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using Garage;
    using n_Strings;
    using n_Vehicle;

    public class ConsoleUI
    {
        private static readonly List<string> sr_FirstMenuStringArray = new List<string>();
        private static readonly List<string> sr_BooleanOptions = new List<string>();
        private GarageManager m_Garage = new GarageManager();

        public static void Main()
        {
            ConsoleUI UI = new ConsoleUI();
            UI.WelcomeToTheGarage();
        }

        public void WelcomeToTheGarage()
        {
            initializationEnums();
            printMessage(Strings.welcome_massage);
            do
            {
                DoAction(getOptionFromUser<int>("", sr_FirstMenuStringArray, 0));
            }
            while (AnotherAction());
        }

        private void initializationEnums()
        {
            CarColor.SetListOfCarColors();
            LicenseType.SetListOfLicenseType();
            VehicleManager.SetVehicleList();
            VehicleProperties.SetListOfOptions();
            DoorNumber.SetListOfOptions();
            FuelVehicle.SetEnergeyTypeList();
            sr_FirstMenuStringArray.Add(Strings.menu_options_1);
            sr_FirstMenuStringArray.Add(Strings.menu_options_2);
            sr_FirstMenuStringArray.Add(Strings.menu_options_3);
            sr_FirstMenuStringArray.Add(Strings.menu_options_4);
            sr_FirstMenuStringArray.Add(Strings.menu_options_5);
            sr_FirstMenuStringArray.Add(Strings.menu_options_6);
            sr_FirstMenuStringArray.Add(Strings.menu_options_7);
            sr_FirstMenuStringArray.Add(Strings.menu_options_8);
            sr_BooleanOptions.Add(Strings.true_option);
            sr_BooleanOptions.Add(Strings.false_option);
        }

        private void printMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        private void showError(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        private int getUserChoice(int i_MinValue, int i_MaxValue)
        {
            int userChoice;

            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                showError(Strings.invalid_integer);
            }

            if (userChoice < i_MinValue || userChoice > i_MaxValue)
            {
                showError(Strings.invalid_menu_choice);
                userChoice = getUserChoice(i_MinValue, i_MaxValue);
            }

            return userChoice;
        }

        public void ShowOptions(List<string> i_OptionsArray)
        {
            for (int i = 0; i < i_OptionsArray.Count; i++)
            {
                printMessage(string.Format(Strings.menu_format, i + 1, i_OptionsArray[i]));
            }
        }

        public void DoAction(int i_Choice)
        {
            switch (i_Choice)
            {
                case 1:
                    addNewVehicleUI();
                    break;
                case 2:
                    ShowPlatesOfAllVehiclesUI();
                    break;
                case 3:
                    ChangePropertiesUI();
                    break;
                case 4:
                    InflatingWheelUI();
                    break;
                case 5:
                    FuelVehicleUI();
                    break;
                case 6:
                    ChargeElectricVehicleUI();
                    break;
                case 7:
                    ShowVehiclesByPlateUI();
                    break;
                case 8:
                    exitProgram();
                    break;
                default:
                    break;
            }
        }

        private void exitProgram()
        {
            printMessage(Strings.exit_program_message);
            Environment.Exit(1);
        }

        public bool AnotherAction()
        {
            printMessage(Strings.continue_massage);
            return getUserChoice(1, 2) == 1;
        }

        private string getStringFromUser()
        {
            return Console.ReadLine();
        }

        private string getStringFromUser(string i_Message)
        {
            printMessage(i_Message);
            return getStringFromUser();
        }

        private void addNewVehicleUI()
        {
            VehicleProperties.eStateOfService newStatus;
            string plateNumber = getStringFromUser(Strings.enter_plate_number);
            
            try
            {
                VehicleProperties vehicle = m_Garage.GetVehicleByPlateNumber(plateNumber);
                printMessage(string.Format(Strings.change_status_options, VehicleProperties.sr_StateListOptions[(int)vehicle.Status]));
                ShowOptions(VehicleProperties.sr_StateListOptions);
                newStatus = (VehicleProperties.eStateOfService)getUserChoice(1, VehicleProperties.sr_StateListOptions.Count) - 1;
                vehicle.Status = newStatus;
            }
            catch (ArgumentException i_PlateError)
            {
                showError(i_PlateError.Message);
                VehicleManager.eVehicleTypes type = getOptionFromUser<VehicleManager.eVehicleTypes>(Strings.choose_type_of_vehicle, VehicleManager.VehicleList, -1);
                string modelName = getStringFromUser(Strings.enter_model_name);
                string wheelManufacturer = getStringFromUser(Strings.enter_wheel_manufacturer);
                string ownerName = getStringFromUser(Strings.enter_owner_name);
                string phoneNumber = getStringFromUser(Strings.enter_phone_number);
                newStatus = getOptionFromUser<VehicleProperties.eStateOfService>(Strings.choose_status_of_vehicle, VehicleProperties.sr_StateListOptions, -1);

                switch (type)
                {
                    case VehicleManager.eVehicleTypes.Truck:
                        bool is_DeliveryMaterials = getOptionFromUser<int>(Strings.will_delivery_materials, sr_BooleanOptions, -1) == 1;
                        float truckCapacity = getFloatFromUser(Strings.set_truck_capacity_level);
                        m_Garage.AddNewVehicle(VehicleManager.CreateNewTruck(modelName, plateNumber, is_DeliveryMaterials, truckCapacity, wheelManufacturer), ownerName, phoneNumber, newStatus);
                        break;
                    case VehicleManager.eVehicleTypes.Car:
                    case VehicleManager.eVehicleTypes.ElectricCar:
                        CarColor.eCarColor carColor = getOptionFromUser<CarColor.eCarColor>(Strings.choose_car_color, CarColor.sr_CarColorNames, -1);
                        DoorNumber.eNumberOfDoors doorNumber = getOptionFromUser<DoorNumber.eNumberOfDoors>(Strings.choose_door_number, DoorNumber.sr_DoorsOptions, 1);
                        if (type == VehicleManager.eVehicleTypes.Car)
                        {
                            m_Garage.AddNewVehicle(VehicleManager.CreateNewCar(plateNumber, doorNumber, carColor, modelName, wheelManufacturer), ownerName, phoneNumber, newStatus);
                            break;
                        }

                        m_Garage.AddNewVehicle(VehicleManager.CreateNewElectricCar(modelName, plateNumber, wheelManufacturer, carColor, doorNumber), ownerName, phoneNumber, newStatus);
                        break;
                    case VehicleManager.eVehicleTypes.Motorcycle:
                    case VehicleManager.eVehicleTypes.ElectricMotorcycle:
                        int engineCapacity = getIntegerFromUser(Strings.set_engine_capacity);
                        LicenseType.eLicenseType licenseType = getOptionFromUser<LicenseType.eLicenseType>(Strings.get_license_massage, LicenseType.sr_LicenseType, -1);
                        if (type == VehicleManager.eVehicleTypes.Motorcycle)
                        {
                            m_Garage.AddNewVehicle(VehicleManager.CreateNewMotorcycle(modelName, plateNumber, engineCapacity, licenseType, wheelManufacturer), ownerName, phoneNumber, newStatus);
                            break;
                        }

                        m_Garage.AddNewVehicle(VehicleManager.CreateNewElectricMotorcycle(modelName, plateNumber, wheelManufacturer, licenseType, engineCapacity), ownerName, phoneNumber, newStatus);
                        break;
                    default:
                        break;
                }
            }
        }

        private T getOptionFromUser<T>(string i_Message, List<string> i_OptionList, int i_OffsetFromChoices)
        {
            T parameterToReturn;
            printMessage(i_Message);
            ShowOptions(i_OptionList);
            parameterToReturn = (T)(object)(getUserChoice(1, i_OptionList.Count) + i_OffsetFromChoices);
            return parameterToReturn;
        }

        private float getFloatFromUser()
        {
            float userChoice;

            while (!float.TryParse(Console.ReadLine(), out userChoice))
            {
                showError(Strings.invalid_integer);
            }

            return userChoice;
        }

        private float getFloatFromUser(string i_Message)
        {
            printMessage(i_Message);
            return getFloatFromUser();
        }

        private int getIntegerFromUser(string i_Message)
        {
            printMessage(i_Message);
            return getIntegerFromUser();
        }

        private int getIntegerFromUser()
        {
            int userChoice;

            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                showError(Strings.invalid_integer);
            }

            return userChoice;
        }

        public void FuelVehicleUI()
        {
            string plateNumber;
            FuelVehicle.eEnergyType energyType;
            float amountOfFuelToAdd;
            BaseVehicle VehicleToFuel;

            printMessage(Strings.enter_plate_number);
            plateNumber = getStringFromUser();
            try
            {
                VehicleToFuel = m_Garage.GetVehicleByPlateNumber(plateNumber).Vehicle;
                ShowOptions(FuelVehicle.sr_EnergyTypeList);
                energyType = (FuelVehicle.eEnergyType)(getUserChoice(1, FuelVehicle.sr_EnergyTypeList.Count) - 1);
                Console.WriteLine(Strings.amount_fuel_massage);
                amountOfFuelToAdd = getFloatFromUser();
                m_Garage.FuelVehicle(VehicleToFuel, energyType, amountOfFuelToAdd);
            }
            catch (ArgumentException i_PlateError)
            {
                showError(i_PlateError.Message);
            }
        }

        public void ChargeElectricVehicleUI()
        {
            string plateNumber = getStringFromUser(Strings.enter_plate_number);

            try
            {
                BaseVehicle VehicleToCharge = m_Garage.GetVehicleByPlateNumber(plateNumber).Vehicle;
                float amountOfElectricInMinutesToAdd = getFloatFromUser(Strings.amount_fuel_massage);
                m_Garage.ChargeElectricVehicle(VehicleToCharge, amountOfElectricInMinutesToAdd);
            }
            catch (ArgumentException i_PlateError)
            {
                showError(i_PlateError.Message);
            }
        }

        public void ShowVehiclesByPlateUI()
        {
            foreach (VehicleProperties vehicle in m_Garage.Vehicles)
            {
                printMessage(string.Format("{0}\n{1}\n",vehicle.ToString(),Strings.line_brake));
            }
        }

        public void ChangePropertiesUI()
        {
            string plateNumber = getStringFromUser(Strings.enter_plate_number);
            try
            {
                VehicleProperties vehicle = m_Garage.GetVehicleByPlateNumber(plateNumber);
                VehicleProperties.eStateOfService newType = getOptionFromUser<VehicleProperties.eStateOfService>(string.Format(Strings.change_status_options, VehicleProperties.sr_StateListOptions[(int)vehicle.Status]), VehicleProperties.sr_StateListOptions, -1);
                vehicle.Status = newType;
            }
            catch (ArgumentException i_PlateError)
            {
                showError(i_PlateError.Message);
            }
        }

        public void InflatingWheelUI()
        {
            string plateNumber = getStringFromUser(Strings.enter_plate_number);

            try
            {
                BaseVehicle vehicle = m_Garage.GetVehicleByPlateNumber(plateNumber).Vehicle;
                float amount = getFloatFromUser(Strings.amount_to_fill_tire);
                m_Garage.InflatingWheel(vehicle, amount);
            }
            catch (ArgumentException i_PlateError)
            {
                showError(i_PlateError.Message);
            }
        }

        public void ShowPlatesOfAllVehiclesUI()
        {
            int vehicleInGarage = m_Garage.Vehicles.Count;

            for (int i = 0; i < vehicleInGarage; i++)
            {
                printMessage(string.Format("{0}: {1}", i + 1, m_Garage.Vehicles[i].Vehicle.PlateNumber));
            }
        }
    }
}