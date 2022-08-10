using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RightMoveADF.Models;
using RightMoveADF.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace RightMoveADF.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        
        [HttpGet]
        [SwaggerOperation(Summary = "Getting all register user list in portal")]
        [Route("GetAllUser")]
        public ResponceData GetAllUser()
        {
           
            ResponceData responce = new ResponceData();
            try
            {
                List<UserViewModel> result = new List<UserViewModel>();
                using (var context = new CoreDbContext())
                {
                    var dbResult = context.UserRegisters.ToList();
                    foreach (var item in dbResult)
                    {
                        bool isLock = false;
                        if (item.IsLock == null || item.IsLock == false)
                        {
                            isLock = false;
                        }
                        else
                        {
                            isLock = true;
                        }
                        result.Add(new UserViewModel {IsLock= isLock, Id=item.Id,FirstName= item.FirstName, LastName=item.LastName,EmailAddress=item.EmailAddress,PostCode=item.PostCode, ShowDate = item.CreatedDts==null?"": Convert.ToDateTime(item.CreatedDts).ToString("dd-MM-yyyy")});
                    }
                }
                responce.Entity = result.ToList();
                responce.StatusCode = 200;
                responce.Message = "Ok";
            }
            catch (Exception ex)
            {
                responce.Entity =string.Empty;
                responce.StatusCode =ex.InnerException==null?400: ex.InnerException.HResult;
                responce.Message = ex.Message;
                throw;
            }
           
            return responce;
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Create user with some details")]
        [Route("CreateUser")]
        public ResponceData CreateUser([FromForm] UserViewModel model)
        {
            ResponceData responce = new ResponceData();
            try
            {
                //var headers = this.Request.Headers;
                //if (!headers.TryGetValue("Token", out var Token)) /*Checking for token if not then we will consider it as unauthrized*/
                //{
                //    responce.Message = "UnAuthrized";
                //    responce.StatusCode = 401;
                //    return responce;
                //}
                using (var context = new CoreDbContext())
                {
                    UserRegister dbModel = new UserRegister();
                    dbModel.EmailAddress =model.EmailAddress;
                    dbModel.CreatedDts = DateTime.Now;
                    dbModel.FirstName = model.FirstName;
                    dbModel.LastName = model.LastName;
                    dbModel.PostCode = model.PostCode;
                    dbModel.Password = model.Password;
                    dbModel.IsLock=model.IsLock;
                    context.UserRegisters.Add(dbModel);
                    context.SaveChanges();
                }
                
                responce.StatusCode = 200;
                responce.Message = "Ok";
            }
            catch (Exception ex)
            {
                responce.Entity = string.Empty;
                responce.StatusCode = ex.InnerException == null ? 400 : ex.InnerException.HResult;
                responce.Message = ex.Message;
                throw;
            }

            return responce;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create user with some details")]
        [Route("SetUserLockStatus")]
        public ResponceData SetUserLockStatus([FromBody] UserViewModel model)
        {
            ResponceData responce = new ResponceData();
            try
            {
               
                using (var context = new CoreDbContext())
                {
                    var dbModel = context.UserRegisters.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (dbModel != null)
                    {
                        dbModel.IsLock = model.IsLock;
                        context.Entry(dbModel).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }

                responce.StatusCode = 200;
                responce.Message = "Ok";
            }
            catch (Exception ex)
            {
                responce.Entity = string.Empty;
                responce.StatusCode = ex.InnerException == null ? 400 : ex.InnerException.HResult;
                responce.Message = ex.Message;
                throw;
            }

            return responce;
        }

        

        [HttpPost]
        [SwaggerOperation(Summary = "Validate userid with given email address")]
        [Route("ValidateUserId")]
        public ResponceData ValidateUserId([FromForm] UserViewModel model)
        {
            ResponceData responce = new ResponceData();
            try
            {
                //var headers = this.Request.Headers;
                //if (!headers.TryGetValue("Token", out var Token)) /*Checking for token if not then we will consider it as unauthrized*/
                //{
                //    responce.Message = "UnAuthrized";
                //    responce.StatusCode = 401;
                //    return responce;
                //}
                using (var context = new CoreDbContext())
                {
                    var dbModel = context.UserLogins.Where(x => x.UserId == model.EmailAddress).FirstOrDefault();
                    if (dbModel != null)
                    {
                        responce.Entity = "Valid";
                        responce.StatusCode = 200;
                    }
                    else
                    {
                        responce.Entity = "InValid";
                        responce.StatusCode = 400;
                    }
                }

                responce.StatusCode = 200;
                responce.Message = "Ok";
            }
            catch (Exception ex)
            {
                responce.Entity = string.Empty;
                responce.StatusCode = ex.InnerException == null ? 400 : ex.InnerException.HResult;
                responce.Message = ex.Message;
                throw;
            }

            return responce;
        }

    }
}
