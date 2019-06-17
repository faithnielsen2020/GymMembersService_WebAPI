using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GymMembersDataAccess;
using GymMembersService.Models;

namespace GymMembersService.Controllers
{
    public class GymMembersController : ApiController
    {
        //Get All
        public IEnumerable<GymMember> GetMembers()
        {
            List<GymMember> memberListToReturn = new List<GymMember>();

            using (GymMembershipEntities db = new GymMembershipEntities())
            {
                var listOfMembersFromDB = db.Members;
                foreach (var item in listOfMembersFromDB)
                {
                    GymMember gymMemberObj = new GymMember();
                    gymMemberObj.MemberID = item.MEMBER_ID;
                    gymMemberObj.FirstName = item.FIRSTNAME;
                    gymMemberObj.LastName = item.LASTNAME;
                    gymMemberObj.PhoneNumber = item.PHONE;
                    gymMemberObj.EmailAddress = item.EMAIL;
                    gymMemberObj.City = item.CITY;
                    gymMemberObj.CenterID = item.CENTER_ID.ToString();

                    memberListToReturn.Add(gymMemberObj);

                }
                return memberListToReturn;
            }
            
        }


        //Get one
        [HttpGet]
        public HttpResponseMessage GetMemberByID(int id)
        {
            using (GymMembershipEntities db = new GymMembershipEntities())
            {
                var entity = db.Members.FirstOrDefault(m => m.MEMBER_ID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Member with id = " + id.ToString() + " not found");
                }
                else
                {
                    GymMember gymMemberObject = new GymMember();
                    gymMemberObject.MemberID = entity.MEMBER_ID;
                    gymMemberObject.FirstName = entity.FIRSTNAME;
                    gymMemberObject.LastName = entity.LASTNAME;
                    gymMemberObject.PhoneNumber = entity.PHONE;
                    gymMemberObject.EmailAddress = entity.EMAIL;
                    gymMemberObject.City = entity.CITY;
                    gymMemberObject.CenterID = entity.CENTER_ID.ToString();

                    return Request.CreateResponse(HttpStatusCode.OK, gymMemberObject);
                }
            }
        }


        //Create
        public HttpResponseMessage Post([FromBody]Member member)
        {
            try
            {
                using (GymMembershipEntities db = new GymMembershipEntities())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Members.Add(member);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, member);
                    message.Headers.Location = new Uri(Request.RequestUri + member.MEMBER_ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //Delete
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            using (GymMembershipEntities db = new GymMembershipEntities())
            {
                //db.Configuration.ProxyCreationEnabled = false;
                var entity = db.Members.FirstOrDefault(m => m.MEMBER_ID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Member with id = " + id.ToString() + " could not be found to delete");
                }
                else
                {
                    db.Members.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
        }



        //update
        public HttpResponseMessage Put(int id, [FromBody]Member member)
        {
            using (GymMembershipEntities db = new GymMembershipEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                try
                {
                    var entity = db.Members.FirstOrDefault(m => m.MEMBER_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Member with id = " + id.ToString() + " not found and was not updated");
                    }
                    else
                    {
                        entity.FIRSTNAME = member.FIRSTNAME;
                        entity.LASTNAME = member.LASTNAME;
                        entity.PHONE = member.PHONE;
                        entity.EMAIL = member.EMAIL;
                        entity.CITY = member.CITY;
                        entity.CENTER_ID = member.CENTER_ID;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


    }
}
