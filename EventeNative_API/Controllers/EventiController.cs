using EventeNative_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace EventeNative_API.Controllers
{
    public class EventiController : ApiController
    {
        private EventeNativeEntities db = new EventeNativeEntities();

        [HttpGet]
        [Route("api/Eventi/{AuthToken}/{Query?}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetEventi(int AuthToken, string Query=null)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_GetWithDrzavaGradKat(Query).ToList();
        }

        [HttpGet]
        [Route("api/Eventi/GetInteresovanja/{KorisnikId}/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetInteresovanja(int KorisnikId, int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_Zainteresovani(KorisnikId).ToList();
        }

        [HttpGet]
        [Route("api/Eventi/GetIdem/{KorisnikId}/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetIdem(int KorisnikId, int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_Idem(KorisnikId).ToList();
        }

        [HttpGet]
        [Route("api/Eventi/GetPopularni/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetPopularni(int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_Popularni().ToList();
        }
        [HttpGet]
        [Route("api/Eventi/GetPreporuceni/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetPreporuceni(int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_Preporuceni().ToList();
        }
        [HttpGet]
        [Route("api/Eventi/GetNovi/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetNovi(int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_Novi().ToList();
        }
        [HttpGet]
        [Route("api/Eventi/GetMuzicki/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetMuzicki(int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_Muzicki().ToList();
        }
        [HttpGet]
        [Route("api/Eventi/GetSportski/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetSportski(int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())

                return null;
            return db.esp_Eventi_Sportski().ToList();
        }
        [HttpGet]
        [Route("api/Eventi/GetKulturni/{AuthToken}")]
        public List<esp_Eventi_GetWithDrzavaGradKat_Result> GetKulturni(int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;

            return db.esp_Eventi_Kulturni().ToList();
        }

    }
    
}