using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetManager.Concretes;
using Newtonsoft.Json;
using System.IO;
using PetManager.Models;


namespace PetManager.Managers
{

    /// <summary>
    /// Enumeration to represent current status of pets
    /// </summary>
    public enum PetStatus
    {
        Deployed = 1,
        Training,
        OnLeave,
        ReadyToDeploy,
        Deceased,
        JustArrived
    }

    /// <summary>
    /// Enumeration to represent state of the response to the client
    /// </summary>
    public enum MessageStatus
    {
        OK = 1,
        ERROR
    }

    /// <summary>
    /// Class that exposes actions to take on the Animal entititeis
    /// </summary>
    public class ModelManager
    {
        public ModelManager()
        {
            
        }

        /// <summary>
        /// Gets Serialized ReturnMessage object containg status of request and JSON-based animal list when status is OK.
        /// Contains error message if status is ERROR
        /// </summary>
        /// <param name="ids">List on ints as animal ids</param>
        /// <returns>string</returns>
        public string GetPetsByIdsList(List<int> ids)
        {
            var returnString = "";
            var returnMessage = new ReturnMessage();
            using (EFRepository rep = new EFRepository())
            {
                try
                {
                    var animals = rep.GetEntitiesByIdList<Animal>(ids);

                    returnMessage.MessageStatus = GetEnumValueName<MessageStatus>((int)MessageStatus.OK);
                    //returnMessage.Message = ProcessIntoJson<Animal>(animals);
                    returnMessage.Message = animals;
                }
                catch(Exception e)
                {
                    returnMessage.MessageStatus = GetEnumValueName<MessageStatus>((int)MessageStatus.ERROR);
                    returnMessage.Message = e.Message;
                }
                finally
                {
                    returnString = ProcessIntoJson<ReturnMessage>(returnMessage);
                }
            }
            return returnString;
        }

        /// <summary>
        /// Gets Serialized ReturnMessage object containg status of request and JSON-based animal list when status is OK.
        /// Contains error message if status is ERROR
        /// </summary>
        /// <param name="statusList">List of enums (PetStatus)</param>
        /// <returns>string</returns>
        public string GetPetsByStatus(List<PetStatus> statusList)
        {
            var returnString = "";
            var returnMessage = new ReturnMessage();
            using (EFRepository rep = new EFRepository())
            {
                try
                {
                    //Func<Animal, bool> fnc = a => a.AnimalStatusID == (int)status;
                    //var animals = rep.GetEntitiesByParameter<Animal>(fnc);
                    
                    var animals = rep.GetEntitiesByStatusList<Animal>(statusList);

                    returnMessage.MessageStatus = GetEnumValueName<MessageStatus>((int)MessageStatus.OK);
                    //returnMessage.Message = ProcessIntoJson<Animal>(animals);
                    returnMessage.Message = animals;
                }
                catch(Exception e)
                {
                    returnMessage.MessageStatus = GetEnumValueName<MessageStatus>((int)MessageStatus.ERROR);
                    returnMessage.Message = e.Message;

                    
                }
                finally
                {
                    returnString = ProcessIntoJson<ReturnMessage>(returnMessage);
                }
            }

            return returnString;
        }


        /// <summary>
        /// Gets Serialized ReturnMessage object containg status of request and simple success message if status is OK.
        /// Contains error message if status is ERROR
        /// </summary>
        /// <param name="newPet">Client-provided Animal object</param>
        /// <returns>string</returns>
        public string SaveNewPet(Animal newPet)
        {
            var returnString = "";
            var returnMessage = new ReturnMessage();
            using(EFRepository rep = new EFRepository())
            {
                try
                {
                    if (newPet.AnimalsID != null && newPet.AnimalsID > 0)
                        throw new Exception("Id is created automatically.  Do not provide.");

                    int rowsModified = rep.SaveNewEntity<Animal>(newPet);
                    returnMessage.MessageStatus = GetEnumValueName<MessageStatus>((int)MessageStatus.OK);
                    returnMessage.Message = "Rows added = " + rowsModified;
                }
                catch(Exception e)
                {
                    returnMessage.MessageStatus = GetEnumValueName<MessageStatus>((int)MessageStatus.ERROR);
                    returnMessage.Message = e.Message;
                }
                finally
                {
                    returnString = ProcessIntoJson<ReturnMessage>(returnMessage);
                }
                
                return returnString;
            }
        }

        /// <summary>
        /// Helper function retrieve "Name" of generically-passed enum member
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="value">Value of enum member</param>
        /// <returns>string</returns>
        private string GetEnumValueName<T>(int value)
        {
            return Enum.GetName(typeof(T), value);
        }

        //private string ProcessIntoJson<T>(List<T> entityList)
        //{
        //    var jsonString = JsonConvert.SerializeObject(entityList);

        //    return jsonString;
        //}


        /// <summary>
        /// Returns provided object in serialized JSON format
        /// </summary>
        /// <typeparam name="T">Generically-provided Type</typeparam>
        /// <param name="entity">Object to serialize</param>
        /// <returns>string</returns>
        private string ProcessIntoJson<T>(T entity)
        {
            var jsonString = JsonConvert.SerializeObject(entity);

            return jsonString;
        }
    }
}
