//using AutoMapper;
//using System.Dynamic;
//using RightMoveADF.Models;
//using Microsoft.EntityFrameworkCore;

//namespace RightMoveADF.Repository
//{
//    public class PropertyRepository :IPropertyRepository
//    {
//        private readonly IMapper _mapper;
        
//        public PropertyRepository(IMapper mapper)
//        {
//            this._mapper = mapper;
//        }
        
//        public ExpandoObject CreateProperty(UkProperty ukProperty)
//        {
//            dynamic responce = new ExpandoObject();
//            var now = DateTime.Now;
//            using (var context = new CoreDbContext())
//            {
//               ukProperty.PropertyAddress.AgentRef =ukProperty.Property.AgentRef;
//                ukProperty.Property.Branch_ID = 1;
//               ukProperty.PropertyAddress.AgentRef = ukProperty.Property.AgentRef;
//              ukProperty.PropertyPrice.AgentRef = ukProperty.Property.AgentRef;
//                ukProperty.PropertyDetail.AgentRef = ukProperty.Property.AgentRef;
//              ukProperty.PropertyDetailsSizing.AgentRef = ukProperty.Property.AgentRef;
//              ukProperty.PropertyRoom.AgentRef = ukProperty.Property.AgentRef;
//              ukProperty.PropertyMedia.AgentRef = ukProperty.Property.AgentRef;

//                var result = context.Properties.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
//                if (result == null)
//                {

//                    try
//                    {
//                        //var header = (string)HttpContext.Request.Headers["Authorization"];
//                        //acctoken = header.Substring(7);
//                        //property.CreatedBy = acctoken;

//                        context.Properties.Add(ukProperty.Property);
//                        context.SaveChanges();

//                        context.PropertyAddresses.Add(ukProperty.PropertyAddress);
//                        context.PropertyPrices.Add(ukProperty.PropertyPrice);
//                        context.PropertyDetails.Add(ukProperty.PropertyDetail);
//                        context.PropertyDetailsSizings.Add(ukProperty.PropertyDetailsSizing);
//                        context.PropertyRooms.Add(ukProperty.PropertyRoom);
//                        context.PropertyMedia.Add(ukProperty.PropertyMedia);
//                        context.SaveChanges();

//                        responce.Request_ID = ukProperty.Property.AgentRef;
//                        responce.Message = "Data Save";
//                        responce.Success = 200;
//                        responce.Request_Timestamp = now;
//                        responce.Response_Timestamp = DateTime.Now;

//                        dynamic propDynamic = new ExpandoObject();
//                        propDynamic.Change_Type = "";
//                        propDynamic.RightMove_ID = 1;
//                        propDynamic.Agent_Ref = ukProperty.Property.AgentRef;
//                        propDynamic.Rightmove_URL = "";
//                        responce.Property = propDynamic;

//                        dynamic propwarning = new ExpandoObject();
//                        propwarning.Warning_Code = "";
//                        propwarning.Warning_Description = "";
//                        propwarning.Warning_Value = "";
//                        responce.Warnings = propwarning;

//                    }
//                    catch (Exception ex)
//                    {
//                        responce.Request_ID = ukProperty.Property.AgentRef;
//                        responce.Success = "401";
//                        responce.Message = ex.Message;
//                        responce.Request_Timestamp = now;
//                        responce.Response_Timestamp = DateTime.Now;


//                        dynamic propDynamic = new ExpandoObject();
//                        propDynamic.Change_Type = "";
//                        propDynamic.RightMove_ID = 1;
//                        propDynamic.Agent_Ref = ukProperty.Property.AgentRef;
//                        propDynamic.Rightmove_URL = "";


//                        dynamic errorDynamic = new ExpandoObject();
//                        errorDynamic.Error_Code = ex.HResult;
//                        errorDynamic.Error_Description = ex.Message;
//                        errorDynamic.Error_Value = ex.InnerException.Message;
//                        responce.Property = propDynamic;

//                        dynamic propwarning = new ExpandoObject();
//                        propwarning.Warning_Code = "";
//                        propwarning.Warning_Description = "";
//                        propwarning.Warning_Value = "";
//                        responce.Warnings = propwarning;
//                        responce.Errors = errorDynamic;

//                    }
//                }
//                else
//                {
//                    responce.Request_ID = ukProperty.Property.AgentRef;
//                    responce.Message = "data is already exists";
//                    responce.Success = 200;
//                    responce.Request_Timestamp = now;
//                    responce.Response_Timestamp = DateTime.Now;

//                    dynamic propDynamic = new ExpandoObject();
//                    propDynamic.Change_Type = "";
//                    propDynamic.RightMove_ID = 1;
//                    propDynamic.Agent_Ref = ukProperty.Property.AgentRef;
//                    propDynamic.Rightmove_URL = "";
//                    responce.Property = propDynamic;

//                    dynamic propwarning = new ExpandoObject();
//                    propwarning.Warning_Code = "";
//                    propwarning.Warning_Description = "";
//                    propwarning.Warning_Value = "";
//                    responce.Warnings = propwarning;

//                }
//            }
//            return responce;
//        }

        
//    }
//}
