using MyVehicleRepairServiceNeeds.Models;
using MyVehicleRepairServiceNeeds.TowApp.Web.Domain;
using MyVehicleRepairServiceNeeds.TowApp.Web.Models;
using MyVehicleRepairServiceNeeds.TowApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WikiDataProvider.Data;
using WikiDataProvider.Data.Interfaces;

namespace MyVehicleRepairServiceNeeds.Services.cs
{
    public class TowInfoService : BaseService, ITowInfoService
    {

        public int Add(TowInfoAddRequest model)
        {
            int id = 0;

            Action<SqlParameterCollection> inputParamDelegate = delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@CompanyName", model.CompanyName);
                paramCollection.AddWithValue("@FirstName", model.FirstName);
                paramCollection.AddWithValue("@LastName", model.LastName);
                paramCollection.AddWithValue("@PhoneNumber", model.PhoneNumber);
                paramCollection.AddWithValue("@NumberOfTrucks", model.NumberOfTrucks);
                paramCollection.AddWithValue("@TwentyFourHours", model.TwentyFourHours);

                SqlParameter outParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                outParameter.Direction = System.Data.ParameterDirection.Output;

                paramCollection.Add(outParameter);
            };

            Action<SqlParameterCollection> returnParamDelegate = delegate (SqlParameterCollection paramCollection)
            {
                Int32.TryParse(paramCollection["@Id"].Value.ToString(), out id);
            };

            DataProvider.ExecuteNonQuery(GetConnection,"dbo.TowInfo_Insert", inputParamDelegate, returnParamDelegate);
            return id;

        }

        public void Update(TowInfoUpdateRequest model, int Id)
        {
            Action<SqlParameterCollection> inputParamDelegate = delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@CompanyName", model.CompanyName);
                paramCollection.AddWithValue("@FirstName", model.FirstName);
                paramCollection.AddWithValue("@LastName", model.LastName);
                paramCollection.AddWithValue("@PhoneNumber", model.PhoneNumber);
                paramCollection.AddWithValue("@NumberOfTrucks", model.NumberOfTrucks);
                paramCollection.AddWithValue("@TwentyFourHours", model.TwentyFourHours);
                paramCollection.AddWithValue("@Id", Id);
            };

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.TowInfo_UpdateById", inputParamDelegate);
        }


        public List<TowInfo> Get()
        {
            List<TowInfo> list = null;

            Action<IDataReader, short> singleRecMapper = delegate (IDataReader reader, short set)
             {
                 TowInfo towInformation = MapTowInfo(reader);

                 if (list == null)
                 {
                     list = new List<TowInfo>();
                 }
                 list.Add(towInformation);
             };

            Action<SqlParameterCollection> inputParamDelegate = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.TowInfo_SelectAll",inputParamDelegate, singleRecMapper);
            return list;
        }

        public static TowInfo MapTowInfo(IDataReader reader)
        {
            TowInfo towInformation = new TowInfo();
            int startingIndex = 0;
            towInformation.Id = reader.GetInt32(startingIndex++);
            towInformation.CompanyName = reader.GetString(startingIndex++);
            towInformation.FirstName = reader.GetString(startingIndex++);
            towInformation.LastName = reader.GetString(startingIndex++);
            towInformation.PhoneNumber = reader.GetString(startingIndex++);
            towInformation.NumberOfTrucks = reader.GetInt32(startingIndex++);
            towInformation.TwentyFourHours = reader.GetBoolean(startingIndex++);
            towInformation.DateAdded = reader.GetDateTime(startingIndex++);
            towInformation.DateModified = reader.GetDateTime(startingIndex++);
            return towInformation;
        }

        public void Delete(int id)
        {
            Action<SqlParameterCollection> inputParamDelegate = delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@Id", id);
            };

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.TowInfo_DeleteById", inputParamDelegate);
        }

        public TowInfo Get(int id)
        {
            TowInfo singleItem = new TowInfo();

            Action<IDataReader, short> singleRecMapper = delegate (IDataReader reader, short set)
            {
                int startingIndex = 0; //startingOrdinal

                singleItem.Id = reader.GetInt32(startingIndex++);
                singleItem.CompanyName = reader.GetString(startingIndex++);
                singleItem.FirstName = reader.GetString(startingIndex++);
                singleItem.LastName = reader.GetString(startingIndex++);
                singleItem.PhoneNumber = reader.GetString(startingIndex++);
                singleItem.NumberOfTrucks = reader.GetInt32(startingIndex++);
                singleItem.TwentyFourHours = reader.GetBoolean(startingIndex++);
                singleItem.DateAdded = reader.GetDateTime(startingIndex++);
                singleItem.DateModified = reader.GetDateTime(startingIndex++);              
            };
            Action<SqlParameterCollection> inputParamDelegate = delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@Id", id);
            };
            DataProvider.ExecuteCmd(GetConnection,"dbo.TowInfo_SelectById", inputParamDelegate, singleRecMapper);

            return singleItem;
        }


    }
}