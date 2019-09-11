using EventeNative_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EventeNative_API.Controllers
{
    public class InteresovanjaController : ApiController
    {
        private EventeNativeEntities db = new EventeNativeEntities();

        [HttpGet]
        [Route("api/Interesovanja/GetInteresovanja/{EventId}/{KorisnikId}/{AuthToken}")]
        public Interesovanja GetInteresovanja(int EventId, int KorisnikId, int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return null;
            
            try
            {
                return db.Interesovanja.Where(x => x.EventId == EventId && x.KorisnikId == KorisnikId).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/Interesovanja/{EventId}/{KorisnikId}/{Zainteresovan}/{Idem}/{AuthToken}")]
        public void PostInteresovanja(int EventId, int KorisnikId, bool Zainteresovan, bool Idem, int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return;

            db.Interesovanja.Add(new Interesovanja { EventId=EventId, KorisnikId=KorisnikId, Zainteresovan=Zainteresovan, Idem=Idem});

            db.SaveChanges();
        }

        [HttpDelete]
        [Route("api/Interesovanja/{EventId}/{KorisnikId}/{AuthToken}")]
        public void DeleteInteresovanja(int EventId, int KorisnikId, int AuthToken)
        {
            db.Interesovanja.Remove(db.Interesovanja.Where(x=> x.EventId==EventId && x.KorisnikId==KorisnikId).FirstOrDefault());

            db.SaveChanges();
        }

        [HttpPatch]
        [Route("api/Interesovanja/{EventId}/{KorisnikId}/{Zainteresovan}/{Idem}/{AuthToken}")]
        public void PatchInteresovanja(int EventId, int KorisnikId, bool Zainteresovan, bool Idem, int AuthToken)
        {
            if ((bool)!db.esp_AuthToken(AuthToken).FirstOrDefault())
                return;
            try
            {
                db.esp_Interesovanja_Update(EventId, KorisnikId, Zainteresovan, Idem);
            }
            catch (Exception)
            {
                
            }

        }

        
    }
}