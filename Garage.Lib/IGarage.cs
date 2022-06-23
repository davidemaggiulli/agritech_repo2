using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Lib
{
    public interface IGarage
    {
        /// <summary>
        /// Immissione di un nuovo veicolo nel garage (ritornare il numero del posto assegnato);
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        /// <exception cref="GarageFullException"></exception>
        /// <exception cref="PlaceAlreadyBusyException"></exception>
        int InsertVehicle(Vehicle vehicle);

        /// <summary>
        /// Estrazione dal garage del veicolo che occupa un determinato posto (ritornare l’istanza del veicolo stesso);
        /// </summary>
        /// <param name="placeNumber"></param>
        /// <exception cref="PlaceAlreadyFreeException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <returns></returns>
        Vehicle ExtractVehicle (int placeNumber);

        /// <summary>
        /// Estrazione dal garage del veicolo che occupa un determinato posto data la targa (ritornare l’istanza del veicolo stesso);
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        Vehicle ExtractVehicle(string plate);

        /// <summary>
        /// Stampa della situazione corrente dei posti nel garage: stampare per ogni posto tutte le informazioni disponibili sul veicolo che lo sta occupando
        /// </summary>
        /// <returns></returns>
        string Print();

        Place GetPlace(int pos);
    }
}
