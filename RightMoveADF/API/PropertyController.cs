using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RightMoveADF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using RightMoveADF.ViewModels;
using AutoMapper;
namespace RightMoveADF.API
{
    

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IMapper _mapper;
       
        public PropertyController(IMapper mapper)
        {
            this._mapper = mapper;
        }
            //public void agentref(UkProperty ukProperty)
            //{

            //}
            [HttpPost]
        [Route("createproperty")]
        [AllowAnonymous]
        public  ExpandoObject CreateProperty([FromForm] UkPropertyViewModel ukPropertyViewModel)
        {
           
            Property property = new Property();
            PropertyAddress propertyAddress = new PropertyAddress();
            PropertyDetail propertyDetail=new PropertyDetail();
            PropertyDetailsSizing propertyDetailsSizing = new PropertyDetailsSizing();
            PropertyMedia propertyMedia = new PropertyMedia();
            PropertyPrice propertyPrice = new PropertyPrice();
            PropertyRoom propertyRoom = new PropertyRoom();

            _mapper.Map(ukPropertyViewModel.PropertyViewModel,property);
            _mapper.Map(ukPropertyViewModel.PropertyAddressViewModel, propertyAddress);
            _mapper.Map(ukPropertyViewModel.PropertyDetailViewModel, propertyDetail);
            _mapper.Map(ukPropertyViewModel.PropertyDetailsSizingViewModel, propertyDetailsSizing);
            _mapper.Map(ukPropertyViewModel.PropertyMediaViewModel, propertyMedia);
            _mapper.Map(ukPropertyViewModel.PropertyPriceViewModel, propertyPrice);
            _mapper.Map(ukPropertyViewModel.PropertyRoomViewModel, propertyRoom);
            dynamic responce = new ExpandoObject();

            var now = DateTime.Now;
            using (var context = new CoreDbContext())
            {
              propertyAddress.AgentRef = property.AgentRef;
                property.Branch_ID = 1;
                propertyAddress.AgentRef = property.AgentRef;
                propertyPrice.AgentRef = property.AgentRef;
                propertyDetail.AgentRef = property.AgentRef;
                propertyDetailsSizing.AgentRef = property.AgentRef;
                propertyRoom.AgentRef = property.AgentRef;
                propertyMedia.AgentRef = property.AgentRef;

                var result = context.Properties.AsNoTracking().FirstOrDefault(x => x.AgentRef == property.AgentRef);
                if (result == null)
                {

                    try
                    {
                        //var header = (string)HttpContext.Request.Headers["Authorization"];
                        //acctoken = header.Substring(7);
                        //property.CreatedBy = acctoken;

                        context.Properties.Add(property);
                        context.SaveChanges();

                        context.PropertyAddresses.Add(propertyAddress);
                        context.PropertyPrices.Add(propertyPrice);
                        context.PropertyDetails.Add(propertyDetail);
                        context.PropertyDetailsSizings.Add(propertyDetailsSizing);
                        context.PropertyRooms.Add(propertyRoom);
                        context.PropertyMedia.Add(propertyMedia);
                        context.SaveChanges();

                        responce.Request_ID = property.AgentRef;
                        responce.Message = "Data Save";
                        responce.Success = 200;
                        responce.Request_Timestamp = now;
                        responce.Response_Timestamp = DateTime.Now;

                        dynamic propDynamic = new ExpandoObject();
                        propDynamic.Change_Type = "";
                        propDynamic.RightMove_ID = 1;
                        propDynamic.Agent_Ref = property.AgentRef;
                        propDynamic.Rightmove_URL = "";
                        responce.Property = propDynamic;

                        dynamic propwarning = new ExpandoObject();
                        propwarning.Warning_Code = "";
                        propwarning.Warning_Description = "";
                        propwarning.Warning_Value = "";
                        responce.Warnings = propwarning;

                    }
                    catch (Exception ex)
                    {
                        responce.Request_ID =property.AgentRef;
                        responce.Success = "401";
                        responce.Message = ex.Message;
                        responce.Request_Timestamp = now;
                        responce.Response_Timestamp = DateTime.Now;


                        dynamic propDynamic = new ExpandoObject();
                        propDynamic.Change_Type = "";
                        propDynamic.RightMove_ID = 1;
                        propDynamic.Agent_Ref = property.AgentRef;
                        propDynamic.Rightmove_URL = "";


                        dynamic errorDynamic = new ExpandoObject();
                        errorDynamic.Error_Code = ex.HResult;
                        errorDynamic.Error_Description = ex.Message;
                        errorDynamic.Error_Value = ex.InnerException.Message;
                        responce.Property = propDynamic;

                        dynamic propwarning = new ExpandoObject();
                        propwarning.Warning_Code = "";
                        propwarning.Warning_Description = "";
                        propwarning.Warning_Value = "";
                        responce.Warnings = propwarning;
                        responce.Errors = errorDynamic;

                    }
                }
                else
                {
                    responce.Request_ID = property.AgentRef;
                    responce.Message = "data is already exists";
                    responce.Success = 200;
                    responce.Request_Timestamp = now;
                    responce.Response_Timestamp = DateTime.Now;

                    dynamic propDynamic = new ExpandoObject();
                    propDynamic.Change_Type = "";
                    propDynamic.RightMove_ID = 1;
                    propDynamic.Agent_Ref = property.AgentRef;
                    propDynamic.Rightmove_URL = "";
                    responce.Property = propDynamic;

                    dynamic propwarning = new ExpandoObject();
                    propwarning.Warning_Code = "";
                    propwarning.Warning_Description = "";
                    propwarning.Warning_Value = "";
                    responce.Warnings = propwarning;
                  
                }
            }
            return responce;

        }

        //[HttpPost]
        //[Route("createproperty")]
        //public IActionResult CreateProperty([FromForm] Property property)
        //{
        //    string acctoken;

        //    ResponceUkProperty responce = new ResponceUkProperty();
        //    responce.Request_Timestamp = DateTime.Now;
        //        try
        //        {
        //         var header = (string)HttpContext.Request.Headers["Authorization"];

        //            acctoken = header.Substring(7);
        //            property.CreatedBy = acctoken;

        //        using (var context = new CoreDbContext())
        //            {

        //                context.Properties.Add(property);
        //                context.SaveChanges();
        //            }
        //            responce.Request_ID = property.AgentRef;
        //            responce.Message = "Data Save";
        //            responce.Success = 200;
        //            responce.Response_Timestamp= DateTime.Now;
        //            responce.Entity = property;
        //        }
        //        catch (Exception ex)
        //        {
        //        responce.Request_ID = property.AgentRef;
        //        responce.Entity = property;
        //        responce.Success = HttpContext.Response.StatusCode;
        //        responce.Message = ex.Message;
        //        responce.Errors = ex.InnerException.Message;


        //    }




        //    return Ok(responce);
        //}

        [HttpGet]
        [Route("getproperties")]
        [AllowAnonymous]
        public ExpandoObject getproperties()
        {

            //ResponceData responce = new ResponceData();
            dynamic responce = new ExpandoObject();
            //var accesstoken = HttpContext.Session.GetString("JWToken");
           var now = DateTime.Now;
            string acctoken;
            try
            {


                List<UkProperty> result = new List<UkProperty>();
                using (var context = new CoreDbContext())
                {
                    //result = context.Properties.ToList();
                    result = (from a in context.Properties
                              join b in context.PropertyAddresses
                              on a.AgentRef equals b.AgentRef

                              join e in context.PropertyDetails
                              on a.AgentRef equals e.AgentRef
                              join f in context.PropertyDetailsSizings
                              on a.AgentRef equals f.AgentRef
                              join g in context.PropertyMedia
                              on a.AgentRef equals g.AgentRef
                              join h in context.PropertyPrices
                              on a.AgentRef equals h.AgentRef
                              join i in context.PropertyRooms
                              on a.AgentRef equals i.AgentRef
                              select new UkProperty
                              {
                                  Property = a,
                                  PropertyAddress = b,
                                  
                                  PropertyDetail = e,
                                  PropertyDetailsSizing = f,
                                  PropertyMedia = g,
                                  PropertyPrice = h,
                                  PropertyRoom = i,

                              }).ToList();

                }
                responce.Request_ID = "";
                responce.Message = "ok";
                responce.StatusCode = 200;
                responce.Request_Timestamp = now;
                responce.Response_Timestamp = DateTime.Now;
                responce.Entity = result;

                dynamic propDynamic = new ExpandoObject();
                propDynamic.Change_Type = "";
                propDynamic.RightMove_ID = 1;
                propDynamic.Rightmove_URL = "";
                responce.Property = propDynamic;

                dynamic propwarning = new ExpandoObject();
                propwarning.Warning_Code = "";
                propwarning.Warning_Description = "";
                propwarning.Warning_Value = "";
                responce.Warnings = propwarning;

            }
            catch (Exception ex)
            {
                responce.Request_ID = "";
                responce.Message = "";
                responce.StatusCode = 401;
                responce.Request_Timestamp = now;
                responce.Response_Timestamp = DateTime.Now;
                responce.Entity = "";


                dynamic propDynamic = new ExpandoObject();
                propDynamic.Change_Type = "";
                propDynamic.RightMove_ID = 1;
                propDynamic.Agent_Ref = "";
                propDynamic.Rightmove_URL = "";


                dynamic errorDynamic = new ExpandoObject();
                errorDynamic.Error_Code = ex.HResult;
                errorDynamic.Error_Description = ex.Message;
                errorDynamic.Error_Value = ex.InnerException.Message;
                responce.Property = propDynamic;

                dynamic propwarning = new ExpandoObject();
                propwarning.Warning_Code = "";
                propwarning.Warning_Description = "";
                propwarning.Warning_Value = "";
                responce.Warnings = propwarning;
                responce.Errors = errorDynamic;

            }




            return responce;


        }

        [HttpGet]
        [Route("getproperty")]
        public ExpandoObject getproperty(string AgentRef)
        {
            dynamic responce = new ExpandoObject();
           var now = DateTime.Now;
            try
            {

                UkProperty result = new UkProperty();
                using (var context = new CoreDbContext())
                {
                    //result = context.Properties.Where(x => x.AgentRef == AgentRef).FirstOrDefault();
                    result = (from a in context.Properties
                              join b in context.PropertyAddresses
                              on a.AgentRef equals b.AgentRef
                              
                              join e in context.PropertyDetails
                              on a.AgentRef equals e.AgentRef
                              join f in context.PropertyDetailsSizings
                              on a.AgentRef equals f.AgentRef
                              join g in context.PropertyMedia
                              on a.AgentRef equals g.AgentRef
                              join h in context.PropertyPrices
                              on a.AgentRef equals h.AgentRef
                              join i in context.PropertyRooms
                              on a.AgentRef equals i.AgentRef
                              where (a.AgentRef == AgentRef)
                              select new UkProperty
                              {
                                  Property = a,
                                  PropertyAddress = b,
                                  
                                  PropertyDetail = e,
                                  PropertyDetailsSizing = f,
                                  PropertyMedia = g,
                                  PropertyPrice= h,
                                  PropertyRoom= i,

                              }).FirstOrDefault();

                }
                if (result == null)
                {
                    responce.Request_ID = AgentRef;
                    responce.Message = "Data Not Found";
                    responce.StatusCode = 200;
                    responce.Request_Timestamp = now;
                    responce.Response_Timestamp = DateTime.Now;
                    responce.Entity = result;
                    



                    dynamic propDynamic = new ExpandoObject();
                    propDynamic.Change_Type = "";
                    propDynamic.RightMove_ID = 1;
                    propDynamic.Agent_Ref = AgentRef;
                    propDynamic.Rightmove_URL = "";
                    responce.Property = propDynamic;

                    dynamic propwarning = new ExpandoObject();
                    propwarning.Warning_Code = "";
                    propwarning.Warning_Description = "";
                    propwarning.Warning_Value = "";
                    responce.Warnings = propwarning;
                }
                else
                {
                    responce.Request_ID = AgentRef;
                    responce.Message = "Ok";
                    responce.StatusCode = 200;
                    responce.Request_Timestamp = now;
                    responce.Response_Timestamp = DateTime.Now;
                    responce.Entity = result;


                    dynamic propDynamic = new ExpandoObject();
                    propDynamic.Change_Type = "";
                    propDynamic.RightMove_ID = 1;
                    propDynamic.Agent_Ref = AgentRef;
                    propDynamic.Rightmove_URL = "";
                    responce.Property = propDynamic;

                    dynamic propwarning = new ExpandoObject();
                    propwarning.Warning_Code = "";
                    propwarning.Warning_Description = "";
                    propwarning.Warning_Value = "";
                    responce.Warnings = propwarning;
                }
            }
            catch (Exception ex)
            {
                responce.Request_ID = AgentRef;
                responce.Message = "";
                responce.StatusCode = 401;
                responce.Request_Timestamp = now;
                responce.Response_Timestamp = DateTime.Now;
                responce.Entity = "";


                dynamic propDynamic = new ExpandoObject();
                propDynamic.Change_Type = "";
                propDynamic.RightMove_ID = 1;
                propDynamic.Agent_Ref = AgentRef;
                propDynamic.Rightmove_URL = "";


                dynamic errorDynamic = new ExpandoObject();
                errorDynamic.Error_Code = ex.HResult;
                errorDynamic.Error_Description = ex.Message;
                errorDynamic.Error_Value = ex.InnerException.Message;
                responce.Property = propDynamic;

                dynamic propwarning = new ExpandoObject();
                propwarning.Warning_Code = "";
                propwarning.Warning_Description = "";
                propwarning.Warning_Value = "";
                responce.Warnings = propwarning;
                responce.Errors = errorDynamic;

            }

            return responce;
        }

        [HttpPost]
        [Route("updateproperty")]
        public ExpandoObject updateproperty([FromForm] UkProperty ukProperty)
        {
            //ResponceData responce = new ResponceData();
            dynamic responce = new ExpandoObject();
            var now = DateTime.Now;
            try
            {
                ukProperty.PropertyAddress.AgentRef = ukProperty.Property.AgentRef;
                ukProperty.Property.Branch_ID = 1;
                ukProperty.PropertyAddress.AgentRef = ukProperty.Property.AgentRef;
                ukProperty.PropertyPrice.AgentRef = ukProperty.Property.AgentRef;
                ukProperty.PropertyDetail.AgentRef = ukProperty.Property.AgentRef;
                ukProperty.PropertyDetailsSizing.AgentRef = ukProperty.Property.AgentRef;
                ukProperty.PropertyRoom.AgentRef = ukProperty.Property.AgentRef;
                ukProperty.PropertyMedia.AgentRef = ukProperty.Property.AgentRef;
                using (var context = new CoreDbContext())
                {
                    var result = context.Properties.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
                    if (result != null)
                    {

                        context.Entry(ukProperty.Property).State = EntityState.Modified;
                        var addresult = context.PropertyAddresses.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
                        ukProperty.PropertyAddress.Id = addresult.Id;
                        context.Entry(ukProperty.PropertyAddress).State = EntityState.Modified;
                        var detailresult = context.PropertyDetails.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
                        ukProperty.PropertyDetail.Id = detailresult.Id;
                        context.Entry(ukProperty.PropertyDetail).State = EntityState.Modified;
                        var sizeresult = context.PropertyDetailsSizings.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
                        ukProperty.PropertyDetailsSizing.Id = sizeresult.Id;
                        context.Entry(ukProperty.PropertyDetailsSizing).State = EntityState.Modified;
                        var mediaresult = context.PropertyMedia.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
                        ukProperty.PropertyMedia.Id = mediaresult.Id;
                        context.Entry(ukProperty.PropertyMedia).State = EntityState.Modified;
                        var priceresult = context.PropertyPrices.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
                        ukProperty.PropertyPrice.Id = priceresult.Id;
                        context.Entry(ukProperty.PropertyPrice).State = EntityState.Modified;
                        var roomresult = context.PropertyRooms.AsNoTracking().FirstOrDefault(x => x.AgentRef == ukProperty.Property.AgentRef);
                        ukProperty.PropertyRoom.Id = roomresult.Id;
                        context.Entry(ukProperty.PropertyRoom).State = EntityState.Modified;
                        context.SaveChanges();




                        responce.Request_ID = ukProperty.Property.AgentRef;
                        responce.Message = "Updata Data";
                        responce.Success = 200;
                        responce.Request_Timestamp = now;
                        responce.Response_Timestamp = DateTime.Now;

                        dynamic propDynamic = new ExpandoObject();
                        propDynamic.Change_Type = "";
                        propDynamic.RightMove_ID = 1;
                        propDynamic.Agent_Ref = ukProperty.Property.AgentRef;
                        propDynamic.Rightmove_URL = "";
                        responce.Property = propDynamic;

                        dynamic propwarning = new ExpandoObject();
                        propwarning.Warning_Code = "";
                        propwarning.Warning_Description = "";
                        propwarning.Warning_Value = "";
                        responce.Warnings = propwarning;
                    }
                    else
                    {
                        responce.Request_ID = ukProperty.Property.AgentRef;
                        responce.StatusCode = 200;
                        responce.Message = "Data Not Found";
                        responce.Request_Timestamp = now;
                        responce.Response_Timestamp = DateTime.Now;

                        dynamic propDynamic = new ExpandoObject();
                        propDynamic.Change_Type = "";
                        propDynamic.RightMove_ID = 1;
                        propDynamic.Agent_Ref = ukProperty.Property.AgentRef;
                        propDynamic.Rightmove_URL = "";
                        responce.Property = propDynamic;

                        dynamic propwarning = new ExpandoObject();
                        propwarning.Warning_Code = "";
                        propwarning.Warning_Description = "";
                        propwarning.Warning_Value = "";
                        responce.Warnings = propwarning;
                    }
                }


            }
            catch (Exception ex)
            {
                //responce.Entity = string.Empty;
                //responce.StatusCode = ex.InnerException == null ? 400 : ex.InnerException.HResult;
                //responce.Message = ex.Message;
                //throw;
                responce.Request_ID = ukProperty.Property.AgentRef;
                responce.Success = "";
                responce.Message = ex.Message;
                responce.Response_Timestamp = DateTime.Now;


                dynamic propDynamic = new ExpandoObject();
                propDynamic.Change_Type = "";
                propDynamic.RightMove_ID = 1;
                propDynamic.Agent_Ref = ukProperty.Property.AgentRef;
                propDynamic.Rightmove_URL = "";


                dynamic errorDynamic = new ExpandoObject();
                errorDynamic.Error_Code = ex.HResult;
                errorDynamic.Error_Description = ex.Message;
                errorDynamic.Error_Value = ex.InnerException.Message;
                responce.Property = propDynamic;

                dynamic propwarning = new ExpandoObject();
                propwarning.Warning_Code = "";
                propwarning.Warning_Description = "";
                propwarning.Warning_Value = "";
                responce.Warnings = propwarning;
                responce.Errors = errorDynamic;

            }

            return responce;
        }

        [HttpDelete]
        [Route("deleteproperty")]
        public ExpandoObject Deleteproperty(string AgentRef)
        {
            dynamic responce = new ExpandoObject();
            var now = DateTime.Now;
            try
            {
                Property result = new Property();
                using (var context = new CoreDbContext())
                {
                    var proresult = context.Properties.Where(x => x.AgentRef == AgentRef).FirstOrDefault();
                    var addresult = context.PropertyAddresses.Where(x => x.AgentRef == AgentRef).FirstOrDefault();
                    var detailresult = context.PropertyDetails.Where(x => x.AgentRef == AgentRef).FirstOrDefault();
                    var sizeresult = context.PropertyDetailsSizings.Where(x => x.AgentRef == AgentRef).FirstOrDefault();
                    var mediaresult = context.PropertyMedia.Where(x => x.AgentRef == AgentRef).FirstOrDefault();
                    var priceresult = context.PropertyPrices.Where(x => x.AgentRef == AgentRef).FirstOrDefault();
                    var roomresult = context.PropertyRooms.Where(x => x.AgentRef == AgentRef).FirstOrDefault();

                    if (proresult != null)
                    {
                       
                        context.PropertyAddresses.Remove(addresult);
                        context.PropertyDetails.Remove(detailresult);
                        context.PropertyDetailsSizings.Remove(sizeresult);
                        context.PropertyMedia.Remove(mediaresult);
                        context.PropertyPrices.Remove(priceresult);
                        context.PropertyRooms.Remove(roomresult);
                        context.SaveChanges();
                        context.Properties.Remove(proresult);
                        context.SaveChanges();

                        responce.Request_ID = AgentRef;
                        responce.Message = "Done";
                        responce.Success = 200;
                        responce.Request_Timestamp = now;
                        responce.Response_Timestamp = DateTime.Now;
                        
                        dynamic propDynamic = new ExpandoObject();
                        propDynamic.Change_Type = "";
                        propDynamic.RightMove_ID = 1;
                        propDynamic.Agent_Ref = AgentRef;
                        propDynamic.Rightmove_URL = "";
                        responce.Property = propDynamic;

                        dynamic propwarning = new ExpandoObject();
                        propwarning.Warning_Code = "";
                        propwarning.Warning_Description = "";
                        propwarning.Warning_Value = "";
                        responce.Warnings = propwarning;
                    }
                    else
                    {
                        responce.Request_ID = AgentRef;
                        responce.Message = "Data Not Found";
                        responce.Success = 200;
                        responce.Request_Timestamp = now;
                        responce.Response_Timestamp = DateTime.Now;
                        
                        dynamic propDynamic = new ExpandoObject();
                        propDynamic.Change_Type = "";
                        propDynamic.RightMove_ID = 1;
                        propDynamic.Agent_Ref = AgentRef;
                        propDynamic.Rightmove_URL = "";
                        responce.Property = propDynamic;

                        dynamic propwarning = new ExpandoObject();
                        propwarning.Warning_Code = "";
                        propwarning.Warning_Description = "";
                        propwarning.Warning_Value = "";
                        responce.Warnings = propwarning;

                    }

                }

            }
            catch (Exception ex)
            {
                responce.Request_ID = AgentRef;
                responce.Success = "";
                responce.Message = ex.Message;
                responce.Request_Timestamp = now;
                responce.Response_Timestamp = DateTime.Now;


                dynamic propDynamic = new ExpandoObject();
                propDynamic.Change_Type = "";
                propDynamic.RightMove_ID = 1;
                propDynamic.Agent_Ref = AgentRef;
                propDynamic.Rightmove_URL = "";


                dynamic errorDynamic = new ExpandoObject();
                errorDynamic.Error_Code = ex.HResult;
                errorDynamic.Error_Description = ex.Message;
                errorDynamic.Error_Value = ex.InnerException.Message;


                dynamic propwarning = new ExpandoObject();
                propwarning.Warning_Code = "";
                propwarning.Warning_Description = "";
                propwarning.Warning_Value = "";
                responce.Warnings = propwarning;
                responce.Errors = errorDynamic;
            }

            return responce;
        }
        //[HttpPost]
        //[Route("createukproperty")]
        //[AllowAnonymous]
        //public ExpandoObject createukproperty([FromForm] Ukproperty ukproperty)
        //{
        //    dynamic responce = new ExpandoObject();
        //    responce.Request_Timestamp = DateTime.Now;
        //    try
        //    {
        //        //var header = (string)HttpContext.Request.Headers["Authorization"];
        //        //var acctoken = header.Substring(7);
        //        //ukproperty.Property.CreatedBy = acctoken;
        //        ukproperty.PropertyAddress.AgentRef = ukproperty.Property.AgentRef;
        //        using (var context = new CoreDbContext())
        //        {
        //            context.Properties.Add(ukproperty.Property);
        //            context.PropertyAddresses.Add(ukproperty.PropertyAddress);
        //            context.SaveChanges();
        //        }
        //        responce.Request_ID = ukproperty.Property.AgentRef;
        //        responce.Message = "Data Save";
        //        responce.Success = 200;
        //        responce.Response_Timestamp = DateTime.Now;

        //        dynamic propDynamic = new ExpandoObject();
        //        propDynamic.Change_Type = "";
        //        propDynamic.RightMove_ID = 1;
        //        propDynamic.Agent_Ref = ukproperty.Property.AgentRef;
        //        propDynamic.Rightmove_URL = "";
        //        responce.Property = propDynamic;

        //        dynamic propwarning = new ExpandoObject();
        //        propwarning.Warning_Code = "";
        //        propwarning.Warning_Description = "";
        //        propwarning.Warning_Value = "";
        //        responce.Warnings = propwarning;

        //    }
        //    catch (Exception ex)
        //    {
        //        responce.Request_ID = ukproperty.Property.AgentRef;
        //        responce.Success = "";
        //        responce.Message = ex.Message;
        //        responce.Response_Timestamp = DateTime.Now;


        //        dynamic propDynamic = new ExpandoObject();
        //        propDynamic.Change_Type = "";
        //        propDynamic.RightMove_ID = 1;
        //        propDynamic.Agent_Ref = ukproperty.Property.AgentRef;
        //        propDynamic.Rightmove_URL = "";


        //        dynamic errorDynamic = new ExpandoObject();
        //        errorDynamic.Error_Code = ex.HResult;
        //        errorDynamic.Error_Description = ex.Message;
        //        errorDynamic.Error_Value = ex.InnerException.Message;
        //        responce.Property = propDynamic;

        //        dynamic propwarning = new ExpandoObject();
        //        propwarning.Warning_Code = "";
        //        propwarning.Warning_Description = "";
        //        propwarning.Warning_Value = "";
        //        responce.Warnings = propwarning;
        //        responce.Errors = errorDynamic;

        //    }
        //    return responce;
        //}
    }
}
