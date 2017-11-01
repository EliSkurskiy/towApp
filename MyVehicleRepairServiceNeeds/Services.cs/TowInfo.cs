//using MyVehicleRepairServiceNeeds.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace MyVehicleRepairServiceNeeds.Services.cs
//{
//    public class TowInfo
//    {
//        private IDataProvider _dataProvider;

//        public TowInfo(IDataProvider dataProvider)
//        {
//            _dataProvider = dataProvider;
//        }


//        public int CreateTowRecord(TowInfoAddRequest model)
//        {
//            int id = 0;

//            Action<SqlParameterCollection> inputParamDelegate = delegate (SqlParameterCollection paramCollection)
//            {
//                paramCollection.AddWithValue("@FirstName", model.FirstName);
//                paramCollection.AddWithValue("@LastName", model.LastName);
//                paramCollection.AddWithValue("@PhoneNumber", model.PhoneNumber);
//                paramCollection.AddWithValue("@NumberOfTrucks", model.NumberOfTrucks);
//                paramCollection.AddWithValue("@TwentyFourHours", model.TwentyFourHours);

//                SqlParameter outParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
//                outParameter.Direction = System.Data.ParameterDirection.Output;

//                paramCollection.Add(outParameter);
//            };

//            Action<SqlParameterCollection> returnParamDelegate = delegate (SqlParameterCollection paramCollection)
//            {
//                Int32.TryParse(paramCollection["@Id"].Value.ToString(), out id);
//            };

//            _dataProvider.ExecuteNonQuery("dbo.TowInfo_Insert", inputParamDelegate, returnParamDelegate);

//        }









//    }
//}