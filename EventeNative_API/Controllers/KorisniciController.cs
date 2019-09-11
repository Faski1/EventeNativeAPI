using EventeNative_API.Models;
using EventeNative_API.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace EventeNative_API.Controllers
{
    public class KorisniciController : ApiController
    {
        private EventeNativeEntities db= new EventeNativeEntities();

        

        [HttpGet]
        [Route("api/Korisnici/ProvjeraLogin/{username}/{password}")]
        public Korisnici ProvjeraLogin(string username, string password)
        {
            try
            {
                return db.Korisnici.Where(x => x.KorisnickoIme == username && x.Lozinka == password).SingleOrDefault();
            }
            catch (Exception)
            {
                return new Korisnici { };
            }
            
        }
        
        [Route("api/Korisnici/{KorisnickoIme}/{Email}/{Ime}/{Prezime}/{Lozinka}/{AuthToken}")]
        [ResponseType(typeof(Korisnici))]
        public IHttpActionResult PostKorisnici(string KorisnickoIme, string Email, string Ime, string Prezime,  string Lozinka, int AuthToken)
        { 
            try
            {
                db.esp_Korisnici_Insert(Ime, Prezime, Email, KorisnickoIme, Lozinka, AuthToken);

                return Ok();
            }
            catch (EntityException ex)
            {
                if (ex.InnerException != null)
                    throw CreateHttpResponseException(Util.ExceptionHandler.HandleException(ex), HttpStatusCode.Conflict);
                else return null;
            }
          
        }

        private HttpResponseException CreateHttpResponseException(string reason, HttpStatusCode code)
        {
            HttpResponseMessage msg = new HttpResponseMessage()
            {
                StatusCode = code,
                ReasonPhrase = reason,
                Content = new StringContent(reason)
            };
            return new HttpResponseException(msg);
        }

    }
}