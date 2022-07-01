using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web;

namespace MyMVCApplication.Controllers
{
    public class SmsController : Controller
    {
        // GET: Sms
        public ActionResult SMSMode()
        {
            return View();
        }

        private string baseUrl = "https://api.smsmode.com/http/1.6/sendSMS.do";

        //SmsModes.Login" value="afiassurances" ou AccessToken
        //"SmsModes.Pass" value="fr3d3r1c"
        /*Exemple de requete d'envoi de sms*/
        //*https://api.smsmode.com/http/1.6/sendSMS.do?accessToken=Ab1CD2efg3Hi&message=Bonjour+Maman&numero=3363123456,0623123457 **/
        ///**https://api.smsmode.com/http/1.6/sendSMS.do?accessToken=Ab1CD2efg3Hi&message=Bon+anniversaire&numero=3363123456&date_envoi=21122005-14:35 **//

        //[System.Web.Http.Route("api/v2/EnvoieLead")]
        //[System.Web.Http.Authorize(Roles = "PartenaireEnvoie")]
        //public string EnvoieSmS([FromBody] afinet.ui5.Models.EnvoieLead.v2.EnvoieLeadInfo_v2 leadInfo)
        //{
        //    EnvoieLeadContent(leadInfo);

        //    return "Envoie réussi";
        //}
    }
}